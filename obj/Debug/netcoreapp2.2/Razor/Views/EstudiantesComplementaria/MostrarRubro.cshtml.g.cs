#pragma checksum "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\EstudiantesComplementaria\MostrarRubro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5dbe59ac44698da5dd9604ff02e3e151edf60181"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EstudiantesComplementaria_MostrarRubro), @"mvc.1.0.view", @"/Views/EstudiantesComplementaria/MostrarRubro.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EstudiantesComplementaria/MostrarRubro.cshtml", typeof(AspNetCore.Views_EstudiantesComplementaria_MostrarRubro))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5dbe59ac44698da5dd9604ff02e3e151edf60181", @"/Views/EstudiantesComplementaria/MostrarRubro.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225633a62ddc17bf9f6645008885b94288a8c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesComplementaria_MostrarRubro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SGCFIEE.Models.TbRubrosexamenes>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EstudiantesComplementaria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditarRubro", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-xs editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Editar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EliminarRubro", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-xs eliminar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Eliminar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\EstudiantesComplementaria\MostrarRubro.cshtml"
  
    ViewData["Title"] = "Mostrar Rubros";
    Layout = "~/Views/Home/Principal.cshtml";

#line default
#line hidden
            BeginContext(150, 1194, true);
            WriteLiteral(@"
<!DOCTYPE html>

<html>
<div class=""row"">
    <div class=""col-md-12"">
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
                <table class=""table table-striped table-bordered table-hover table-checkable order-column"" style=""width: 100%"" id=""tbcomp"">
                    <thead>
                        <tr>
                            <th style=""display: none""></th>
                            <th class=""center"" style=""width: 100px""> Estado del rubro </th>
                            <th class=""center"" style=""width: 700");
            WriteLiteral("px;\"> Nombre </th>\r\n                            <th class=\"center\">Accion</th>\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
            EndContext();
#line 32 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\EstudiantesComplementaria\MostrarRubro.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
            BeginContext(1425, 111, true);
            WriteLiteral("                            <tr class=\"odd gradeX\">\r\n                                <td style=\"display: none\">");
            EndContext();
            BeginContext(1537, 53, false);
#line 35 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\EstudiantesComplementaria\MostrarRubro.cshtml"
                                                     Write(Html.DisplayFor(modelItem => item.IdTbRubrosExamenes));

#line default
#line hidden
            EndContext();
            BeginContext(1590, 122, true);
            WriteLiteral("</td>\r\n                                <td class=\"center\">Activo</td>\r\n                                <td class=\"center\">");
            EndContext();
            BeginContext(1713, 46, false);
#line 37 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\EstudiantesComplementaria\MostrarRubro.cshtml"
                                              Write(Html.DisplayFor(modelItem => item.RubroExamen));

#line default
#line hidden
            EndContext();
            BeginContext(1759, 143, true);
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <div class=\"center\">\r\n                                        ");
            EndContext();
            BeginContext(1902, 284, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dbe59ac44698da5dd9604ff02e3e151edf601818760", async() => {
                BeginContext(2066, 116, true);
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
#line 40 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\EstudiantesComplementaria\MostrarRubro.cshtml"
                                             WriteLiteral(item.IdTbRubrosExamenes);

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
            BeginContext(2186, 42, true);
            WriteLiteral("\r\n                                        ");
            EndContext();
            BeginContext(2228, 319, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5dbe59ac44698da5dd9604ff02e3e151edf6018111651", async() => {
                BeginContext(2425, 118, true);
                WriteLiteral("\r\n                                            <i class=\"fa fa-trash-o \"></i>\r\n                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#line 43 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\EstudiantesComplementaria\MostrarRubro.cshtml"
                                               Write(item.RubroExamen);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-id", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 43 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\EstudiantesComplementaria\MostrarRubro.cshtml"
                                                                         WriteLiteral(item.IdTbRubrosExamenes);

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
            BeginContext(2547, 120, true);
            WriteLiteral("\r\n                                    </div>\r\n                                </td>\r\n                            </tr>\r\n");
            EndContext();
#line 49 "C:\Users\dxvm1\Desktop\nuevo\SGCFIEE\Views\EstudiantesComplementaria\MostrarRubro.cshtml"
                        }

#line default
#line hidden
            BeginContext(2694, 121, true);
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
