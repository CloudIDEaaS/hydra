﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AbstraX.Generators.Pages.WelcomePage
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Utils;
    using AbstraX.Generators;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\WelcomePage\WelcomePageTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class WelcomePageTemplate : AbstraX.Generators.Base.TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 12 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\WelcomePage\WelcomePageTemplate.tt"
 
    // TODO - add template code

            
            #line default
            #line hidden
            this.Write("<ion-content scroll=\"false\">\r\n  <div padding>\r\n    <button ion-button block (clic" +
                    "k)=\"signup()\">Sign up</button>\r\n    <button ion-button block (click)=\"login()\">L" +
                    "ogin</button>\r\n  </div>\r\n</ion-content>\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\WelcomePage\WelcomePageTemplate.tt"

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

private string _PageNameField;

/// <summary>
/// Access the PageName parameter of the template.
/// </summary>
private string PageName
{
    get
    {
        return this._PageNameField;
    }
}

private string _EntityNameField;

/// <summary>
/// Access the EntityName parameter of the template.
/// </summary>
private string EntityName
{
    get
    {
        return this._EntityNameField;
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
bool PageNameValueAcquired = false;
if (this.Session.ContainsKey("PageName"))
{
    this._PageNameField = ((string)(this.Session["PageName"]));
    PageNameValueAcquired = true;
}
if ((PageNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("PageName");
    if ((data != null))
    {
        this._PageNameField = ((string)(data));
    }
}
bool EntityNameValueAcquired = false;
if (this.Session.ContainsKey("EntityName"))
{
    this._EntityNameField = ((string)(this.Session["EntityName"]));
    EntityNameValueAcquired = true;
}
if ((EntityNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("EntityName");
    if ((data != null))
    {
        this._EntityNameField = ((string)(data));
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
