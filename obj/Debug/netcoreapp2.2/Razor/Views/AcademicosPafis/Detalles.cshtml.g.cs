#pragma checksum "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b2d1bd7650789595a8e688276507183011276ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AcademicosPafis_Detalles), @"mvc.1.0.view", @"/Views/AcademicosPafis/Detalles.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AcademicosPafis/Detalles.cshtml", typeof(AspNetCore.Views_AcademicosPafis_Detalles))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b2d1bd7650789595a8e688276507183011276ae", @"/Views/AcademicosPafis/Detalles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225633a62ddc17bf9f6645008885b94288a8c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_AcademicosPafis_Detalles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCFIEE.Models.pPafisAcademicos>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-xs"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AcademicosPafis", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Descargar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
  
    ViewData["Title"] = "Detalles";
    Layout = "~/Views/Home/Principal.cshtml";

#line default
#line hidden
            BeginContext(132, 844, true);
            WriteLiteral(@"
<!DOCTYPE html>
<html lang=""en"">

<div class=""row"">
    <div class=""col-md-12"">
        <div class=""card card-topline-green"">
            <div class=""card-head"">
                <header>DATOS DEL PAFIs</header>
                <div class=""tools"">
                    <a class=""fa fa-repeat btn-color box-refresh"" href=""javascript:;""></a>
                    <a class=""t-collapse btn-color fa fa-chevron-down"" href=""javascript:;""></a>
                    <a class=""t-close btn-color fa fa-times"" href=""javascript:;""></a>
                </div>
            </div>
            <div class=""card-body "">
                <div class=""row"">
                    <div class=""col-md-4 col-6 b-r"">
                        <strong>Nombre del académico</strong>
                        <br>
                        <p class=""text-muted"">");
            EndContext();
            BeginContext(977, 22, false);
#line 26 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                         Write(Model.Nombre_academico);

#line default
#line hidden
            EndContext();
            BeginContext(999, 223, true);
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"col-md-4 col-6 b-r\">\r\n                        <strong>Nombre del PAFIs</strong>\r\n                        <br>\r\n                        <p class=\"text-muted\">");
            EndContext();
            BeginContext(1223, 17, false);
#line 31 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                         Write(Model.Nombre_pafi);

#line default
#line hidden
            EndContext();
            BeginContext(1240, 214, true);
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"col-md-4 col-6 b-r\">\r\n                        <strong>Horario</strong>\r\n                        <br>\r\n                        <p class=\"text-muted\">");
            EndContext();
            BeginContext(1455, 13, false);
#line 36 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                         Write(Model.Horario);

#line default
#line hidden
            EndContext();
            BeginContext(1468, 299, true);
            WriteLiteral(@"</p>
                    </div>
                </div>
                <br>
                <div class=""row"">
                    <div class=""col-md-4 col-6"">
                        <strong>Número de horas</strong>
                        <br>
                        <p class=""text-muted"">");
            EndContext();
            BeginContext(1768, 14, false);
#line 44 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                         Write(Model.NumHoras);

#line default
#line hidden
            EndContext();
            BeginContext(1782, 165, true);
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"col-md-4 col-6 b-r\">\r\n                        <strong>Tipo</strong>\r\n                        <br>\r\n");
            EndContext();
