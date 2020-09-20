﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AbstraX.Generators.Client.Validator
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using Utils;
    using AbstraX.Generators;
    using AbstraX.Angular;
    using AbstraX.Generators.Pages.EditPopupPage;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ValidatorClassTemplate : AbstraX.Generators.Base.TemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            
            #line 19 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
 
    var pageName = this.PageName.ToCamelCase();
    var className = this.PageName + "Validator";
    var provider = new Validator(className);
    var modelVariable = this.EntityName.ToCamelCase();

    this.Providers.Add(provider);

    foreach (var import in this.Imports)
    {
        this.WriteLine(import.DeclarationCode);
    }

            
            #line default
            #line hidden
            this.Write("\r\n@Injectable()\r\nexport class ");
            
            #line 34 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            
            #line default
            #line hidden
            this.Write(" {\r\n\r\n  ");
            
            #line 36 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write("Form: FormGroup;\r\n  validationMap: ValidationMap;\r\n\r\n  constructor(public transla" +
                    "teService: TranslateService) {\r\n    translateService.get([");
            
            #line 40 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
 

    var builder = new StringBuilder();

    foreach (var formField in this.FormFields.GetDisplayed())
    {
        var validationSet = formField.ValidationSet;

        foreach (var entry in validationSet.ValidationEntries)
        {
            builder.AppendWithLeadingIfLength(", ", entry.ErrorMessageTranslationKey.SurroundWithQuotes());
        }
    }

    this.Write(builder.ToString());


            
            #line default
            #line hidden
            this.Write("]).subscribe(values => {\r\n\r\n      this.validationMap = new ValidationMap([\r\n");
            
            #line 59 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

    foreach (var formField in this.FormFields.GetDisplayed())
    {
        var validationSet = formField.ValidationSet;

            
            #line default
            #line hidden
            this.Write("        {\r\n        \"");
            
            #line 65 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.MakeVariable(modelVariable, formField.Name)));
            
            #line default
            #line hidden
            this.Write("\": [\r\n");
            
            #line 66 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

        foreach (var entry in validationSet.ValidationEntries)
        {

            
            #line default
            #line hidden
            this.Write("            {\r\n              \"");
            
            #line 71 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.Name));
            
            #line default
            #line hidden
            this.Write("\":\r\n                {\r\n                  \"function\": ");
            
            #line 73 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(entry.FunctionExpression));
            
            #line default
            #line hidden
            this.Write(",\r\n                  \"message\": ");
            
            #line 74 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Format("values[\"{0}\"]", entry.ErrorMessageTranslationKey)));
            
            #line default
            #line hidden
            this.Write("\r\n                }\r\n            },\r\n");
            
            #line 77 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

        }

            
            #line default
            #line hidden
            this.Write("            {\r\n              // TODO - enable by returning non-null from function" +
                    " and setting message\r\n              \"custom\":\r\n                {\r\n              " +
                    "    \"function\": this.");
            
            #line 84 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.MakeVariable(modelVariable, formField.Name)));
            
            #line default
            #line hidden
            this.Write("Validator(),\r\n                  \"message\": null\r\n                }\r\n            }" +
                    "\r\n          ]\r\n        },\r\n");
            
            #line 90 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("        {\r\n          \"form\": [\r\n            {\r\n               // TODO - enable by" +
                    " returning non-null from function and setting message\r\n              \"");
            
            #line 97 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write("Validator\":\r\n                {\r\n                  \"function\": this.");
            
            #line 99 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write("FormValidator(),\r\n                  \"message\": null\r\n                }\r\n         " +
                    "   }\r\n          ]\r\n        }\r\n      ]);\r\n    });\r\n  }\r\n");
            
            #line 108 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

    builder = new StringBuilder();

    foreach (var formField in this.FormFields.GetDisplayed())
    {
        builder.AppendWithLeadingIfLength(", ", string.Format("{0} : {1}", this.MakeVariable(modelVariable, formField.Name), formField.ClientDataType));
    }


            
            #line default
            #line hidden
            this.Write("\r\n  create");
            
            #line 118 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.EntityName));
            
            #line default
            #line hidden
            this.Write("Form(");
            
            #line 118 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(builder.ToString()));
            
            #line default
            #line hidden
            this.Write("): FormGroup {\r\n\r\n    this.");
            
            #line 120 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write("Form = new FormGroup({\r\n");
            
            #line 121 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

    foreach (var formField in this.FormFields.GetDisplayed())
    {

            
            #line default
            #line hidden
            this.Write("      ");
            
            #line 125 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.MakeVariable(modelVariable, formField.Name)));
            
            #line default
            #line hidden
            this.Write(": new FormControl(");
            
            #line 125 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.MakeVariable(modelVariable, formField.Name)));
            
            #line default
            #line hidden
            this.Write(", this.validationMap.get(\"");
            
            #line 125 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.MakeVariable(modelVariable, formField.Name)));
            
            #line default
            #line hidden
            this.Write("\").functions),\r\n");
            
            #line 126 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("    }, this.validationMap.get(\"form\").functions);\r\n\r\n    return this.");
            
            #line 131 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write("Form;\r\n  }\r\n\r\n  getControl(fieldName : string) : FormControl {\r\n    return <FormC" +
                    "ontrol>this.");
            
            #line 135 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write("Form.get(fieldName);\r\n  }\r\n\r\n  hasValidationErrors(fieldName: string, checkTouche" +
                    "d: boolean = true): boolean {\r\n\r\n    let control = <FormControl>this.");
            
            #line 140 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write(@"Form.get(fieldName);
    let hasError = false;

    this.validationMap.map.get(fieldName).entryMap.forEach((validatorEntry, name) => {

      let touched = checkTouched ? control.touched : true;

      if (touched && (control.hasError(name) || control.hasError(name.toLowerCase()))) {
        hasError = true;
        return false;
      }

    });

    return hasError;
  }

  getValidationErrors(fieldName: string, checkTouched: boolean = true): string[] {

    let errors: string[] = [];
    let control = <FormControl>this.");
            
            #line 160 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write(@"Form.get(fieldName);

    this.validationMap.map.get(fieldName).entryMap.forEach((validatorEntry, name) => {

      let touched = checkTouched ? control.touched : true;

      if (touched && (control.hasError(name) || control.hasError(name.toLowerCase()))) {
        errors.push(validatorEntry.message);
      }

    });

    return errors;
  }

  getValidationErrorsText(fieldName: string): string {

    let control = <FormControl>this.");
            
            #line 177 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write(@"Form.get(fieldName);
    let errors : string[] = [];
    let errorsObject = control.errors;

    Object.getOwnPropertyNames(errorsObject).forEach(p => {

      this.validationMap.map.get(fieldName).entryMap.forEach((validatorEntry, name) => {

        if (name == p || name.toLowerCase() == p) {
          errors.push(validatorEntry.message);
        }
      });
    });

    return errors.join(""\r\n"");
  }

