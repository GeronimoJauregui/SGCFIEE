#pragma checksum "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5778821207b269b2b783fabe2568f4a560927258"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AcademicosComplementaria_MostrarRubro), @"mvc.1.0.view", @"/Views/AcademicosComplementaria/MostrarRubro.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AcademicosComplementaria/MostrarRubro.cshtml", typeof(AspNetCore.Views_AcademicosComplementaria_MostrarRubro))]
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
#line 1 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\_ViewImports.cshtml"
using SGCFIEE;

#line default
#line hidden
#line 2 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\_ViewImports.cshtml"
using SGCFIEE.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5778821207b269b2b783fabe2568f4a560927258", @"/Views/AcademicosComplementaria/MostrarRubro.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225633a62ddc17bf9f6645008885b94288a8c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_AcademicosComplementaria_MostrarRubro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SGCFIEE.Models.TbRubrosexamenes>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/plugins/sweet-alert/sweetalert.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/plugins/sweet-alert/sweetalert.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/pages/sweet-alert/sweet-alert-data.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CrearRubro", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AcademicosComplementaria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm m-b-10"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "VistaOpcionesCatalogos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default btn-sm m-b-10"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditarRubro", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-xs editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
  
    ViewData["Title"] = "Mostrar Rubros";
    Layout = "~/Views/Home/Principal.cshtml";

#line default
#line hidden
            BeginContext(150, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "5778821207b269b2b783fabe2568f4a5609272587863", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(228, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(230, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5778821207b269b2b783fabe2568f4a5609272589116", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(300, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(302, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5778821207b269b2b783fabe2568f4a56092725810293", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(375, 48, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n<div class=\"row\">\r\n");
            EndContext();
#line 13 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
     if (TempData["msg"] != null)
    {
        

#line default
#line hidden
            BeginContext(474, 25, false);
#line 15 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
   Write(Html.Raw(TempData["msg"]));

#line default
#line hidden
            EndContext();
#line 15 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                  
    }

#line default
#line hidden
            BeginContext(508, 736, true);
            WriteLiteral(@"    <div class=""col-md-12"">
        <div class=""card card-topline-green"">
            <div class=""card-head"">
                <header>RUBROS EXAMENES</header>
                <div class=""tools"">
                    <a class=""fa fa-repeat btn-color box-refresh"" href=""javascript:;""></a>
                    <a class=""t-collapse btn-color fa fa-chevron-down"" href=""javascript:;""></a>
                    <a class=""t-close btn-color fa fa-times"" href=""javascript:;""></a>
                </div>
            </div>
            <div class=""card-body "">
                <div class=""row p-b-20"">
                    <div class=""col-md-6 col-sm-6 col-6"">
                        <div class=""btn-group"">
                            ");
            EndContext();
            BeginContext(1244, 184, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5778821207b269b2b783fabe2568f4a56092725813019", async() => {
                BeginContext(1352, 72, true);
                WriteLiteral("\r\n                                INSERTAR\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1428, 58, true);
            WriteLiteral("\r\n                        </div>\r\n                        ");
            EndContext();
            BeginContext(1486, 185, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5778821207b269b2b783fabe2568f4a56092725814812", async() => {
                BeginContext(1605, 62, true);
                WriteLiteral("\r\n                            VOLVER\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1671, 733, true);
            WriteLiteral(@"
                    </div>
                </div>
                <table class=""table table-striped table-bordered table-hover table-checkable order-column"" style=""width: 100%"" id=""tbcomp"">
                    <thead>
                        <tr>
                            <th style=""display: none""></th>
                            <th class=""center"" style=""width: 100px""> Estado del rubro </th>
                            <th class=""center"" style=""width: 100px""> Tipo de examen </th>
                            <th class=""center"" style=""width: 700px;""> Nombre </th>
                            <th class=""center"">Accion</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 51 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(2485, 111, true);
            WriteLiteral("                            <tr class=\"odd gradeX\">\r\n                                <td style=\"display: none\">");
            EndContext();
            BeginContext(2597, 53, false);
#line 54 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                                     Write(Html.DisplayFor(modelItem => item.IdTbRubrosExamenes));

#line default
#line hidden
            EndContext();
            BeginContext(2650, 60, true);
            WriteLiteral("</td>\r\n                                <td class=\"center\">\r\n");
            EndContext();
#line 56 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                     if (item.Status == 1)
                                    {

#line default
#line hidden
            BeginContext(2807, 20, true);
            WriteLiteral(" <div>Activo</div>  ");
            EndContext();
#line 57 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                                         }

#line default
#line hidden
            BeginContext(2830, 36, true);
            WriteLiteral("                                    ");
            EndContext();
#line 58 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                     if (item.Status == 0)
                                    {

#line default
#line hidden
            BeginContext(2927, 19, true);
            WriteLiteral("<div>Inactivo</div>");
            EndContext();
#line 59 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                                        }

#line default
#line hidden
            BeginContext(2949, 92, true);
            WriteLiteral("                                </td>\r\n                                <td class=\"center\">\r\n");
            EndContext();
#line 62 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                     if (item.TipoExamen == 1)
                                    {

#line default
#line hidden
            BeginContext(3142, 28, true);
            WriteLiteral(" <div>Examen ingreso</div>  ");
            EndContext();
#line 63 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                                                 }

#line default
#line hidden
            BeginContext(3173, 36, true);
            WriteLiteral("                                    ");
            EndContext();
#line 64 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                     if (item.TipoExamen == 0)
                                    {

#line default
#line hidden
            BeginContext(3274, 25, true);
            WriteLiteral("<div>Examen interno</div>");
            EndContext();
#line 65 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                                              }

#line default
#line hidden
            BeginContext(3302, 90, true);
            WriteLiteral("                                </td>\r\n                                <td class=\"center\">");
            EndContext();
            BeginContext(3393, 46, false);
#line 67 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.RubroExamen));

#line default
#line hidden
            EndContext();
            BeginContext(3439, 143, true);
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <div class=\"center\">\r\n                                        ");
            EndContext();
            BeginContext(3582, 283, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5778821207b269b2b783fabe2568f4a56092725821730", async() => {
                BeginContext(3745, 116, true);
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
#line 70 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                             WriteLiteral(item.IdTbRubrosExamenes);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3865, 57, true);
            WriteLiteral("\r\n                                        <a data-value=\"");
            EndContext();
            BeginContext(3923, 23, false);
#line 73 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                                                  Write(item.IdTbRubrosExamenes);

#line default
#line hidden
            EndContext();
            BeginContext(3946, 420, true);
            WriteLiteral(@""" data-controlador=""AcademicosComplementaria"" data-accion=""EliminarRubro"" data-regreso=""MostrarRubro"" name=""eliminardato"" class=""btn btn-danger btn-xs eliminar"" title=""Eliminar"">
                                            <i class=""fa fa-trash-o ""></i>
                                        </a>
                                    </div>
                                </td>
                            </tr>
");
            EndContext();
#line 79 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosComplementaria\MostrarRubro.cshtml"
                        }

#line default
#line hidden
            BeginContext(4393, 121, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SGCFIEE.Models.TbRubrosexamenes>> Html { get; private set; }
    }
}
#pragma warning restore 1591
