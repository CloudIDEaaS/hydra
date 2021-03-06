﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AbstraX.Generators.Server.WebAPIStartupGraphQLSchemas
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Utils;
    using AbstraX.Generators;
    using AbstraX.Angular;
    using AbstraX.DataAnnotations;
    using AbstraX;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class WebAPIStartupGraphQLSchemasClassTemplate : AbstraX.Generators.Base.TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.Extensions.DependencyInjection;
using ");
            
            #line 24 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.RootNamespace));
            
            #line default
            #line hidden
            this.Write(".GraphQL;\r\n\r\n\r\nnamespace ");
            
            #line 27 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.RootNamespace));
            
            #line default
            #line hidden
            this.Write(".Services\r\n{\r\n    public static class StartupSchemasExtensions\r\n    {\r\n        pu" +
                    "blic static IApplicationBuilder AddSchemas(this IApplicationBuilder app)\r\n      " +
                    "  {\r\n");
            
            #line 33 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"

    foreach (var schema in this.Schemas)
    {

            
            #line default
            #line hidden
            this.Write("            app.UseGraphQL<");
            
            #line 37 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(schema));
            
            #line default
            #line hidden
            this.Write("Schema>();\r\n");
            
            #line 38 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("\r\n            return app;\r\n        }\r\n\r\n        public static IServiceCollection " +
                    "AddSchemas(this IServiceCollection services)\r\n        {\r\n");
            
            #line 47 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"

    foreach (var schema in this.Schemas)
    {

            
            #line default
            #line hidden
            this.Write("            services.AddScoped<");
            
            #line 51 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(schema));
            
            #line default
            #line hidden
            this.Write("Schema>();\r\n");
            
            #line 52 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("\r\n            return services;\r\n        }\r\n    }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Server\WebAPIStartupGraphQLSchemas\WebAPIStartupGraphQLSchemasClassTemplate.tt"

private global::System.EventHandler _DebugCallbackField;

/// <summary>
/// Access the DebugCallback parameter of the template.
/// </summary>
private global::System.EventHandler DebugCallback
{
    get
    {
        return this._DebugCallbackField;
    }
}

private string _RootNamespaceField;

/// <summary>
/// Access the RootNamespace parameter of the template.
/// </summary>
private string RootNamespace
{
    get
    {
        return this._RootNamespaceField;
    }
}

private string[] _SchemasField;

/// <summary>
/// Access the Schemas parameter of the template.
/// </summary>
private string[] Schemas
{
    get
    {
        return this._SchemasField;
    }
}


/// <summary>
/// Initialize the template
/// </summary>
public override void Initialize()
{
    base.Initialize();
    if ((this.Errors.HasErrors == false))
    {
bool DebugCallbackValueAcquired = false;
if (this.Session.ContainsKey("DebugCallback"))
{
    this._DebugCallbackField = ((global::System.EventHandler)(this.Session["DebugCallback"]));
    DebugCallbackValueAcquired = true;
}
if ((DebugCallbackValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("DebugCallback");
    if ((data != null))
    {
        this._DebugCallbackField = ((global::System.EventHandler)(data));
    }
}
bool RootNamespaceValueAcquired = false;
if (this.Session.ContainsKey("RootNamespace"))
{
    this._RootNamespaceField = ((string)(this.Session["RootNamespace"]));
    RootNamespaceValueAcquired = true;
}
if ((RootNamespaceValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("RootNamespace");
    if ((data != null))
    {
        this._RootNamespaceField = ((string)(data));
    }
}
bool SchemasValueAcquired = false;
if (this.Session.ContainsKey("Schemas"))
{
    this._SchemasField = ((string[])(this.Session["Schemas"]));
    SchemasValueAcquired = true;
}
if ((SchemasValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Schemas");
    if ((data != null))
    {
        this._SchemasField = ((string[])(data));
    }
}


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
