#pragma checksum "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14b9ae5fe6c8280802c8993c080f3a80635cb9eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AcademicosCoordinadores_CrearProgramaTransversal), @"mvc.1.0.view", @"/Views/AcademicosCoordinadores/CrearProgramaTransversal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AcademicosCoordinadores/CrearProgramaTransversal.cshtml", typeof(AspNetCore.Views_AcademicosCoordinadores_CrearProgramaTransversal))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\_ViewImports.cshtml"
using SGCFIEE;

#line default
#line hidden
#line 2 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\_ViewImports.cshtml"
using SGCFIEE.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14b9ae5fe6c8280802c8993c080f3a80635cb9eb", @"/Views/AcademicosCoordinadores/CrearProgramaTransversal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225633a62ddc17bf9f6645008885b94288a8c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_AcademicosCoordinadores_CrearProgramaTransversal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCFIEE.Models.CoordinadorProgramaTransversal>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("archivo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("required", new global::Microsoft.AspNetCore.Html.HtmlString("required"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AcademicosCoordinadores", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IndexProgramaTransversal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default btn-sm m-b-10"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GuardarProgramaTransversal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
  
    ViewData["Title"] = "CrearProgramaTransversal";
    Layout = "~/Views/Home/Principal.cshtml";
    var acad = (IEnumerable<Academicos>)ViewData["academicos"];
    var perio = (IEnumerable<TipoPeriodo>)ViewData["periodos"];
    var programa = (IEnumerable<ProgramasTrasversales>)ViewData["programas"];

#line default
#line hidden
            BeginContext(371, 379, true);
            WriteLiteral(@"<!DOCTYPE html>

<html>
    <div class=""row"">
        <div class=""col-md-12 col-sm-12"">
            <div class=""card card-box"">
                <div class=""card-topline-green card-head"">
                    <header>COORDINADOR DE PROGRAMA TRANSVERSAL</header>        
                </div>
                <div class=""card-body "" id=""bar-parent2"">
                    ");
            EndContext();
            BeginContext(750, 3730, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb9258", async() => {
                BeginContext(881, 265, true);
                WriteLiteral(@" 
                        <div class=""row"">
                            <div class=""col-md-6 col-md-6"">

                                <div class=""form-group"">
                                    <label>Académico</label>
                                    ");
                EndContext();
                BeginContext(1146, 489, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb9911", async() => {
                    BeginContext(1197, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 26 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                         foreach (var item in acad)
                                        {

#line default
#line hidden
                    BeginContext(1311, 44, true);
                    WriteLiteral("                                            ");
                    EndContext();
                    BeginContext(1355, 190, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb10740", async() => {
                        BeginContext(1391, 41, false);
#line 28 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                                                          Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
                        EndContext();
                        BeginContext(1432, 1, true);
                        WriteLiteral(" ");
                        EndContext();
                        BeginContext(1434, 50, false);
#line 28 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                                                                                                     Write(Html.DisplayFor(modelItem => item.ApellidoPaterno));

#line default
#line hidden
                        EndContext();
                        BeginContext(1484, 1, true);
                        WriteLiteral(" ");
                        EndContext();
                        BeginContext(1486, 50, false);
#line 28 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                                                                                                                                                         Write(Html.DisplayFor(modelItem => item.ApellidoMaterno));

#line default
#line hidden
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#line 28 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                               WriteLiteral(item.IdAcademicos);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(1545, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 29 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                        }

#line default
#line hidden
                    BeginContext(1590, 36, true);
                    WriteLiteral("                                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 25 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdAcademico);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1635, 209, true);
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group\">\r\n                                    <label>Programa transversal</label>\r\n                                    ");
                EndContext();
                BeginContext(1844, 393, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb16160", async() => {
                    BeginContext(1888, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 35 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                         foreach (var item in programa)
                                        {

#line default
#line hidden
                    BeginContext(2006, 44, true);
                    WriteLiteral("                                            ");
                    EndContext();
                    BeginContext(2050, 97, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb16993", async() => {
                        BeginContext(2097, 41, false);
#line 37 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                                                                     Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#line 37 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                               WriteLiteral(item.IdProgramasTrasversales);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2147, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 38 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                        }

#line default
#line hidden
                    BeginContext(2192, 36, true);
                    WriteLiteral("                                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 34 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdPt);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2237, 303, true);
                WriteLiteral(@"
                                </div>
                            </div>
                            <div class=""col-md-6 col-md-6"">
                                <div class=""form-group"">
                                    <label>Periodo de inicio</label>
                                    ");
                EndContext();
                BeginContext(2540, 386, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb21363", async() => {
                    BeginContext(2594, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 46 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                         foreach (var item in perio)
                                        {

#line default
#line hidden
                    BeginContext(2709, 44, true);
                    WriteLiteral("                                            ");
                    EndContext();
                    BeginContext(2753, 83, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb22193", async() => {
                        BeginContext(2786, 41, false);
#line 48 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                                                       Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#line 48 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                               WriteLiteral(item.IdPeriodo);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2836, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 49 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                        }

#line default
#line hidden
                    BeginContext(2881, 36, true);
                    WriteLiteral("                                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 45 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdFechaInicial);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2926, 208, true);
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group\">\r\n                                    <label>Periodo de termino </label>\r\n                                    ");
                EndContext();
                BeginContext(3134, 385, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb26455", async() => {
                    BeginContext(3187, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 55 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                         foreach (var item in perio)
                                        {

#line default
#line hidden
                    BeginContext(3302, 44, true);
                    WriteLiteral("                                            ");
                    EndContext();
                    BeginContext(3346, 83, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb27285", async() => {
                        BeginContext(3379, 41, false);
#line 57 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                                                       Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#line 57 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                               WriteLiteral(item.IdPeriodo);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(3429, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 58 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
                                        }

#line default
#line hidden
                    BeginContext(3474, 36, true);
                    WriteLiteral("                                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 54 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdFechaCierre);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3519, 209, true);
                WriteLiteral("\r\n                                </div>\r\n                                <div class=\"form-group\">\r\n                                    <label>Subir evidencia:</label><br>\r\n                                    ");
                EndContext();
                BeginContext(3728, 100, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb31547", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 63 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosCoordinadores\CrearProgramaTransversal.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Evidencia);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Name = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3828, 330, true);
                WriteLiteral(@"
                                </div>
                                <br>
                                <button type=""submit"" class=""btn btn-success btn-sm m-b-10"" name=""Guardar"" style=""float:right"">
                                    Guardar
                                </button>
                                 ");
                EndContext();
                BeginContext(4158, 225, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "14b9ae5fe6c8280802c8993c080f3a80635cb9eb34196", async() => {
                    BeginContext(4298, 81, true);
                    WriteLiteral("\r\n                                    Cancelar\r\n                                 ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4383, 90, true);
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4480, 79, true);
            WriteLiteral("\r\n            </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</html>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGCFIEE.Models.CoordinadorProgramaTransversal> Html { get; private set; }
    }
}
#pragma warning restore 1591
