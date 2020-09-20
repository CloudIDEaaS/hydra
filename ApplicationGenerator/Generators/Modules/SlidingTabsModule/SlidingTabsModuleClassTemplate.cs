﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AbstraX.Generators.Modules.SlidingTabsModule
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Utils;
    using AbstraX.Generators;
    using AbstraX.Angular;
    using AbstraX;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class SlidingTabsModuleClassTemplate : AbstraX.Generators.Base.TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("import { NgModule } from \'@angular/core\';\r\nimport { IonicPageModule } from \'ionic" +
                    "-angular\';\r\nimport { SuperTabsModule } from \"ionic2-super-tabs\";\r\n");
            
            #line 19 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"
 
    var className = this.ModuleName;
    var builder = new StringBuilder();
    var component = this.Imports.GetComponent();
    var indent4 = this.GetIndent(4);

    foreach (var import in this.Imports)
    {
        this.WriteLine(import.DeclarationCode);
    }

    // TODO - add module specific imports below this block

            
            #line default
            #line hidden
            this.Write("\r\n@NgModule({\r\n  declarations: [\r\n");
            
            #line 35 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"
  
    foreach (var declarable in this.AngularModule.Declarations)
    {
        builder.AppendWithLeadingIfLength(",\r\n", indent4 + declarable.Name);
    }

    this.WriteLine(builder.ToString());

            
            #line default
            #line hidden
            this.Write("  ],\r\n  imports: [\r\n    SuperTabsModule.forRoot(),\r\n");
            
            #line 45 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"
  if (!IsComponent)
    {

            
            #line default
            #line hidden
            this.Write("    IonicPageModule.forChild(");
            
            #line 48 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(component.Name));
            
            #line default
            #line hidden
            this.Write(")\r\n");
            
            #line 49 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"
  
    }
  
    builder = new StringBuilder();

    if (this.AngularModule.Imports.Count > 0)
    {
        foreach (var import in this.AngularModule.Imports)
        {
            builder.AppendWithLeadingIfLength(",\r\n", indent4 + import.Name);
        }

        this.WriteLine(builder.ToString());
    }

            
            #line default
            #line hidden
            this.Write("  ]");
            
            #line 63 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"
  
    
    if (this.AngularModule.Providers.Count > 0)
    {
        this.WriteLine(",");

            
            #line default
            #line hidden
            this.Write("  providers: [\r\n");
            
            #line 70 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"

        builder = new StringBuilder();

        foreach (var provider in this.AngularModule.Providers)
        {
            builder.AppendWithLeadingIfLength(",\r\n", indent4 + provider.Name);
        }

        this.WriteLine(builder.ToString());

            
            #line default
            #line hidden
            this.Write("  ]");
            
            #line 80 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"

    }

    if (this.AngularModule.Exports.Count > 0)
    {
        this.WriteLine(",");

            
            #line default
            #line hidden
            this.Write("  exports: [\r\n");
            
            #line 88 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"

        builder = new StringBuilder();

        foreach (var export in this.AngularModule.Exports)
        {
            builder.AppendWithLeadingIfLength(",\r\n", indent4 + export.Name);
        }

        if (this.IsComponent)
        {
            builder.AppendWithLeadingIfLength(",\r\n", indent4 + component.Name);
        }

        this.WriteLine(builder.ToString());

            
            #line default
            #line hidden
            this.Write("  ]\r\n");
            
            #line 104 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"

    }
 
            
            #line default
            #line hidden
            this.Write("})\r\nexport class ");
            
            #line 108 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            
            #line default
            #line hidden
            this.Write(" {}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Modules\SlidingTabsModule\SlidingTabsModuleClassTemplate.tt"

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

private global::System.Collections.Generic.IEnumerable<ModuleImportDeclaration> _ImportsField;

/// <summary>
/// Access the Imports parameter of the template.
/// </summary>
private global::System.Collections.Generic.IEnumerable<ModuleImportDeclaration> Imports
{
    get
    {
        return this._ImportsField;
    }
}

private global::AbstraX.Angular.AngularModule _AngularModuleField;

/// <summary>
/// Access the AngularModule parameter of the template.
/// </summary>
private global::AbstraX.Angular.AngularModule AngularModule
{
    get
    {
        return this._AngularModuleField;
    }
}

private string _ModuleNameField;

/// <summary>
/// Access the ModuleName parameter of the template.
/// </summary>
private string ModuleName
{
    get
    {
        return this._ModuleNameField;
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
bool ImportsValueAcquired = false;
if (this.Session.ContainsKey("Imports"))
{
    this._ImportsField = ((global::System.Collections.Generic.IEnumerable<ModuleImportDeclaration>)(this.Session["Imports"]));
    ImportsValueAcquired = true;
}
if ((ImportsValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Imports");
    if ((data != null))
    {
        this._ImportsField = ((global::System.Collections.Generic.IEnumerable<ModuleImportDeclaration>)(data));
    }
}
bool AngularModuleValueAcquired = false;
if (this.Session.ContainsKey("AngularModule"))
{
    this._AngularModuleField = ((global::AbstraX.Angular.AngularModule)(this.Session["AngularModule"]));
    AngularModuleValueAcquired = true;
}
if ((AngularModuleValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("AngularModule");
    if ((data != null))
    {
        this._AngularModuleField = ((global::AbstraX.Angular.AngularModule)(data));
    }
}
bool ModuleNameValueAcquired = false;
if (this.Session.ContainsKey("ModuleName"))
{
    this._ModuleNameField = ((string)(this.Session["ModuleName"]));
    ModuleNameValueAcquired = true;
}
if ((ModuleNameValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("ModuleName");
    if ((data != null))
    {
        this._ModuleNameField = ((string)(data));
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
