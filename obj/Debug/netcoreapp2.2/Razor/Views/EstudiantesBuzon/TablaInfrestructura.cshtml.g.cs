#pragma checksum "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5bd4db3003cd01af0fc1d01033fd6bf8f72bdd7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EstudiantesBuzon_TablaInfrestructura), @"mvc.1.0.view", @"/Views/EstudiantesBuzon/TablaInfrestructura.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EstudiantesBuzon/TablaInfrestructura.cshtml", typeof(AspNetCore.Views_EstudiantesBuzon_TablaInfrestructura))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5bd4db3003cd01af0fc1d01033fd6bf8f72bdd7", @"/Views/EstudiantesBuzon/TablaInfrestructura.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225633a62ddc17bf9f6645008885b94288a8c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesBuzon_TablaInfrestructura : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCFIEE.Models.CtMovilidades>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("tipo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CargarTabla", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Home/Principal.cshtml";
    var modelo = (IEnumerable<TablaSugerenciasBuzon>)ViewData["lista"];

#line default
#line hidden
            BeginContext(199, 1256, true);
            WriteLiteral(@"<!DOCTYPE html>
<html>
<div class=""profile-content"">
    <div class=""row"">
        <div class=""col-md-12 col-sm-12"">
            <div class=""card"">
                <div class=""card-topline-green"">
                    <div class=""card-head"">
                        <header>Sugerencias de infrestructura</header>
                        <div class=""tools"">
                            <a class=""fa fa-repeat btn-color box-refresh"" href=""javascript:;""></a>
                            <a class=""t-collapse btn-color fa fa-chevron-down"" href=""javascript:;""></a>
                            <a class=""t-close btn-color fa fa-times"" href=""javascript:;""></a>
                        </div>
                    </div>

                </div>
                <!-- Tab panes -->
                <div class=""tab-content"">
                    <div class=""tab-pane fontawesome-demo active show"" id=""tab1"">
                        <div class=""row"">
                            <div class=""col-md-12"">
              ");
            WriteLiteral("                  <div class=\"card-body \">\r\n                                    <div class=\"row p-b-20\">\r\n                                        <div class=\"col-md-12 col-sm-12 col-12\">\r\n                                            ");
            EndContext();
            BeginContext(1455, 1435, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5bd4db3003cd01af0fc1d01033fd6bf8f72bdd77391", async() => {
                BeginContext(1509, 217, true);
                WriteLiteral("\r\n                                                <div class=\"form-group\">\r\n                                                    <div class=\"col-md-4 col-sm-4\">\r\n                                                        ");
                EndContext();
                BeginContext(1726, 84, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5bd4db3003cd01af0fc1d01033fd6bf8f72bdd77999", async() => {
                    BeginContext(1759, 43, true);
                    WriteLiteral("Elija el tipo de sugerencias que desee ver:");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 35 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TipoMovilidades);

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
                BeginContext(1810, 58, true);
                WriteLiteral("\r\n                                                        ");
                EndContext();
                BeginContext(1868, 467, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5bd4db3003cd01af0fc1d01033fd6bf8f72bdd79859", async() => {
                    BeginContext(1933, 62, true);
                    WriteLiteral("\r\n                                                            ");
                    EndContext();
                    BeginContext(1995, 41, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5bd4db3003cd01af0fc1d01033fd6bf8f72bdd710325", async() => {
                        BeginContext(2013, 14, true);
                        WriteLiteral("Seleccionar...");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2036, 62, true);
                    WriteLiteral("\r\n                                                            ");
                    EndContext();
                    BeginContext(2098, 56, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5bd4db3003cd01af0fc1d01033fd6bf8f72bdd711948", async() => {
                        BeginContext(2116, 29, true);
                        WriteLiteral("Sugerencias en infrestructura");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_1.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2154, 62, true);
                    WriteLiteral("\r\n                                                            ");
                    EndContext();
                    BeginContext(2216, 52, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a5bd4db3003cd01af0fc1d01033fd6bf8f72bdd713586", async() => {
                        BeginContext(2234, 25, true);
                        WriteLiteral("Sugerencias en académicos");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(2268, 58, true);
                    WriteLiteral("\r\n                                                        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 36 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TipoMovilidades);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
                BeginContext(2335, 548, true);
                WriteLiteral(@"
                                                        <br />
                                                        <button id=""BuscarMov"" type=""submit"" class=""btn btn-success btn-sm m-b-10"">
                                                            Buscar
                                                        </button>
                                                    </div>
                                                    
                                                </div>
                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
#line 32 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
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
            BeginContext(2890, 1179, true);
            WriteLiteral(@"
                                            <br />
                                        </div>
                                    </div>
                                    <div class=""table-scrollable"">
                                        <table class=""table table-striped table-bordered table-hover table-checkable order-column"" style=""width: 100%"" id=""example1"">
                                            <thead>
                                                <tr>
                                                    <th hidden></th>
                                                    <th class=""center""> Nombre del problema</th>
                                                    <th class=""center""> Nombre del alumno</th>
                                                    <th class=""center""> Periodo</th>
                                                    <th class=""center""> Propuesta</th>
                                                    <th class=""center""> Sugerencia</th>

       ");
            WriteLiteral("                                         </tr>\r\n                                            </thead>\r\n                                            <tbody>\r\n");
            EndContext();
#line 66 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
                                                 foreach (var item in modelo)
                                                {
                                                    var name = item.nombreAlu + " " + item.apeAluP + " " + item.apeAluM;

#line default
#line hidden
            BeginContext(4321, 214, true);
            WriteLiteral("                                                <tr class=\"odd gradeX\">\r\n                                                    <td hidden></td>\r\n                                                    <td class=\"center\">");
            EndContext();
            BeginContext(4536, 44, false);
#line 71 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.nombrePro));

#line default
#line hidden
            EndContext();
            BeginContext(4580, 78, true);
            WriteLiteral("</td>\r\n                                                    <td class=\"center\">");
            EndContext();
            BeginContext(4659, 34, false);
#line 72 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => name));

#line default
#line hidden
            EndContext();
            BeginContext(4693, 78, true);
            WriteLiteral("</td>\r\n                                                    <td class=\"center\">");
            EndContext();
            BeginContext(4772, 42, false);
#line 73 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.nomPeri));

#line default
#line hidden
            EndContext();
            BeginContext(4814, 78, true);
            WriteLiteral("</td>\r\n                                                    <td class=\"center\">");
            EndContext();
            BeginContext(4893, 44, false);
#line 74 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.propuesta));

#line default
#line hidden
            EndContext();
            BeginContext(4937, 78, true);
            WriteLiteral("</td>\r\n                                                    <td class=\"center\">");
            EndContext();
            BeginContext(5016, 45, false);
#line 75 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.sugerencia));

#line default
#line hidden
            EndContext();
            BeginContext(5061, 62, true);
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
            EndContext();
#line 77 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaInfrestructura.cshtml"
                                                }

#line default
#line hidden
            BeginContext(5174, 373, true);
            WriteLiteral(@"                                            </tbody>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SGCFIEE.Models.CtMovilidades> Html { get; private set; }
    }
}
#pragma warning restore 1591
