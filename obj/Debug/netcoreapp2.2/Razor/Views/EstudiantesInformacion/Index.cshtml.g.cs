#pragma checksum "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d16fc1d8564e519424c0400f2a2a211e2ba9483d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EstudiantesInformacion_Index), @"mvc.1.0.view", @"/Views/EstudiantesInformacion/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EstudiantesInformacion/Index.cshtml", typeof(AspNetCore.Views_EstudiantesInformacion_Index))]
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
#line 1 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/_ViewImports.cshtml"
using SGCFIEE;

#line default
#line hidden
#line 2 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/_ViewImports.cshtml"
using SGCFIEE.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d16fc1d8564e519424c0400f2a2a211e2ba9483d", @"/Views/EstudiantesInformacion/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bf9784a52ff93f593cd66162fa38b59d495150e", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesInformacion_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SGCFIEE.Models.TablaAlumno>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/pages/table/table_data.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EstudiantesInformacion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Crear", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm m-b-10"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detalles", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-xs infoextra"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Toda la información"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Editar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-xs editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Home/Principal.cshtml";

#line default
#line hidden
            BeginContext(131, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(135, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d16fc1d8564e519424c0400f2a2a211e2ba9483d7011", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(196, 789, true);
            WriteLiteral(@"
<!DOCTYPE html>

<html>
<div class=""row"">
    <div id=""Reporte"" class=""col-md-12"">
        <div class=""card card-topline-green"">
            <div class=""card-head"">
                <header>INFORMACIÓN</header>
                <div class=""tools"">
                    <a class=""fa fa-repeat btn-color box-refresh"" href=""javascript:;""></a>
                    <a class=""t-collapse btn-color fa fa-chevron-down"" href=""javascript:;""></a>
                    <a class=""t-close btn-color fa fa-times"" href=""javascript:;""></a>
                </div>
            </div>
            <div class=""card-body "" id=""tablap"">
                <div class=""row p-b-20"">
                    <div class=""col-md-12 col-sm-12 col-12"">
                        <div class=""btn-group"">
                            ");
            EndContext();
            BeginContext(985, 200, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d16fc1d8564e519424c0400f2a2a211e2ba9483d8993", async() => {
                BeginContext(1085, 96, true);
                WriteLiteral("\n                                Agregar <i class=\"fa fa-plus\"></i>\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1185, 868, true);
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <table class=""table table-striped table-bordered table-hover table-checkable order-column"" style=""width: 100%"" id=""example1"">
                    <thead>
                        <tr>
                            <th class=""center""> Nombre    </th>
                            <th class=""center""> A. Paterno </th>
                            <th class=""center""> A. Materno </th>
                            <th class=""center""> Matricula</th>
                            <th class=""center""> Carrera </th>
                            <th style=""display: none""></th>
                            <th style=""display: none""></th>
                            <th class=""center"">Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
");
            EndContext();
#line 45 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                         foreach (var item in Model)
                        {


#line default
#line hidden
            BeginContext(2133, 103, true);
            WriteLiteral("                            <tr class=\"odd gradeX\">\n                                <td class=\"center\">");
            EndContext();
            BeginContext(2237, 41, false);
#line 49 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(2278, 57, true);
            WriteLiteral("</td>\n                                <td class=\"center\">");
            EndContext();
            BeginContext(2336, 50, false);
#line 50 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.ApellidoPaterno));

#line default
#line hidden
            EndContext();
            BeginContext(2386, 57, true);
            WriteLiteral("</td>\n                                <td class=\"center\">");
            EndContext();
            BeginContext(2444, 50, false);
#line 51 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.ApellidoMaterno));

#line default
#line hidden
            EndContext();
            BeginContext(2494, 57, true);
            WriteLiteral("</td>\n                                <td class=\"center\">");
            EndContext();
            BeginContext(2552, 44, false);
#line 52 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.Matricula));

#line default
#line hidden
            EndContext();
            BeginContext(2596, 57, true);
            WriteLiteral("</td>\n                                <td class=\"center\">");
            EndContext();
            BeginContext(2654, 44, false);
#line 53 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.NombrePro));

#line default
#line hidden
            EndContext();
            BeginContext(2698, 229, true);
            WriteLiteral("</td>\n                                <td style=\"display: none\">iddpersonales</td>\n                                <td style=\"display: none\">idalumno</td>\n\n                                <td>\n                                    ");
            EndContext();
            BeginContext(2927, 267, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d16fc1d8564e519424c0400f2a2a211e2ba9483d14481", async() => {
                BeginContext(3085, 105, true);
                WriteLiteral("\n                                        <i class=\"fa fa-check\"></i>\n                                    ");
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
#line 58 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                                         WriteLiteral(item.id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
            BeginContext(3194, 37, true);
            WriteLiteral("\n                                    ");
            EndContext();
            BeginContext(3231, 250, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d16fc1d8564e519424c0400f2a2a211e2ba9483d17294", async() => {
                BeginContext(3371, 106, true);
                WriteLiteral("\n                                        <i class=\"fa fa-pencil\"></i>\n                                    ");
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
#line 61 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                                         WriteLiteral(item.id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
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
            BeginContext(3481, 52, true);
            WriteLiteral("\n                                    <a data-value=\"");
            EndContext();
            BeginContext(3534, 7, false);
#line 64 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                                              Write(item.id);

#line default
#line hidden
            EndContext();
            BeginContext(3541, 497, true);
            WriteLiteral(@""" data-controlador=""EstudiantesInformacion"" data-accion=""Eliminar"" name=""laeliminacion"" class=""btn btn-danger btn-xs eliminar"" title=""Eliminar"">
                                        <i class=""fa fa-trash-o ""></i>
                                    </a>
                                    <a data-controlador=""EstudiantesInformacion"" data-accion=""Index"" hidden name=""actualizar"">
                                    </a>
                                </td>
                            </tr>
");
            EndContext();
#line 71 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(4064, 114, true);
            WriteLiteral("                    </tbody>\n                </table>\n            </div>\n        </div>\n    </div>\n</div>\n</html>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SGCFIEE.Models.TablaAlumno>> Html { get; private set; }
    }
}
#pragma warning restore 1591
