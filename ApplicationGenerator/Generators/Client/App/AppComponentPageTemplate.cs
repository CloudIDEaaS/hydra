﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AbstraX.Generators.Client.App
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Utils;
    using AbstraX.Generators;
    using AbstraX.DataAnnotations;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Client\App\AppComponentPageTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    public partial class AppComponentPageTemplate : AbstraX.Generators.Base.TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("<ion-app>\r\n  <ion-router-outlet></ion-router-outlet>\r\n</ion-app>\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\MC\CloudIDEaaS\root\ApplicationGenerator\Generators\Client\App\AppComponentPageTemplate.tt"

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


    }
}


        
        #line default
        #line hidden
    }
    
    #line default
    #line hidden
}
