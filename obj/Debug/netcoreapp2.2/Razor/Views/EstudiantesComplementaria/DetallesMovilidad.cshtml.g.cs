#pragma checksum "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3d4145d1fd2b542428517ab0e02f9f27aca34d53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EstudiantesComplementaria_DetallesMovilidad), @"mvc.1.0.view", @"/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml", typeof(AspNetCore.Views_EstudiantesComplementaria_DetallesMovilidad))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d4145d1fd2b542428517ab0e02f9f27aca34d53", @"/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bf9784a52ff93f593cd66162fa38b59d495150e", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesComplementaria_DetallesMovilidad : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCFIEE.Models.CtMovilidades>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EstudiantesComplementaria", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MostrarMovilidad", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml"
  
    ViewData["Title"] = "Dtalle Movilidad";
    Layout = "~/Views/Home/Principal.cshtml";

#line default
#line hidden
            BeginContext(131, 972, true);
            WriteLiteral(@"
<!DOCTYPE html>

<html>
<div class=""profile-content"">
    <div class=""row"">
        <div class=""col-md-12 col-sm-12"">
            <div class=""card"">
                <div class=""card-topline-green"">
                    <div class=""card-head"" id=""idDatosPersonales"">
                        <header>Información de movilidad</header>
                    </div>
                </div>
                <div class=""tab-content"">
                    <div class=""tab-pane fontawesome-demo active show"" id=""tab1"">
                        <div class=""row"">
                            <div class=""col-md-12 col-sm-12"">
                                
                                <div class=""card-body "" id=""bar-parent2"">
                                    <div class=""row"">
                                        <div class=""col-md-6 col-6 b-r"">
                                            <strong>Tipo de movilidad</strong>
                                            <br>
");
            EndContext();
#line 29 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml"
                                             if (Model.TipoMovilidades == 1)
                                            {

#line default
#line hidden
            BeginContext(1225, 57, true);
            WriteLiteral("  <div><p id=\"\" class=\"text-muted\"> Nacional </p> </div> ");
            EndContext();
#line 30 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml"
                                                                                                      }

#line default
#line hidden
            BeginContext(1284, 44, true);
            WriteLiteral("                                            ");
            EndContext();
#line 31 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml"
                                             if (Model.TipoMovilidades == 2)
                                            {

#line default
#line hidden
            BeginContext(1406, 59, true);
            WriteLiteral(" <div><p id=\"\" class=\"text-muted\"> Internacional</p> </div>");
            EndContext();
#line 32 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml"
                                                                                                        }

#line default
#line hidden
            BeginContext(1467, 409, true);
            WriteLiteral(@"                                            
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6 b-r"">
                                            <strong>Pais destino</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(1877, 52, false);
#line 39 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml"
                                                                   Write(Html.DisplayFor(model => model.PaisDestinoMovilidad));

#line default
#line hidden
            EndContext();
            BeginContext(1929, 372, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6 b-r"">
                                            <strong>Entidad destino</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(2302, 55, false);
#line 45 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml"
                                                                   Write(Html.DisplayFor(model => model.EntidadDestinoMovilidad));

#line default
#line hidden
            EndContext();
            BeginContext(2357, 368, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Escuela destino</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(2726, 55, false);
#line 51 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml"
                                                                   Write(Html.DisplayFor(model => model.EscuelaDestinoMovilidad));

#line default
#line hidden
            EndContext();
            BeginContext(2781, 374, true);
            WriteLiteral(@"</p>
                                            <br>
                                        </div>
                                        <div class=""col-md-6 col-6"">
                                            <strong>Tiempo de permanencia</strong>
                                            <br>
                                            <p id="""" class=""text-muted"">");
            EndContext();
            BeginContext(3156, 58, false);
#line 57 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesComplementaria/DetallesMovilidad.cshtml"
                                                                   Write(Html.DisplayFor(model => model.TiempoPermanenciaMovilidad));

#line default
#line hidden
            EndContext();
            BeginContext(3214, 180, true);
            WriteLiteral("</p>\n                                            <br>\n                                        </div>\n                                    </div>\n                                    ");
            EndContext();
            BeginContext(3394, 212, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3d4145d1fd2b542428517ab0e02f9f27aca34d5310659", async() => {
                BeginContext(3508, 94, true);
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
            BeginContext(3606, 254, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGCFIEE.Models.CtMovilidades> Html { get; private set; }
    }
}
#pragma warning restore 1591
