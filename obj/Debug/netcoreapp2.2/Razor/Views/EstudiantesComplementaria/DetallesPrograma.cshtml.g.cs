#pragma checksum "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b39e705ad0d4a46c67fdfabef62bb4dae740afc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EstudiantesComplementaria_DetallesPrograma), @"mvc.1.0.view", @"/Views/EstudiantesComplementaria/DetallesPrograma.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EstudiantesComplementaria/DetallesPrograma.cshtml", typeof(AspNetCore.Views_EstudiantesComplementaria_DetallesPrograma))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b39e705ad0d4a46c67fdfabef62bb4dae740afc", @"/Views/EstudiantesComplementaria/DetallesPrograma.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bf9784a52ff93f593cd66162fa38b59d495150e", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesComplementaria_DetallesPrograma : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCFIEE.Models.ProgramaEducativo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EstudiantesComplementaria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MostrarProgramas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm m-b-10"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
  
    ViewData["Title"] = "Detalles Programa";
    Layout = "~/Views/Home/Principal.cshtml";

#line default
#line hidden
            BeginContext(136, 1182, true);
            WriteLiteral(@"
<!DOCTYPE html>

<html>
<div class=""profile-content"">
    <div class=""row"">
        <div class=""col-md-12 col-sm-12"">
            <div class=""card"">
                <div class=""card-topline-green""></div>

                <div class=""p-rl-20"">
                    <ul class=""nav customtab nav-tabs"" role=""tablist"">
                        <li id=""tb1"" class=""nav-item""><a href=""#tab1"" class=""nav-link active show"" data-toggle=""tab"">Información del programa</a></li>
                    </ul>
                </div>
                <!-- Tab panes -->
                <div class=""tab-content"">
                    <div class=""tab-pane fontawesome-demo active show"" id=""tab1"">
                        <div class=""row"">
                            <div class=""col-md-12 col-sm-12"">

                                <div class=""card-body "" id=""bar-parent2"">
                                    <div class=""row"">
                                        <div class=""col-md-6 col-6 b-r"">
                                            ");
            WriteLiteral("<strong>Nombre del programa</strong>\n                                            <br>\n                                            <p id=\"\" class=\"text-muted\">");
            EndContext();
            BeginContext(1319, 38, false);
#line 32 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1357, 365, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6 b-r"">
                                            <strong>Creditos</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(1723, 40, false);
#line 38 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Creditos));

#line default
#line hidden
            EndContext();
            BeginContext(1763, 375, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6 b-r"">
                                            <strong>Clave del programa</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(2139, 43, false);
#line 44 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.ClvPrograma));

#line default
#line hidden
            EndContext();
            BeginContext(2182, 361, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Facultad</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(2544, 40, false);
#line 50 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Facultad));

#line default
#line hidden
            EndContext();
            BeginContext(2584, 359, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Campus</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(2944, 38, false);
#line 56 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Campus));

#line default
#line hidden
            EndContext();
            BeginContext(2982, 358, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Nivel</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(3341, 37, false);
#line 62 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Nivel));

#line default
#line hidden
            EndContext();
            BeginContext(3378, 328, true);
            WriteLiteral(@"</p>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Creditos min por periodo</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(3707, 45, false);
#line 67 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.CreditosMinXp));

#line default
#line hidden
            EndContext();
            BeginContext(3752, 377, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Creditos max por periodo</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(4130, 45, false);
#line 73 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.CreditosMaxXp));

#line default
#line hidden
            EndContext();
            BeginContext(4175, 357, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Área</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(4533, 36, false);
#line 79 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Area));

#line default
#line hidden
            EndContext();
            BeginContext(4569, 180, true);
            WriteLiteral("</p>\n                                            <br>\n                                        </div>\n                                    </div>\n                                    ");
            EndContext();
            BeginContext(4749, 212, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b39e705ad0d4a46c67fdfabef62bb4dae740afc13077", async() => {
                BeginContext(4863, 94, true);
                WriteLiteral("\n                                        Regresar a tabla\n                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4961, 37, true);
            WriteLiteral("\n                                    ");
            EndContext();
            BeginContext(4998, 205, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b39e705ad0d4a46c67fdfabef62bb4dae740afc14841", async() => {
                BeginContext(5101, 98, true);
                WriteLiteral("\n                                        Regresar a principal\n                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5203, 217, true);
            WriteLiteral("\n                                </div>\n\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n</html>\n");
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