");
            
            #line 194 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

    foreach (var formField in this.FormFields)
    {

            
            #line default
            #line hidden
            this.Write("  ");
            
            #line 198 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(this.MakeVariable(modelVariable, formField.Name)));
            
            #line default
            #line hidden
            this.Write("Validator(): ValidatorFn {\r\n    return (control: AbstractControl): { [key: string" +
                    "]: any } | null => {\r\n      return null;\r\n    };\r\n  }\r\n\r\n");
            
            #line 204 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

    }

            
            #line default
            #line hidden
            this.Write("  ");
            
            #line 207 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(modelVariable));
            
            #line default
            #line hidden
            this.Write("FormValidator(): ValidatorFn {\r\n    return (control: AbstractControl): { [key: st" +
                    "ring]: any } | null => {\r\n      return null;\r\n    };\r\n  }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
        
        #line 1 "D:\MC\RazorViewsDesigner\ApplicationGenerator\Generators\Client\Validator\ValidatorClassTemplate.tt"

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

private global::System.Collections.Generic.List<FormField> _FormFieldsField;

/// <summary>
/// Access the FormFields parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<FormField> FormFields
{
    get
    {
        return this._FormFieldsField;
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

private global::System.Collections.Generic.List<ESModule> _ExportsField;

/// <summary>
/// Access the Exports parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<ESModule> Exports
{
    get
    {
        return this._ExportsField;
    }
}

private global::System.Collections.Generic.List<IDeclarable> _DeclarationsField;

/// <summary>
/// Access the Declarations parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<IDeclarable> Declarations
{
    get
    {
        return this._DeclarationsField;
    }
}

private global::System.Collections.Generic.List<Provider> _ProvidersField;

/// <summary>
/// Access the Providers parameter of the template.
/// </summary>
private global::System.Collections.Generic.List<Provider> Providers
{
    get
    {
        return this._ProvidersField;
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
bool FormFieldsValueAcquired = false;
if (this.Session.ContainsKey("FormFields"))
{
    this._FormFieldsField = ((global::System.Collections.Generic.List<FormField>)(this.Session["FormFields"]));
    FormFieldsValueAcquired = true;
}
if ((FormFieldsValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("FormFields");
    if ((data != null))
    {
        this._FormFieldsField = ((global::System.Collections.Generic.List<FormField>)(data));
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
bool ExportsValueAcquired = false;
if (this.Session.ContainsKey("Exports"))
{
    this._ExportsField = ((global::System.Collections.Generic.List<ESModule>)(this.Session["Exports"]));
    ExportsValueAcquired = true;
}
if ((ExportsValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Exports");
    if ((data != null))
    {
        this._ExportsField = ((global::System.Collections.Generic.List<ESModule>)(data));
    }
}
bool DeclarationsValueAcquired = false;
if (this.Session.ContainsKey("Declarations"))
{
    this._DeclarationsField = ((global::System.Collections.Generic.List<IDeclarable>)(this.Session["Declarations"]));
    DeclarationsValueAcquired = true;
}
if ((DeclarationsValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Declarations");
    if ((data != null))
    {
        this._DeclarationsField = ((global::System.Collections.Generic.List<IDeclarable>)(data));
    }
}
bool ProvidersValueAcquired = false;
if (this.Session.ContainsKey("Providers"))
{
    this._ProvidersField = ((global::System.Collections.Generic.List<Provider>)(this.Session["Providers"]));
    ProvidersValueAcquired = true;
}
if ((ProvidersValueAcquired == false))
{
    object data = global::System.Runtime.Remoting.Messaging.CallContext.LogicalGetData("Providers");
    if ((data != null))
    {
        this._ProvidersField = ((global::System.Collections.Generic.List<Provider>)(data));
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
