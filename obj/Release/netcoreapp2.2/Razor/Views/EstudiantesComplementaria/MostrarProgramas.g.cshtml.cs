#pragma checksum "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ce16541258be91856c6f19976b5db51923ed61d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EstudiantesComplementaria_MostrarProgramas), @"mvc.1.0.view", @"/Views/EstudiantesComplementaria/MostrarProgramas.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EstudiantesComplementaria/MostrarProgramas.cshtml", typeof(AspNetCore.Views_EstudiantesComplementaria_MostrarProgramas))]
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
#line 1 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\_ViewImports.cshtml"
using SGCFIEE;

#line default
#line hidden
#line 2 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\_ViewImports.cshtml"
using SGCFIEE.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ce16541258be91856c6f19976b5db51923ed61d", @"/Views/EstudiantesComplementaria/MostrarProgramas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225633a62ddc17bf9f6645008885b94288a8c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesComplementaria_MostrarProgramas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SGCFIEE.Models.ProgramaEducativo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EstudiantesComplementaria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetallesPrograma", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-xs infoextra"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Toda la información"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditarPrograma", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-xs editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EliminarPrograma", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-xs eliminar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Eliminar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
  


    ViewData["Title"] = "Mostrar Programas";
    Layout = "~/Views/Home/Principal.cshtml";

#line default
#line hidden
            BeginContext(158, 1344, true);
            WriteLiteral(@"
<!DOCTYPE html>

<html>
<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card card-topline-green"">
            <div class=""card-head"">
                <header>PROGRAMAS EDUCATIVOS</header>
                <div class=""tools"">
                    <a class=""fa fa-repeat btn-color box-refresh"" href=""javascript:;""></a>
                    <a class=""t-collapse btn-color fa fa-chevron-down"" href=""javascript:;""></a>
                    <a class=""t-close btn-color fa fa-times"" href=""javascript:;""></a>
                </div>
            </div>
            <div class=""card-body "">
                <table class=""table table-striped table-bordered table-hover table-checkable order-column"" style=""width: 100%"" id=""tbcomp"">
                    <thead>
                        <tr>
                            <th style=""width: 150px;""> Nombre    </th>
                            <th class=""center""> Creditos </th>
                            <th class=""center""> Clave </th>
                ");
            WriteLiteral(@"            <th class=""center""> Facultad</th>
                            <th class=""center""> Area </th>
                            <th style=""display: none""></th>
                            <th class=""center"">Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 37 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(1583, 106, true);
            WriteLiteral("                            <tr class=\"odd gradeX\">\r\n\r\n                                <td class=\"center\">");
            EndContext();
            BeginContext(1690, 41, false);
#line 41 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1731, 58, true);
            WriteLiteral("</td>\r\n                                <td class=\"center\">");
            EndContext();
            BeginContext(1790, 43, false);
#line 42 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.Creditos));

#line default
#line hidden
            EndContext();
            BeginContext(1833, 58, true);
            WriteLiteral("</td>\r\n                                <td class=\"center\">");
            EndContext();
            BeginContext(1892, 46, false);
#line 43 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.ClvPrograma));

#line default
#line hidden
            EndContext();
            BeginContext(1938, 58, true);
            WriteLiteral("</td>\r\n                                <td class=\"center\">");
            EndContext();
            BeginContext(1997, 43, false);
#line 44 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.Facultad));

#line default
#line hidden
            EndContext();
            BeginContext(2040, 58, true);
            WriteLiteral("</td>\r\n                                <td class=\"center\">");
            EndContext();
            BeginContext(2099, 39, false);
#line 45 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.Area));

#line default
#line hidden
            EndContext();
            BeginContext(2138, 210, true);
            WriteLiteral("</td>\r\n                                <td style=\"display: none\"></td>\r\n\r\n                                <td>\r\n                                    <div class=\"center\">\r\n                                        ");
            EndContext();
            BeginContext(2348, 305, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ce16541258be91856c6f19976b5db51923ed61d11688", async() => {
                BeginContext(2534, 115, true);
                WriteLiteral("\r\n                                            <i class=\"fa fa-check\"></i>\r\n                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 50 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                                             WriteLiteral(item.IdProgramaEducativo);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2653, 42, true);
            WriteLiteral("\r\n                                        ");
            EndContext();
            BeginContext(2695, 288, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ce16541258be91856c6f19976b5db51923ed61d14614", async() => {
                BeginContext(2863, 116, true);
                WriteLiteral("\r\n                                            <i class=\"fa fa-pencil\"></i>\r\n                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                                             WriteLiteral(item.IdProgramaEducativo);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2983, 42, true);
            WriteLiteral("\r\n                                        ");
            EndContext();
            BeginContext(3025, 295, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5ce16541258be91856c6f19976b5db51923ed61d17541", async() => {
                BeginContext(3198, 118, true);
                WriteLiteral("\r\n                                            <i class=\"fa fa-trash-o \"></i>\r\n                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 56 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                                             WriteLiteral(item.IdProgramaEducativo);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
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
            BeginContext(3320, 120, true);
            WriteLiteral("\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 62 "C:\Users\abrah\Documents\TrabajoWEBSGCFIEE\SGCFIEE\SGCFIEE\SGCFIEE\Views\EstudiantesComplementaria\MostrarProgramas.cshtml"
                        }

#line default
#line hidden
            BeginContext(3467, 121, true);
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SGCFIEE.Models.ProgramaEducativo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