#line 49 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                         if (Model.Tipopafi == 0)
                        {

#line default
#line hidden
            BeginContext(2025, 67, true);
            WriteLiteral("                            <p class=\"text-muted\">Nivelatorio</p>\r\n");
            EndContext();
#line 52 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                        }

#line default
#line hidden
            BeginContext(2119, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 53 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                         if (Model.Tipopafi == 1)
                        {

#line default
#line hidden
            BeginContext(2197, 64, true);
            WriteLiteral("                            <p class=\"text-muted\">Remedial</p>\r\n");
            EndContext();
#line 56 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                        }

#line default
#line hidden
            BeginContext(2288, 161, true);
            WriteLiteral("                    </div>\r\n                    <div class=\"col-md-4 col-6 b-r\">\r\n                        <strong>Estado</strong>\r\n                        <br>\r\n");
            EndContext();
#line 61 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                         if (Model.Estado == 0)
                        {

#line default
#line hidden
            BeginContext(2525, 65, true);
            WriteLiteral("                            <p class=\"text-muted\">Solicitud</p>\r\n");
            EndContext();
#line 64 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                        }

#line default
#line hidden
            BeginContext(2617, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 65 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                         if (Model.Estado == 1)
                        {

#line default
#line hidden
            BeginContext(2693, 66, true);
            WriteLiteral("                            <p class=\"text-muted\">Constancia</p>\r\n");
            EndContext();
#line 68 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                        }

#line default
#line hidden
            BeginContext(2786, 243, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n                <br>\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-4 col-6 b-r\">\r\n                        <strong>Proceso</strong>\r\n                        <br>\r\n");
            EndContext();
#line 76 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                         if (Model.Solicitud == 0)
                        {

#line default
#line hidden
            BeginContext(3108, 83, true);
            WriteLiteral("                            <p class=\"text-muted\">Alumno solicito por escrito</p>\r\n");
            EndContext();
#line 79 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                        }

#line default
#line hidden
            BeginContext(3218, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 80 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                         if (Model.Solicitud == 1)
                        {

#line default
#line hidden
            BeginContext(3297, 86, true);
            WriteLiteral("                            <p class=\"text-muted\">Académico solicito por escrito</p>\r\n");
            EndContext();
#line 83 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                        }

#line default
#line hidden
            BeginContext(3410, 208, true);
            WriteLiteral("                    </div>\r\n                    <div class=\"col-md-4 col-6 b-r\">\r\n                        <strong>Periodo</strong>\r\n                        <br>\r\n                        <p class=\"text-muted\">");
            EndContext();
            BeginContext(3619, 13, false);
#line 88 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                         Write(Model.Periodo);

#line default
#line hidden
            EndContext();
            BeginContext(3632, 212, true);
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"col-md-4 col-6 b-r\">\r\n                        <strong>Salon</strong>\r\n                        <br>\r\n                        <p class=\"text-muted\">");
            EndContext();
            BeginContext(3845, 11, false);
#line 93 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                         Write(Model.Salon);

#line default
#line hidden
            EndContext();
            BeginContext(3856, 333, true);
            WriteLiteral(@"</p>
                    </div>
                </div>
                <br>
                <br>
                <div class=""row"">
                    <div class=""col-md-4 col-6 b-r"">
                        <strong>Programa al que impacta</strong>
                        <br>
                        <p class=""text-muted"">");
            EndContext();
            BeginContext(4190, 8, false);
#line 102 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                         Write(Model.PE);

#line default
#line hidden
            EndContext();
            BeginContext(4198, 228, true);
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"col-md-4 col-6\">\r\n                        <strong>Número de consejo tecnico</strong>\r\n                        <br>\r\n                        <p class=\"text-muted\">");
            EndContext();
            BeginContext(4427, 14, false);
#line 107 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                         Write(Model.NumeroCt);

#line default
#line hidden
            EndContext();
            BeginContext(4441, 198, true);
            WriteLiteral("</p>\r\n                    </div>\r\n                    <div class=\"col-md-4 col-6 b-r\">\r\n                        <strong>Archivo PAFIs</strong>\r\n                        <br>\r\n                        ");
            EndContext();
            BeginContext(4639, 221, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b2d1bd7650789595a8e688276507183011276ae14546", async() => {
                BeginContext(4770, 86, true);
                WriteLiteral("\r\n                            <i class=\"fa fa-download\"></i>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-filename", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 112 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                                                  WriteLiteral(Model.ArchivoPafi);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["filename"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-filename", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["filename"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4860, 296, true);
            WriteLiteral(@"
                    </div>
                </div>
                <br>
                <div class=""row"">
                    <div class=""col-md-4 col-6 b-r"">
                        <strong>Acta de academia donde se autorizó</strong>
                        <br>
                        ");
            EndContext();
            BeginContext(5156, 221, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b2d1bd7650789595a8e688276507183011276ae17608", async() => {
                BeginContext(5287, 86, true);
                WriteLiteral("\r\n                            <i class=\"fa fa-download\"></i>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-filename", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 122 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\AcademicosPafis\Detalles.cshtml"
                                                                  WriteLiteral(Model.ArchivoActaA);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["filename"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-filename", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["filename"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5377, 141, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <br>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGCFIEE.Models.pPafisAcademicos> Html { get; private set; }
    }
}
#pragma warning restore 1591
