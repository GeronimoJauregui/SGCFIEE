#pragma checksum "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9259567e555307a1bb0bc8011a967860ef10d8fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AcademicosComplementaria_TablaMatPE), @"mvc.1.0.view", @"/Views/AcademicosComplementaria/TablaMatPE.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AcademicosComplementaria/TablaMatPE.cshtml", typeof(AspNetCore.Views_AcademicosComplementaria_TablaMatPE))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9259567e555307a1bb0bc8011a967860ef10d8fe", @"/Views/AcademicosComplementaria/TablaMatPE.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bf9784a52ff93f593cd66162fa38b59d495150e", @"/Views/_ViewImports.cshtml")]
    public class Views_AcademicosComplementaria_TablaMatPE : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCFIEE.Models.ProgramaEducativo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("tipo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TablaMatPE", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EliminarMC", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-xs eliminar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Eliminar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
  
    Layout = "~/Views/Home/Principal.cshtml";
    var x = (IEnumerable<SGCFIEE.Models.ProgramaEducativo>)ViewData["carreras"];
    var y = (IEnumerable<SGCFIEE.Models.TablaMatPE>)ViewData["mapa"];

#line default
#line hidden
            BeginContext(243, 1138, true);
            WriteLiteral(@"
<!DOCTYPE html>
<html>
<div class=""profile-content"">
    <div class=""row"">
        <div class=""col-md-12 col-sm-12"">
            <div class=""card card-topline-green"">
                <div class=""card-head"">
                    <header>Mapa curricular</header>
                    <div class=""tools"">
                        <a class=""fa fa-repeat btn-color box-refresh"" href=""javascript:;""></a>
                        <a class=""t-collapse btn-color fa fa-chevron-down"" href=""javascript:;""></a>
                        <a class=""t-close btn-color fa fa-times"" href=""javascript:;""></a>
                    </div>
                </div>
                <div class=""white-box"">
                    <!-- Tab panes -->
                    <div class=""tab-content"">
                        <div class=""tab-pane fontawesome-demo active show"" id=""tab1"">
                            <div class=""row"">
                                <div class=""col-md-12 col-sm-12"">

                                    <div class=""card-body "" id=""");
            WriteLiteral("bar-parent2\">\n                                        <!-- text input -->\n                                        ");
            EndContext();
            BeginContext(1381, 1300, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9259567e555307a1bb0bc8011a967860ef10d8fe7515", async() => {
                BeginContext(1434, 202, true);
                WriteLiteral("\n                                            <div class=\"form-group\">\n                                                <div class=\"col-md-3 col-sm-3\">\n                                                    ");
                EndContext();
                BeginContext(1636, 61, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9259567e555307a1bb0bc8011a967860ef10d8fe8100", async() => {
                    BeginContext(1673, 16, true);
                    WriteLiteral("Elija la carrera");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 34 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdProgramaEducativo);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1697, 53, true);
                WriteLiteral("\n                                                    ");
                EndContext();
                BeginContext(1750, 481, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9259567e555307a1bb0bc8011a967860ef10d8fe9904", async() => {
                    BeginContext(1819, 1, true);
                    WriteLiteral("\n");
                    EndContext();
#line 36 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                                         foreach (var item in x)
                                                        {

#line default
#line hidden
                    BeginContext(1959, 60, true);
                    WriteLiteral("                                                            ");
                    EndContext();
                    BeginContext(2019, 92, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9259567e555307a1bb0bc8011a967860ef10d8fe10757", async() => {
                        BeginContext(2062, 40, false);
#line 38 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                                                                                 Write(Html.DisplayFor(itemView => item.Nombre));

#line default
#line hidden
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#line 38 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                                               WriteLiteral(item.IdProgramaEducativo);

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
                    BeginContext(2111, 1, true);
                    WriteLiteral("\n");
                    EndContext();
#line 39 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                                        }

#line default
#line hidden
                    BeginContext(2170, 52, true);
                    WriteLiteral("                                                    ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 35 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdProgramaEducativo);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
                BeginContext(2231, 443, true);
                WriteLiteral(@"
                                                </div>
                                                <br />
                                                <button id=""BuscarMov"" type=""submit"" class=""btn btn-success btn-sm m-b-10"">
                                                    Buscar
                                                </button>
                                            </div>
                                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#line 31 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery = true;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-antiforgery", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2681, 744, true);
            WriteLiteral(@"
                                        <table class=""table table-striped table-bordered table-hover table-checkable order-column"" style=""width: 100%"" id=""example1"">
                                        <thead>
                                            <tr>
                                                <th class=""center"">Nombre de la materia</th>
                                                <th class=""center"">Area</th>
                                                <th class=""center"">creditos</th>
                                                <th class=""center"">Acciones</th>

                                            </tr>
                                        </thead>
                                        <tbody>
");
            EndContext();
#line 59 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                             foreach (var item in y)
                                            {

#line default
#line hidden
            BeginContext(3540, 143, true);
            WriteLiteral("                                                <tr class=\"odd gradeX\">\n                                                    <td class=\"center\">");
            EndContext();
            BeginContext(3684, 41, false);
#line 62 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.nomMat));

#line default
#line hidden
            EndContext();
            BeginContext(3725, 77, true);
            WriteLiteral("</td>\n                                                    <td class=\"center\">");
            EndContext();
            BeginContext(3803, 39, false);
#line 63 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.area));

#line default
#line hidden
            EndContext();
            BeginContext(3842, 77, true);
            WriteLiteral("</td>\n                                                    <td class=\"center\">");
            EndContext();
            BeginContext(3920, 43, false);
#line 64 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.creditos));

#line default
#line hidden
            EndContext();
            BeginContext(3963, 134, true);
            WriteLiteral("</td>\n                                                    <td class=\"center\">\n                                                        ");
            EndContext();
            BeginContext(4097, 263, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9259567e555307a1bb0bc8011a967860ef10d8fe19830", async() => {
                BeginContext(4208, 148, true);
                WriteLiteral("\n                                                            <i class=\"fa fa-trash-o \"></i>\n                                                        ");
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
#line 66 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                                             WriteLiteral(item.idMapa);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4360, 114, true);
            WriteLiteral("\n\n                                                    </td>\n                                                </tr>\n");
            EndContext();
#line 72 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/AcademicosComplementaria/TablaMatPE.cshtml"
                                            }

#line default
#line hidden
            BeginContext(4520, 358, true);
            WriteLiteral(@"
                                        </tbody>
                                        </table>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</html>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGCFIEE.Models.ProgramaEducativo> Html { get; private set; }
    }
}
#pragma warning restore 1591
