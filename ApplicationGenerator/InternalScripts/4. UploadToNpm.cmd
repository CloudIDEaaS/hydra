set TargetDir="%HYDRASOLUTIONPATH%\HydraCLI\HydraInstall"

%TargetDir:~1,2%
cd %TargetDir%
npm publish
echo publish complete

set TargetDir="%HYDRASOLUTIONPATH%\HydraCLI\HydraCLI"

%TargetDir:~1,2%
cd %TargetDir%
npm publish
echo publish complete