﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AbstraX.Generators.Pages.RepeaterPage
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Utils;
    using AbstraX.Generators;
    using AbstraX.Generators.Base;
    using AbstraX.ViewEngine.SemanticTree;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\RepeaterPage\RepeaterPageTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class RepeaterPageTemplate : AbstraX.Generators.Base.DelayedWriterTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 14 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\RepeaterPage\RepeaterPageTemplate.tt"
 
    this.RazorSemanticVisitor.PageWriter = this;
    this.RazorSemanticVisitor.ClassWriter = new NullWriterTemplateBase();

    this.View.SemanticTree.Accept(this.RazorSemanticVisitor);

            
            #line default
            #line hidden
            this.Write("\r\n");
            
            #line 21 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\RepeaterPage\RepeaterPageTemplate.tt"

    this.WriteAll(NodeKind.Markup | NodeKind.Comment);

            
            #line default
            #line hidden
            this.Write("\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Pages\RepeaterPage\RepeaterPageTemplate.tt"

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

private global::AbstraX.ViewEngine.RazorSemanticVisitor _RazorSemanticVisitorField;

/// <summary>
/// Access the RazorSemanticVisitor parameter of the template.
/// </summary>
private global::AbstraX.ViewEngine.RazorSemanticVisitor RazorSemanticVisitor
{
    get
    {
        return this._RazorSemanticVisitorField;
    }
}

private global::AbstraX.ViewEngine.View _ViewField;

/// <summary>
/// Access the View parameter of the template.
/// </summary>
private global::AbstraX.ViewEngine.View View
{
    get
    {
        return this._ViewField;
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
bool RazorSemanticVisitorValueAcquired = false;
if (this.Session.ContainsKey("RazorSemanticVisitor"))
{
    this._RazorSemanticVisitorField = ((global::AbstraX.ViewEngine.RazorSemanticVisitor)(this.Session["RazorSemanticVisitor"]));
    RazorSemanticVisitorValueAcquired = true;
}
if ((RazorSemanticVisitorValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("RazorSemanticVisitor");
    if ((data != null))
    {
        this._RazorSemanticVisitorField = ((global::AbstraX.ViewEngine.RazorSemanticVisitor)(data));
    }
}
bool ViewValueAcquired = false;
if (this.Session.ContainsKey("View"))
{
    this._ViewField = ((global::AbstraX.ViewEngine.View)(this.Session["View"]));
    ViewValueAcquired = true;
}
if ((ViewValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("View");
    if ((data != null))
    {
        this._ViewField = ((global::AbstraX.ViewEngine.View)(data));
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
