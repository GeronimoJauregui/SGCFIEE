#pragma checksum "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/CrearReporte.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4571495f8cf19b0c898f44266b6914fffcbc298"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EstudiantesInformacion_CrearReporte), @"mvc.1.0.view", @"/Views/EstudiantesInformacion/CrearReporte.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EstudiantesInformacion/CrearReporte.cshtml", typeof(AspNetCore.Views_EstudiantesInformacion_CrearReporte))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4571495f8cf19b0c898f44266b6914fffcbc298", @"/Views/EstudiantesInformacion/CrearReporte.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bf9784a52ff93f593cd66162fa38b59d495150e", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesInformacion_CrearReporte : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCFIEE.Models.CompletoAlumnos>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/FIEE.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("150"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("200"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("hspace", new global::Microsoft.AspNetCore.Html.HtmlString("20"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("vspace", new global::Microsoft.AspNetCore.Html.HtmlString("20"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/Users/mac/Desktop/SGCFIEE_ACADEMICOS/SGCFIEE/Views/EstudiantesInformacion/CrearReporte.cshtml"
  
    ViewData["Title"] = "Generar Reporte";
    Layout = "~/Views/Home/Principal.cshtml";
    var y = (IEnumerable<TipoPeriodo>)ViewData["periodo"];
    var z = (IEnumerable<TipoEventos>)ViewData["tipoevento"];
    var cali = (IEnumerable<CalificacionAlumno>)ViewData["calificacion"];
    var evento = (IEnumerable<AlumnoEvento>)ViewData["evento"];
    var movilidad = (IEnumerable<AlumnoMovilidad>)ViewData["movilidad"];
    var pafi = (IEnumerable<AlumnoPafi>)ViewData["pafi"];
    var examen = (IEnumerable<AlumnoExamen>)ViewData["examen"];
    var final = (IEnumerable<AlumnoFinal>)ViewData["Instancias"];


#line default
#line hidden
            BeginContext(653, 148, true);
            WriteLiteral("\n<!DOCTYPE html>\n\n<html>\n<div class=\"content\">\n    <div class=\"card card-topline-gray\" id=\"ReporteUV\">\n        <div class=\"contenedor\">\n            ");
            EndContext();
            BeginContext(801, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b4571495f8cf19b0c898f44266b6914fffcbc2985941", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(885, 3254, true);
            WriteLiteral(@" <br /> <br />
            <div class=""encima""><h3 class=""center"">Facultad de Ingeniería Eléctrica y Eléctronica</h3> </div>
            <div class=""centrado""><h4 class=""center"">Universidad Veracruzana</h4></div>
        </div>
        <div class=""card-head"">
            <div class=""row"">
                <div class=""col-md-12 col-sm-12"">

                    <div class=""row"">
                        <br /> <br />
                        <div class=""col-md-6 col-6 b-r"">
                            <strong>Nombre</strong>
                            <br>
                            <p id=""Nombre"">cosas</p>
                            <br>
                        </div>
                        <div class=""col-md-6 col-6 b-r"">
                            <strong>A. Paterno</strong>
                            <br>
                            <p id=""A_paterno"">cosas</p>
                            <br>
                        </div>
                        <div class=""col-md-6 col-6 b-r"">
                         ");
            WriteLiteral(@"   <strong>A. Materno</strong>
                            <br>
                            <p id=""A_materno"">cosas</p>
                            <br>
                        </div>
                        <div class=""col-md-6 col-6"">
                            <strong>Correo</strong>
                            <br>
                            <p id=""email"">cosas</p>
                            <br>
                        </div>
                        <div class=""col-md-6 col-6"">
                            <strong>Fecha de Nacimiento</strong>
                            <br>
                            <p id=""fecha"">cosas</p>
                            <br>
                        </div>
                        <div class=""col-md-6 col-6"">
                            <strong>Nacionalidad</strong>
                            <br>
                            <p id=""Nacionalidad"">cosas</p>
                        </div>
                        <div class=""col-md-6 col-6"">
                            <str");
            WriteLiteral(@"ong>Estado Civil</strong>
                            <br>
                            <p id=""Estadoc"">cosas</p>
                            <br>
                        </div>
                        <div class=""col-md-6 col-6"">
                            <strong>CURP</strong>
                            <br>
                            <p id=""Curp"">cosas</p>
                            <br>
                        </div>
                        <div class=""col-md-6 col-6"">
                            <strong>Domicilio</strong>
                            <br>
                            <p id=""Domicilio"">cosas</p>
                            <br>
                        </div>
                        <div class=""col-md-6 col-6"">
                            <strong>Teléfono</strong>
                            <br>
                            <p id=""Tel"" class=""text-muted"">cosas</p>
                            <br>
                        </div>
                    </div>
                </div>
            ");
            WriteLiteral("</div>\n        </div>\n    </div>\n\n    <a id=\"tablaPDF\" class=\"btn btn-danger btn-xs eliminar\" title=\"Generar Reporte\">\n        <i class=\"fa fa-trash-o \"></i>\n    </a>\n</div>\n</html>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGCFIEE.Models.CompletoAlumnos> Html { get; private set; }
    }
}
#pragma warning restore 1591
