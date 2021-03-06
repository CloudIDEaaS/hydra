"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ApplicationGeneratorClient = void 0;
const agent_1 = require("./agent");
require("../modules/utils/extensions");
const utils_1 = require("../modules/utils/utils");
const commands = require("./commands");
const linq_javascript_1 = require("linq-javascript");
const installInfo_1 = require("./installInfo");
const events_1 = require("events");
const connectPromise_1 = require("./connectPromise");
const npmInstall_1 = require("./npmInstall");
const readJson = require('read-package-json');
const path = require('path');
const commandLineArgs = require('command-line-args');
const colors = require('colors/safe');
const fs = require('fs');
const beautify = require('js-beautify');
const rimraf = require('rimraf');
const readline = require('readline');
const child_process = require("child_process");
const yaml = require('js-yaml');
const regedit = require('regedit');
const { version } = require('../../package.json');
const commandLineUsage = require('command-line-usage');
class ApplicationGeneratorClient {
    constructor() {
        this.pollingInstallFromCacheStatus = false;
        this.pollingInstallFromCacheStatusComplete = false;
        this.agent = new agent_1.ApplicationGeneratorAgent();
        this.stdout = process.stdout;
        this.stderr = process.stderr;
        this.installs = new linq_javascript_1.Dictionary();
        this.devInstalls = new linq_javascript_1.Dictionary();
        this.onComplete = new events_1.EventEmitter();
        this.installTotalCount = -1;
    }
    static start() {
        let client;
        if (ApplicationGeneratorClient.client === undefined) {
            ApplicationGeneratorClient.client = new ApplicationGeneratorClient();
        }
        client = ApplicationGeneratorClient.client;
        client.launch();
        client.onComplete.on("onComplete", (status = null, isError = false) => {
            if (isError) {
                console.error(status);
            }
            else if (status) {
                console.log(status);
            }
        });
    }
    launch() {
        const mainCommand = commandLineArgs(commands.mainDefinitions, { stopAtFirstUnknown: true });
        let debug = mainCommand.debug;
        let logToConsole = mainCommand.logToConsole;
        let skipInstalls = mainCommand.skipInstalls;
        let skipIonicInstall = mainCommand.skipIonicInstall;
        let noFileCreation = mainCommand.noFileCreation;
        let version = mainCommand.version;
        let help = mainCommand.help;
        let argv = mainCommand._unknown || [];
        let configFile = path.join(process.cwd(), "package.json");
        let commandsFile = path.join(__dirname, "commands.json");
        readJson(commandsFile, console.error, false, (error, data) => {
            if (error) {
                this.writeError("There was an error reading the commands.json file.");
                this.onComplete.emit("onComplete");
                return;
            }
            else {
                this.commands = data.commands;
                if (mainCommand.command === "start") {
                    this.start(argv, logToConsole, skipIonicInstall);
                }
                else if (mainCommand.command === "setPackages") {
                    this.setPackages(argv, logToConsole, configFile);
                }
                else if (mainCommand.command === "build") {
                    this.build(logToConsole);
                }
                else if (mainCommand.command === "delete") {
                    this.delete(argv, logToConsole);
                }
                else if (mainCommand.command === "clean") {
                    this.clean(argv, logToConsole, configFile, data);
                }
                else if (mainCommand.command === "set") {
                    this.set(argv, logToConsole, configFile, data);
                }
                else if (mainCommand.command === "test") {
                    this.test(debug);
                }
                else if (version || mainCommand.command === "version") {
                    this.version(debug);
                }
                else if (help || mainCommand.command === undefined || mainCommand.command === "help") {
                    this.help();
                }
                else {
                    readJson(configFile, console.error, false, (error, data) => {
                        let servicesProjectPath;
                        let entitiesProjectPath;
                        let packageCachePath;
                        if (argv[0] === "app") {
                            if (error) {
                                this.writeError("There was an error reading the package.json file. " + error + "\nDid you run 'hydra start'?");
                                this.onComplete.emit("onComplete");
                                return;
                            }
                            if (!data.servicesProjectPath) {
                                this.writeError("package.json does not include 'servicesProjectPath'");
                                this.onComplete.emit("onComplete");
                                return;
                            }
                            if (!data.entitiesProjectPath) {
                                this.writeError("package.json does not include 'entitiesProjectPath'");
                                this.onComplete.emit("onComplete");
                                return;
                            }
                            servicesProjectPath = utils_1.Utils.expandPath(data.servicesProjectPath);
                            entitiesProjectPath = utils_1.Utils.expandPath(data.entitiesProjectPath);
                            if (data.packageCachePath) {
                                packageCachePath = utils_1.Utils.expandPath(data.packageCachePath);
                            }
                        }
                        if (mainCommand.command === "generate") {
                            this.generate(argv, debug, logToConsole, skipInstalls, entitiesProjectPath, servicesProjectPath, packageCachePath, noFileCreation);
                        }
                        else {
                            this.writeError(`Unknown command: ${mainCommand.command}`);
                        }
                    });
                }
            }
        });
    }
    setPackages(argv, logToConsole, configFile) {
        const generateOptions = commandLineArgs(commands.setPackagesDefinitions, { argv, stopAtFirstUnknown: true });
        let packageListArg = generateOptions.packageListArg;
        let saveDev = generateOptions["save-dev"];
        let clear = generateOptions.clear;
        readJson(configFile, console.error, false, (error, data) => {
            let content;
            let propertyName;
            let packageList = packageListArg ? packageListArg.split(",") : [];
            if (saveDev) {
                propertyName = "devDependencies";
            }
            else {
                propertyName = "dependencies";
            }
            if (error) {
                throw new Error(error);
            }
            for (var property in data) {
                if (property === propertyName) {
                    let packageData = data[property];
                    if (clear) {
                        for (var x in packageData) {
                            if (packageData.hasOwnProperty(x)) {
                                delete packageData[x];
                            }
                        }
                    }
                    packageList.forEach(i => {
                        let packageName;
                        let version;
                        [packageName, version] = i.split("@");
                        packageData[packageName] = version;
                    });
                    break;
                }
            }
            content = beautify(JSON.stringify(data), { indent_size: 2, space_in_empty_paren: true });
            fs.writeFile(configFile, content, 'utf8', (err) => {
                if (err) {
                    throw Error(err);
                }
                this.writeSuccess(`Finished saving ${packageList.length} '${propertyName}' to '${configFile}'`);
            });
        });
    }
    set(argv, logToConsole, configFile, data) {
        const generateOptions = commandLineArgs(commands.setDefinitions, { argv, stopAtFirstUnknown: true });
        let name = generateOptions.name;
        let directory = process.cwd();
        if (name) {
            regedit.putValue({
                'HKCU\\SOFTWARE\\Hydra\\ApplicationGenerator': {
                    'CurrentWorkingDirectory': {
                        value: name,
                        type: 'REG_SZ'
                    }
                }
            }, function (err) {
                throw new Error(err);
            });
        }
        else {
            regedit.putValue({
                'HKCU\\SOFTWARE\\Hydra\\ApplicationGenerator': {
                    'CurrentWorkingDirectory': {
                        value: directory,
                        type: 'REG_SZ'
                    }
                }
            }, function (err) {
                throw new Error(err);
            });
        }
    }
    delete(argv, logToConsole) {
        let rl = readline.createInterface(process.stdin, process.stdout);
        let directory = path.join(process.cwd(), argv[0]);
        let thisWriteError = (o) => {
            this.writeError(o);
        };
        let thisWriteSuccess = (o) => {
            this.writeSuccess(o);
        };
        rl.question(`Delete '${directory}'? [yes]/no: `, function (answer) {
            if (answer !== "yes" && answer !== "y") {
                return;
            }
            fs.readdir(directory, (err, items) => {
                items.forEach((f) => {
                    let fileName = f;
                    let fullName = path.join(directory, fileName);
                    fs.stat(fullName, (err, result) => {
                        rimraf(fullName, (err) => {
                            if (err) {
                                thisWriteError(err);
                                return;
                            }
                        });
                    });
                });
            });
            process.chdir("../");
            rimraf(directory, (err) => {
                if (err) {
                    thisWriteError(err);
                    return;
                }
                process.exit(1);
            });
        });
    }
    build(name) {
        let commandLine = "ionic build";
        let ionicProcess = child_process.exec(commandLine);
        ionicProcess.stdout.on("data", (o) => {
            let p = process;
            let c = p.connected;
            let output = o.toString();
            this.write(output);
        });
        ionicProcess.stderr.on("data", (e) => {
            let p = process;
            let c = p.connected;
            this.writeError(e.toString());
        });
    }
    clean(argv, logToConsole, configFile, configData) {
        let content;
        let directory = process.cwd();
        let rl = readline.createInterface(process.stdin, process.stdout);
        let thisWriteError = (o) => {
            this.writeError(o);
        };
        rl.question(`Clean contents of '${directory}'? [yes]/no: `, function (answer) {
            if (answer !== "yes" && answer !== "y") {
                return;
            }
            for (var property in configData) {
                if (configData.hasOwnProperty(property)) {
                    switch (property) {
                        case "servicesProjectPath":
                        case "entitiesProjectPath":
                            break;
                        default:
                            delete configData[property];
                            break;
                    }
                }
            }
            content = beautify(JSON.stringify(configData), { indent_size: 2, space_in_empty_paren: true });
            fs.writeFile(configFile, content, 'utf8', function (err) {
                if (err) {
                    thisWriteError(err);
                    return;
                }
            });
            fs.readdir(directory, (err, items) => {
                items.forEach((f) => {
                    let fileName = f;
                    let fullName = path.join(directory, fileName);
                    fs.stat(fullName, (err, result) => {
                        if (result.isDirectory() || (fileName !== "package.json" && fileName !== "package.backup.json")) {
                            rimraf(fullName, (err) => {
                                if (err) {
                                    thisWriteError(err);
                                    return;
                                }
                            });
                        }
                    });
                });
            });
        });
    }
    start(argv, logToConsole, skipIonicInstall) {
        const generateOptions = commandLineArgs(commands.startDefinitions, { argv, stopAtFirstUnknown: true });
        let argv2 = generateOptions._unknown || [];
        let name = generateOptions.name;
        let npmCommand = "ionic cordova";
        let cwd = process.cwd();
        let runStart = () => {
            let ionicProcess;
            ionicProcess = this.runIonicStart(name);
            ionicProcess.on("close", () => {
                if (!this.hasError) {
                    let projectPath = path.join(cwd, name);
                    let configFile = path.join(projectPath, "package.json");
                    readJson(configFile, console.error, false, (error, data) => {
                        let content;
                        let configData = {};
                        let hydraConfigFile = path.join(cwd, "hydra.json");
                        if (error) {
                            this.writeError("There was an error reading the package.json file. " + error + "\nDid you run 'hydra start'?");
                            this.onComplete.emit("onComplete");
                            return;
                        }
                        readJson(hydraConfigFile, console.error, false, (error2, data2) => {
                            let servicesProjectPath = "";
                            let entitiesProjectPath = "";
                            let packageCachePath = "";
                            let directories = [];
                            let directory = "";
                            if (!error2) {
                                servicesProjectPath = data2.servicesProjectPath;
                                entitiesProjectPath = data2.entitiesProjectPath;
                                packageCachePath = data2.packageCachePath;
                            }
                            for (var property in data) {
                                if (property === "scripts") {
                                    configData["servicesProjectPath"] = servicesProjectPath;
                                    configData["entitiesProjectPath"] = entitiesProjectPath;
                                    configData["packageCachePath"] = packageCachePath;
                                    configData["config"] = {
                                        ionic_sass: "./config/sass.config.js",
                                        ionic_copy: "./config/copy.config.js",
                                        ionic_generate_source_map: "true",
                                        ionic_source_map_type: "source-map"
                                    };
                                }
                                configData[property] = data[property];
                            }
                            content = beautify(JSON.stringify(configData), { indent_size: 2, space_in_empty_paren: true });
                            fs.writeFile(configFile, content, 'utf8', (err) => {
                                if (err) {
                                    this.writeError(err);
                                    return;
                                }
                                process.chdir(projectPath);
                                directories = ["src/app/pages", "src/app/providers"];
                                directories.forEach((d) => {
                                    let directory = path.join(projectPath, d);
                                    fs.readdir(directory, (err, items) => {
                                        items.forEach((f) => {
                                            let fileName = f;
                                            let fullName = path.join(directory, fileName);
                                            fs.stat(fullName, (err, result) => {
                                                rimraf(fullName, (err) => {
                                                    if (err) {
                                                        this.writeError(err);
                                                        return;
                                                    }
                                                });
                                            });
                                        });
                                    });
                                });
                                this.writeSuccess(`Finished creating project '${name}'. Please set the following fields in package.json: servicesProjectPath, entitiesProjectPath`);
                            });
                        });
                    });
                }
            });
        };
        logToConsole = generateOptions.logToConsole;
        skipIonicInstall = generateOptions.skipIonicInstall;
        if (skipIonicInstall) {
            runStart();
        }
        else {
            this.writeLine("Installing ionic cordova...");
            npmInstall_1.npm.install(npmCommand.split(" "), {
                cwd: cwd,
                save: true,
                output: true,
                global: true
            })
                .then(() => {
                this.writeSuccess(`Finished installing package: ${npmCommand}`);
                runStart();
            })
                .catch((e) => {
                this.writeError(`Unable to install package: ${npmCommand}, Error: ${e}`);
            });
        }
    }
    runIonicStart(name) {
        let template = "conference";
        let type = "ionic-angular";
        //let commandLine = `ionic start ${name} ${template} --type=${type} --cordova --no-link`;
        let commandLine = `ionic start ${name} ${template}`;
        let ionicProcess = child_process.exec(commandLine);
        let dialog = this.commands["ionic start"];
        ionicProcess.stdout.on("data", (o) => {
            let p = process;
            let c = p.connected;
            let output = o.toString();
            if (output.indexOf("Not erasing existing project") > -1) {
                this.hasError = true;
                this.writeError(output);
            }
            else {
                this.write(output);
            }
        });
        ionicProcess.stderr.on("data", (e) => {
            let p = process;
            let c = p.connected;
            let error = e.toString();
            if (error.indexOf("Cloning into ") === -1) {
                this.writeError(error);
            }
        });
        return ionicProcess;
    }
    generate(argv, debug, logToConsole, skipInstalls, entitiesProjectPath, servicesProjectPath, packageCachePath, noFileCreation) {
        const generateOptions = commandLineArgs(commands.generateDefinitions, { argv });
        let emptyLineCount = 0;
        let generateApp = () => {
            this.agent.generateApp(entitiesProjectPath, servicesProjectPath, packageCachePath, noFileCreation, "All", (response) => {
                let eof = false;
                let close = (status) => {
                    let errorHandler = npmInstall_1.npm.getErrorHandler();
                    this.agent.dispose((commandObject) => {
                        this.onComplete.emit("onComplete", status);
                        try {
                            errorHandler();
                        }
                        catch {
                        }
                    });
                };
                if (response.trim().length > 0 && emptyLineCount > 0) {
                    emptyLineCount = 0;
                }
                emptyLineCount += response.getEndingCount("\r\n");
                if (emptyLineCount === 3) {
                    eof = true;
                    this.agent.stopListening();
                }
                else {
                    this.write(response);
                }
                if (eof) {
                    if (skipInstalls) {
                        this.onComplete.emit("onComplete");
                    }
                    else {
                        const installWatch = 1000;
                        const statusWatch = 5000;
                        const statusPrintInterval = 60000;
                        let lastStatusPrint = 0;
                        let usesPackageCache = false;
                        let showCacheProcessingWarning = false;
                        let installing = false;
                        let watchMilliseconds = installWatch;
                        let cacheStatusMode = "installs";
                        let waitingForInstallStatus = false;
                        let installsInProcess = false;
                        let setInstallStatus = (status) => {
                            return new Promise((resolve, reject) => {
                                waitingForInstallStatus = true;
                                this.agent.sendSimpleCommand("setinstallstatus", (commandObject) => {
                                    let cacheStatus = commandObject.Response;
                                    resolve(cacheStatus);
                                    waitingForInstallStatus = false;
                                }, { key: "status", value: status });
                            });
                        };
                        let getCacheStatus = (mode) => {
                            return new Promise((resolve, reject) => {
                                this.agent.sendSimpleCommand("getcachestatus", (commandObject) => {
                                    let cacheStatus = commandObject.Response;
                                    resolve(cacheStatus);
                                }, { key: "mode", value: mode });
                            });
                        };
                        let pollInstallFromCacheStatus = async (mode, listener) => {
                            let getInstallFromCacheStatus = () => {
                                this.agent.getInstallFromCacheStatus(mode, (installsFromCacheStatus) => {
                                    listener(installsFromCacheStatus);
                                    if (installsFromCacheStatus.NothingToPoll) {
                                        this.pollingInstallFromCacheStatusComplete = true;
                                    }
                                    else if (installsFromCacheStatus.TotalRemaining > 0) {
                                        utils_1.Utils.sleep(watchMilliseconds).then(() => {
                                            getInstallFromCacheStatus();
                                        });
                                    }
                                    else {
                                        this.pollingInstallFromCacheStatusComplete = true;
                                    }
                                });
                            };
                            getInstallFromCacheStatus();
                        };
                        let watch = (installs, next) => {
                            utils_1.Utils.sleep(watchMilliseconds).then(() => {
                                installing = installs.any(i => !i.value.InstallAttempted);
                                if (installing) {
                                    if (!this.pollingInstallFromCacheStatus) {
                                        this.pollingInstallFromCacheStatus = true;
                                        pollInstallFromCacheStatus(cacheStatusMode, (s) => this.installsFromCacheStatusListener(s));
                                    }
                                    watch(installs, next);
                                }
                                else if (usesPackageCache) {
                                    watchMilliseconds = statusWatch;
                                    if (showCacheProcessingWarning) {
                                        this.writeWarning("Package cache processing may take a while on first run.  Please be patient.");
                                        showCacheProcessingWarning = false;
                                    }
                                    if (waitingForInstallStatus || installsInProcess) {
                                        watch(installs, next);
                                    }
                                    else if (this.pollingInstallFromCacheStatus && !this.pollingInstallFromCacheStatusComplete) {
                                        watch(installs, next);
                                    }
                                    else if (this.installTotalCount === 0) {
                                        this.installTotalCount = -1;
                                        if (!this.pollingInstallFromCacheStatus) {
                                            this.pollingInstallFromCacheStatus = true;
                                            pollInstallFromCacheStatus(cacheStatusMode, (s) => this.installsFromCacheStatusListener(s));
                                        }
                                        watch(installs, next);
                                    }
                                    else {
                                        getCacheStatus(cacheStatusMode).then((cacheStatus) => {
                                            let now = Date.now();
                                            if (now - lastStatusPrint > statusPrintInterval) {
                                                this.writeStatus(cacheStatus.StatusText);
                                                lastStatusPrint = now;
                                            }
                                            if (cacheStatus.CacheStatus === "EndOfProcessing") {
                                                if (cacheStatusMode === "devInstalls") {
                                                    setInstallStatus("finalized").then((result) => {
                                                        cacheStatusMode = "finalizing";
                                                        watch(installs, next);
                                                    });
                                                    return;
                                                }
                                                else {
                                                    this.writeStatus(cacheStatus.StatusText);
                                                    lastStatusPrint = now;
                                                    next();
                                                    return;
                                                }
                                            }
                                            watch(installs, next);
                                        }).catch((e) => {
                                            this.writeError(`Error: ${e}`);
                                        });
                                    }
                                }
                                else {
                                    next();
                                }
                            }).catch((e) => {
                                this.writeError(`Error: ${e}`);
                            });
                        };
                        if (packageCachePath) {
                            usesPackageCache = true;
                            showCacheProcessingWarning = true;
                        }
                        let installDev = () => {
                            cacheStatusMode = "devInstalls";
                            this.agent.sendSimpleCommand("getpackagedevinstalls", (commandObject) => {
                                let packageInstalls = commandObject.Response;
                                let count = 0;
                                let totalCount = packageInstalls.length;
                                this.installTotalCount = totalCount;
                                if (this.pollingInstallFromCacheStatus && !this.pollingInstallFromCacheStatusComplete) {
                                    throw new Error("Unexpected incompletion of pollingInstallFromCacheStatus");
                                }
                                this.pollingInstallFromCacheStatusComplete = false;
                                this.pollingInstallFromCacheStatus = false;
                                setInstallStatus("installsStarted").then((result) => {
                                    let installNext = () => {
                                        if (packageInstalls.length) {
                                            let install = packageInstalls.pop();
                                            installsInProcess = true;
                                            installDevPackage(install);
                                        }
                                        else {
                                            installsInProcess = false;
                                            setInstallStatus("installsComplete").then((result) => { });
                                        }
                                    };
                                    let installDevPackage = (i) => {
                                        this.devInstalls.set(i, new installInfo_1.InstallInfo(i));
                                        count++;
                                        this.writeLine(`\nAttempting to install ${count} of ${totalCount} dev packages` + "*".repeat(25) + "\n");
                                        this.writeLine(`npm install ${i} --save-dev`);
                                        npmInstall_1.npm.install(i, {
                                            cwd: process.cwd(),
                                            saveDev: true,
                                            output: true
                                        })
                                            .then(() => {
                                            let info = this.devInstalls.get(i);
                                            info.InstallAttempted = true;
                                            info.Succeeded = true;
                                            this.writeSuccess(`Finished installing package: ${i}`);
                                            installNext();
                                        })
                                            .catch((e) => {
                                            let info = this.devInstalls.get(i);
                                            info.InstallAttempted = true;
                                            info.Failed = true;
                                            this.writeError(`Unable to install package: ${i}, Error: ${e}`);
                                            installNext();
                                        });
                                    };
                                    this.writeLine(`\nInstalling ${totalCount} dev dependencies ` + "*".repeat(50) + "\n");
                                    installNext();
                                    watch(this.installs, () => close("\nHydra installs completed!"));
                                });
                            });
                        };
                        this.agent.sendSimpleCommand("getpackageinstalls", (commandObject) => {
                            let packageInstalls = commandObject.Response;
                            let count = 0;
                            let totalCount = packageInstalls.length;
                            let installing = false;
                            let watchMilliseconds = installWatch;
                            let lastStatusPrint = 0;
                            this.installTotalCount = totalCount;
                            if (this.pollingInstallFromCacheStatus && !this.pollingInstallFromCacheStatusComplete) {
                                throw new Error("Unexpected incompletion of pollingInstallFromCacheStatus");
                            }
                            this.pollingInstallFromCacheStatusComplete = false;
                            this.pollingInstallFromCacheStatus = false;
                            setInstallStatus("installsStarted").then((result) => {
                                let installNext = () => {
                                    if (packageInstalls.length) {
                                        let install = packageInstalls.pop();
                                        installsInProcess = true;
                                        installPackage(install);
                                    }
                                    else {
                                        installsInProcess = false;
                                        setInstallStatus("installsComplete").then((result) => { });
                                    }
                                };
                                let installPackage = (i) => {
                                    this.installs.set(i, new installInfo_1.InstallInfo(i));
                                    count++;
                                    this.writeLine(`\nAttempting to install ${count} of ${totalCount} packages ` + "*".repeat(25) + "\n");
                                    this.writeLine(`npm install ${i} --save`);
                                    npmInstall_1.npm.install(i, {
                                        cwd: process.cwd(),
                                        save: true,
                                        output: true
                                    })
                                        .then(() => {
                                        let info = this.installs.get(i);
                                        info.InstallAttempted = true;
                                        info.Succeeded = true;
                                        this.writeSuccess(`Finished installing package: ${i}`);
                                        installNext();
                                    })
                                        .catch((e) => {
                                        let info = this.installs.get(i);
                                        info.InstallAttempted = true;
                                        info.Failed = true;
                                        this.writeError(`Unable to install package: ${i}, Error: ${e}`);
                                        installNext();
                                    });
                                };
                                this.writeLine(`\nInstalling ${totalCount} dependencies ` + "*".repeat(50) + "\n");
                                installNext();
                                watch(this.installs, installDev);
                            });
                        });
                    }
                }
            });
        };
        if (!debug) {
            debug = generateOptions.debug;
        }
        if (!skipInstalls) {
            skipInstalls = generateOptions.skipInstalls;
        }
        if (!noFileCreation) {
            noFileCreation = generateOptions.noFileCreation;
        }
        if (logToConsole) {
            this.logOutputToConsole = true;
        }
        else {
            this.logOutputToConsole = generateOptions.logToConsole;
        }
        if (generateOptions.target === "app") {
            this.initializeAndConnect(debug).then(() => {
                generateApp();
            })
                .catch((e) => {
                this.writeError(`Error: ${e}`);
            });
        }
        else if (generateOptions.target === "workspace") {
            this.initializeAndConnect(debug).then(() => {
                let appName = generateOptions.appName;
                this.agent.generateWorkspace(appName, noFileCreation, "All", (response) => {
                    this.writeSuccess(`Finished generating workspace ${appName}`);
                });
            })
                .catch((e) => {
                this.writeError(`Error: ${e}`);
            });
        }
        else if (generateOptions.target === "businessmodel") {
            this.initializeAndConnect(debug).then(() => {
                let templateFile = generateOptions.template;
                this.agent.generateBusinessModel(templateFile, noFileCreation, "All", (response) => {
                    this.writeSuccess(`Finished generating business model from ${templateFile}`);
                });
            })
                .catch((e) => {
                this.writeError(`Error: ${e}`);
            });
        }
        else if (generateOptions.target === "entities") {
            this.initializeAndConnect(debug).then(() => {
                let templateFile = generateOptions.template;
                let businessModelFile = generateOptions.businessmodel;
                let jsonFile = generateOptions.json;
                this.agent.generateEntities(templateFile, jsonFile, businessModelFile, entitiesProjectPath, noFileCreation, "All", (response) => {
                    this.writeSuccess(`Finished generating entities`);
                });
            })
                .catch((e) => {
                this.writeError(`Error: ${e}`);
            });
        }
        else {
            this.writeError(`Unknown target: ${generateOptions.target}`);
        }
    }
    setPackageJsonConfig(configPath, packageList, callback) {
    }
    setPackageYamlConfig(configPath, packageList, callback) {
        let configData = yaml.safeLoad(fs.readFileSync(configPath, 'utf8'));
        let packagesSection = configData["packages"];
        let configContents;
        let scopedAllProperty = "@*/*";
        let allProperty = "**";
        let scopedAll;
        let all;
        if (!packagesSection.hasOwnProperty(`'${scopedAllProperty}'`)) {
            scopedAll = packagesSection[scopedAllProperty];
            delete packagesSection[scopedAllProperty];
        }
        if (!packagesSection.hasOwnProperty(`'${allProperty}'`)) {
            all = packagesSection[allProperty];
            delete packagesSection[allProperty];
        }
        packageList.forEach((p) => {
            if (!packagesSection.hasOwnProperty(p)) {
                if (this.isQuotablePropertyName(p)) {
                    packagesSection[`${p}`] = { access: "$all", publish: "$all" };
                }
                else {
                    packagesSection[`\ua725${p}\ua725`] = { access: "$all", publish: "$all" };
                }
            }
        });
        if (scopedAll) {
            packagesSection[`${scopedAllProperty}`] = scopedAll;
        }
        if (all) {
            packagesSection[`${allProperty}`] = all;
        }
        configContents = yaml.safeDump(configData);
        configContents = configContents.replace(/\ua725/g, "'");
        fs.writeFile(configPath, configContents, function (err) {
            if (err) {
                callback(err);
            }
            else {
                callback(null);
            }
        });
    }
    isQuotablePropertyName(str) {
        return /^[@~`!#$%\^&*+=\-\[\]\\';,/{}|\\":<>\?]/g.test(str);
    }
    cachePackageData(packageCachePath, callback) {
        // figure out versioning, refresh, etc.
        let packageDataFile = path.join(packageCachePath, ".verdaccio-db.json");
        this.writeLine("Caching package data");
        readJson(packageDataFile, console.error, false, (error2, data) => {
            let content;
            let packageList = data["list"];
            fs.readdir(packageCachePath, (err, items) => {
                if (err) {
                    callback(err);
                }
                else {
                    let count = items.length;
                    items.forEach((f) => {
                        let fileName = f;
                        let fullName = path.join(packageCachePath, fileName);
                        fs.stat(fullName, (err, result) => {
                            count--;
                            if (err) {
                                callback(err);
                            }
                            else {
                                if (!result.isFile()) {
                                    if (!packageList.includes(fileName)) {
                                        packageList.push(fileName);
                                    }
                                }
                                if (count === 0) {
                                    content = beautify(JSON.stringify(data), { indent_size: 2, space_in_empty_paren: true });
                                    fs.writeFile(packageDataFile, content, 'utf8', (err) => {
                                        let packageConfigPath = path.join(packageCachePath, "..\\", "config.yaml");
                                        if (err) {
                                            callback(err);
                                            return;
                                        }
                                        this.setPackageYamlConfig(packageConfigPath, packageList, callback);
                                    });
                                }
                            }
                        });
                    });
                }
            });
        });
    }
    initializeAndConnect(debug) {
        let promise = new connectPromise_1.ConnectPromise();
        this.agent.initialize(debug);
        this.agent.onError.on("onError", (e) => {
            this.writeError(e);
            this.dispose();
        });
        this.agent.sendSimpleCommand("connect", (connectObject) => {
            if (connectObject.Response === "Connected successfully") {
                this.writeSuccess("Connected");
                promise.resolve("Connected");
            }
            else {
                promise.reject(connectObject.Response);
            }
        });
        return promise;
    }
    dispose() {
    }
    version(debug) {
        let clientVersion = version;
        this.writeLine("     ./&.                                       *((                             ");
        this.writeLine("     ,(#.                                       (#*                             ");
        this.writeLine("     *((..*///*    .,,         .*.    .*////*.  (#,  ,*..*//,    ,*///*,  .*.   ");
        this.writeLine("     /%#(/*,,,/%/. ./%,       /#(. ./#(/,,,,*(#/%(  ,(&#(*,.. ,(#(*,,,*/#(#%,   ");
        this.writeLine("     (%*.      /#(  ,(%,    .##*  /#/.        ,%%/  *#%,    ,(#*         /%#    ");
        this.writeLine("    *#(        /(/   .%(,  *##,  *#(          .((*  /#*.   ./&,          ,((    ");
        this.writeLine("   ./(/        #(*    ,#( (#/    *#(          ,%/.  (#     ./&,          ((/    ");
        this.writeLine("   .#(,       .%(.     *#&#*      /#/.      ,/%&*  ,#(      ,##*      .*#&#,    ");
        this.writeLine("   .#*.       ,#*      *##.        ./##(((((/*/#,  *(*        *(#((((((/,#*     ");
        this.writeLine("                     .(#/                                                       ");
        this.writeLine("                    ,##,                                                        ");
        this.writeLine("                     .                                                          ");
        this.writeLine("                                       .,*//((##%%%&&&&&&&&&&&&&%%#((/*.        ");
        this.writeLine("                             .,,*/(#&&@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#,     ");
        this.writeLine("                      ..,/#&@@@@@@@@@@@@@@@@@@@&&&&&%%%%#########(//////*       ");
        this.writeLine("                 ./%&@@@@@@@@@@@@@&&%%##(((((((((((((((((((((((/,               ");
        this.writeLine("           *(#%&@@@@@&&%%%#####((((((((((((((((((((((((((((((((,                ");
        this.writeLine("     ,*(#%&&%%%####(((((((((((((((((((((((((((((((((((((((((((*.                ");
        this.writeLine(",,*(####((((((((((((((((((((((((((((((((((((((((((((((((((((((*.                ");
        this.writeLine("#(((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((*.                ");
        this.writeLine("#((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((,                ");
        this.writeLine("#((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((/*               ");
        this.writeLine("#((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((/,.            ");
        this.writeLine("#((((((((((((((((((((((((((((((((((((((((((((((((#####%%%%%&&&&&&&&%#(**,,.     ");
        this.writeLine("#((((((((((((((((((((((((((((((((((((((((###%&&@@@@@@@@@@@@@@@@@@@@@@&&&&@@&%,  ");
        this.writeLine("#(((((((((((((((((((((((((((((((((#%%&@@@@@@@@&&&%%%####((((((((((((/.          ");
        this.writeLine("#((((((((((((((((((((((((((##%&&&&%%%######((((((((((((((((((((((((*            ");
        this.writeLine("#((((((((((((((((((((((((####(((((((((((((((((((((((((((((((((((((/,            ");
        this.writeLine("#(((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((/,            ");
        this.writeLine("#((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((((/.           ");
        this.writeLine("");
        this.writeLine(`Client version v${clientVersion} `);
        this.initializeAndConnect(debug).then(() => {
            this.agent.sendSimpleCommand("getversion", (commandObject) => {
                let appGeneratorVersion = commandObject.Response;
                this.writeLine(`ApplicationGenerator version v${appGeneratorVersion} `);
                this.writeLine("Copyright 2020 CloudIDEaaS");
                this.writeLine("visit: http://www.cloudideaas.com/hydra");
                this.agent.dispose((commandObject) => {
                    this.onComplete.emit("onComplete");
                });
            });
        });
    }
    help() {
        let mainDefinitions = new linq_javascript_1.List(commands.mainDefinitions);
        let availableCommands = mainDefinitions.where(d => d.type.name === "String");
        let globalOptions = mainDefinitions.where(d => d.type.name !== "String");
        let definitionsWithInner = mainDefinitions.where(d => Object.keys(d).includes("innerDefinitions"));
        let sections = [
            {
                content: commands.HELP_HEADER,
                raw: true
            },
            {
                header: "Available Commands",
                content: availableCommands.select(c => ({ name: c.name, summary: c.description })).toArray(),
            },
            {
                header: "Global Options",
                content: globalOptions.select(c => ({ name: c.name, summary: c.description })).toArray(),
            },
        ];
        this.addSections(sections, definitionsWithInner);
        const usage = commandLineUsage(sections);
        this.write(usage);
    }
    addSections(sections, definitions) {
        definitions.forEach(d => {
            let name = d.name;
            let innerDefinitions = new linq_javascript_1.List(d["innerDefinitions"]);
            let definitionsWithInner = innerDefinitions.where(d => Object.keys(d).includes("innerDefinitions"));
            let section = {
                header: `Commands and options for ${name}`,
                content: innerDefinitions.where(c => c.description !== undefined).select(c => ({ name: c.name, summary: c.description })).toArray(),
            };
            sections.push(section);
            this.addSections(sections, definitionsWithInner);
        });
    }
    test(debug) {
        const watchMilliseconds = 1000;
        let pollInstallFromCacheStatus = async (mode, listener) => {
            let getInstallFromCacheStatus = () => {
                this.agent.getInstallFromCacheStatus(mode, (installsFromCacheStatus) => {
                    listener(installsFromCacheStatus);
                    this.writeLine(installsFromCacheStatus.StatusText);
                    if (installsFromCacheStatus.TotalRemaining > 0) {
                        utils_1.Utils.sleep(watchMilliseconds).then(() => {
                            getInstallFromCacheStatus();
                        });
                    }
                    else {
                        this.pollingInstallFromCacheStatusComplete = true;
                    }
                });
            };
            getInstallFromCacheStatus();
        };
        this.initializeAndConnect(debug).then(() => {
            this.pollingInstallFromCacheStatus = false;
            this.pollingInstallFromCacheStatusComplete = false;
            let close = () => {
                this.agent.dispose((commandObject) => {
                    this.onComplete.emit("onComplete");
                });
            };
            let watch = (next) => {
                utils_1.Utils.sleep(watchMilliseconds).then(() => {
                    if (this.pollingInstallFromCacheStatusComplete) {
                        next();
                    }
                    else {
                        watch(next);
                    }
                });
            };
            this.writeStatus("This is a test. Nothing will actually be installed.  This tests the full connectivity of Hydra including the local Package Cache service.");
            pollInstallFromCacheStatus("Testing", (s) => this.installsFromCacheStatusListener(s));
            watch(() => {
                this.writeStatus("Test complete.");
                close();
            });
        });
    }
    writeStatus(output) {
        if (!output) {
            console.error("No writeStatus output provided");
        }
        this.writeLine(output);
    }
    writeLine(output) {
        this.stdout.writeLine(output);
        if (this.logOutputToConsole) {
            console.log(output);
        }
    }
    write(output) {
        this.stdout.write(output);
        if (this.logOutputToConsole) {
            console.log(output);
        }
    }
    writeConsole(output) {
        if (this.logOutputToConsole) {
            console.log(output);
        }
    }
    writeError(output) {
        let coloredOutput = colors.red(output);
        this.stderr.writeLine(coloredOutput);
        if (this.logOutputToConsole) {
            console.log(coloredOutput);
        }
    }
    writeWarning(output) {
        let coloredOutput = colors.yellow(output);
        this.stderr.writeLine(coloredOutput);
        if (this.logOutputToConsole) {
            console.log(coloredOutput);
        }
    }
    writeSuccess(output) {
        let coloredOutput = colors.green(output);
        this.stdout.writeLine(coloredOutput);
        if (this.logOutputToConsole) {
            console.log(coloredOutput);
        }
    }
    installsFromCacheStatusListener(installsFromCacheStatus) {
        if (installsFromCacheStatus.InstallFromCacheStatus.length > 0) {
            installsFromCacheStatus.InstallFromCacheStatus.forEach((i) => {
                if (i.StatusIsError) {
                    this.writeError(i.StatusText);
                }
                else if (i.StatusIsSuccess) {
                    this.writeSuccess(i.StatusText);
                }
                else {
                    this.writeLine(i.StatusText);
                }
            });
        }
        else {
            if (installsFromCacheStatus.StatusIsError) {
                this.writeError(installsFromCacheStatus.StatusSummary);
            }
            else if (installsFromCacheStatus.StatusIsSuccess) {
                this.writeSuccess(installsFromCacheStatus.StatusSummary);
            }
            else if (installsFromCacheStatus.StatusSummary) {
                this.writeLine(installsFromCacheStatus.StatusSummary);
            }
        }
    }
}
exports.ApplicationGeneratorClient = ApplicationGeneratorClient;
//# sourceMappingURL=client.js.map