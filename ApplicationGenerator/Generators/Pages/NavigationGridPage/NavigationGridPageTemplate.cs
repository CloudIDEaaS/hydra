﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AbstraX.Generators.Pages.NavigationGridPage
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
    
    #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class NavigationGridPageTemplate : AbstraX.Generators.Base.TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 13 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"

    if (this.IsComponent)
    {

            
            #line default
            #line hidden
            this.Write("<ion-fab top right edge>\r\n  <button ion-fab mini (click)=\"this.presentAdd");
            
            #line 18 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.EntityName));
            
            #line default
            #line hidden
            this.Write("($event)\"><ion-icon name=\"add\"></ion-icon></button>\r\n</ion-fab>\r\n<ag-grid-angular" +
                    " #");
            
            #line 20 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.PageName.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write("Grid style=\"height: 500px;\"\r\n  class=\"ag-theme-balham\"\r\n  [enableSorting]=\"true\"\r" +
                    "\n  [enableFilter]=\"true\"\r\n  [rowSelection]=\"multiple\"\r\n  [enableColResize]=\"true" +
                    "\"\r\n  [rowData]=\"rowData | async\"\r\n  [columnDefs]=\"columnDefs\">\r\n</ag-grid-angula" +
                    "r>\r\n");
            
            #line 29 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"

    }
    else
    {

            
            #line default
            #line hidden
            this.Write("<ion-header>\r\n  <ion-navbar>\r\n    <ion-title>");
            
            #line 36 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.PageName));
            
            #line default
            #line hidden
            this.Write("</ion-title>\r\n  </ion-navbar>\r\n</ion-header>\r\n<ion-content padding>\r\n\r\n  <ion-fab" +
                    " top right edge>\r\n    <button ion-fab mini (click)=\"this.presentAdd");
            
            #line 42 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.EntityName));
            
            #line default
            #line hidden
            this.Write("($event)\"><ion-icon name=\"add\"></ion-icon></button>\r\n  </ion-fab>\r\n  <ag-grid-ang" +
                    "ular #");
            
            #line 44 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.PageName.ToCamelCase()));
            
            #line default
            #line hidden
            this.Write(@"Grid style=""height: 500px;""
    class=""ag-theme-balham""
    [enableSorting]=""true""
    [enableFilter]=""true""
    [rowSelection]=""multiple""
    [enableColResize]=""true""
    [rowData]=""rowData | async""
    [columnDefs]=""columnDefs"">
  </ag-grid-angular>

</ion-content>
");
            
            #line 55 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"

    }

            
            #line default
            #line hidden
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\NavigationGridPage\NavigationGridPageTemplate.tt"

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

private bool _IsComponentField;

/// <summary>
/// Access the IsComponent parameter of the template.
/// </summary>
private bool IsComponent
{
    get
    {
        return this._IsComponentField;
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
bool IsComponentValueAcquired = false;
if (this.Session.ContainsKey("IsComponent"))
{
    this._IsComponentField = ((bool)(this.Session["IsComponent"]));
    IsComponentValueAcquired = true;
}
if ((IsComponentValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("IsComponent");
    if ((data != null))
    {
        this._IsComponentField = ((bool)(data));
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
