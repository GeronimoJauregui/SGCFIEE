#pragma checksum "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6ab2c0518182927df50f63af1e88e5e8eaa5912"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6ab2c0518182927df50f63af1e88e5e8eaa5912", @"/Views/EstudiantesComplementaria/DetallesPrograma.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bf9784a52ff93f593cd66162fa38b59d495150e", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesComplementaria_DetallesPrograma : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCFIEE.Models.ProgramaEducativo>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EstudiantesComplementaria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MostrarProgramas", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm m-b-10"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(136, 1082, true);
            WriteLiteral(@"
<!DOCTYPE html>

<html>
<div class=""profile-content"">
    <div class=""row"">
        <div class=""col-md-12 col-sm-12"">
            <div class=""card"">
                <div class=""card-topline-green"">
                    <div class=""card-head"" id=""idDatosPersonales"">
                        <header>Información del programa</header>
                    </div>
                </div>

                <!-- Tab panes -->
                <div class=""tab-content"">
                    <div class=""tab-pane fontawesome-demo active show"" id=""tab1"">
                        <div class=""row"">
                            <div class=""col-md-12 col-sm-12"">
                                
                                <div class=""card-body "" id=""bar-parent2"">
                                    <div class=""row"">
                                        <div class=""col-md-6 col-6 b-r"">
                                            <strong>Nombre del programa</strong>
                                            <br>
              ");
            WriteLiteral("                              <p id=\"\" class=\"text-muted\">");
            EndContext();
            BeginContext(1219, 38, false);
#line 31 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1257, 365, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6 b-r"">
                                            <strong>Creditos</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(1623, 40, false);
#line 37 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Creditos));

#line default
#line hidden
            EndContext();
            BeginContext(1663, 375, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6 b-r"">
                                            <strong>Clave del programa</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(2039, 43, false);
#line 43 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.ClvPrograma));

#line default
#line hidden
            EndContext();
            BeginContext(2082, 361, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Facultad</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(2444, 40, false);
#line 49 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Facultad));

#line default
#line hidden
            EndContext();
            BeginContext(2484, 359, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Campus</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(2844, 38, false);
#line 55 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Campus));

#line default
#line hidden
            EndContext();
            BeginContext(2882, 358, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Nivel</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(3241, 37, false);
#line 61 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Nivel));

#line default
#line hidden
            EndContext();
            BeginContext(3278, 328, true);
            WriteLiteral(@"</p>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Creditos min por periodo</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(3607, 45, false);
#line 66 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.CreditosMinXp));

#line default
#line hidden
            EndContext();
            BeginContext(3652, 377, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Creditos max por periodo</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(4030, 45, false);
#line 72 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.CreditosMaxXp));

#line default
#line hidden
            EndContext();
            BeginContext(4075, 357, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Área</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(4433, 36, false);
#line 78 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesPrograma.cshtml"
                                                                   Write(Html.DisplayFor(model => model.Area));

#line default
#line hidden
            EndContext();
            BeginContext(4469, 180, true);
            WriteLiteral("</p>\n                                            <br>\n                                        </div>\n                                    </div>\n                                    ");
            EndContext();
            BeginContext(4649, 212, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a6ab2c0518182927df50f63af1e88e5e8eaa591212664", async() => {
                BeginContext(4763, 94, true);
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
            BeginContext(4861, 254, true);
            WriteLiteral("\n                                    \n                                </div>\n\n                            </div>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n</html>\n");
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
