#pragma checksum "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d5a2156deed7191bb0a4d59017da571810e262b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EstudiantesBuzon_TablaAcademicos), @"mvc.1.0.view", @"/Views/EstudiantesBuzon/TablaAcademicos.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EstudiantesBuzon/TablaAcademicos.cshtml", typeof(AspNetCore.Views_EstudiantesBuzon_TablaAcademicos))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d5a2156deed7191bb0a4d59017da571810e262b", @"/Views/EstudiantesBuzon/TablaAcademicos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225633a62ddc17bf9f6645008885b94288a8c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesBuzon_TablaAcademicos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SGCFIEE.Models.CtMovilidades>
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
#line 2 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Home/Principal.cshtml";
    var modelo = (IEnumerable<TablaSugerenciasBuzon>)ViewData["lista"];

#line default
#line hidden
            BeginContext(199, 1255, true);
            WriteLiteral(@"<!DOCTYPE html>
<html>
<div class=""profile-content"">
    <div class=""row"">
        <div class=""col-md-12 col-sm-12"">
            <div class=""card"">
                <div class=""card-topline-green"">
                    <div class=""card-head"">
                        <header>Sugerencias sobre academicos</header>
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
            WriteLiteral("                 <div class=\"card-body \">\r\n                                    <div class=\"row p-b-20\">\r\n                                        <div class=\"col-md-12 col-sm-12 col-12\">\r\n                                            ");
            EndContext();
            BeginContext(1454, 1435, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5a2156deed7191bb0a4d59017da571810e262b7358", async() => {
                BeginContext(1508, 217, true);
                WriteLiteral("\r\n                                                <div class=\"form-group\">\r\n                                                    <div class=\"col-md-4 col-sm-4\">\r\n                                                        ");
                EndContext();
                BeginContext(1725, 84, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5a2156deed7191bb0a4d59017da571810e262b7966", async() => {
                    BeginContext(1758, 43, true);
                    WriteLiteral("Elija el tipo de sugerencias que desee ver:");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#line 35 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
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
                BeginContext(1809, 58, true);
                WriteLiteral("\r\n                                                        ");
                EndContext();
                BeginContext(1867, 467, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5a2156deed7191bb0a4d59017da571810e262b9822", async() => {
                    BeginContext(1932, 62, true);
                    WriteLiteral("\r\n                                                            ");
                    EndContext();
                    BeginContext(1994, 41, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5a2156deed7191bb0a4d59017da571810e262b10288", async() => {
                        BeginContext(2012, 14, true);
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
                    BeginContext(2035, 62, true);
                    WriteLiteral("\r\n                                                            ");
                    EndContext();
                    BeginContext(2097, 56, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5a2156deed7191bb0a4d59017da571810e262b11911", async() => {
                        BeginContext(2115, 29, true);
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
                    BeginContext(2153, 62, true);
                    WriteLiteral("\r\n                                                            ");
                    EndContext();
                    BeginContext(2215, 52, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d5a2156deed7191bb0a4d59017da571810e262b13549", async() => {
                        BeginContext(2233, 25, true);
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
                    BeginContext(2267, 58, true);
                    WriteLiteral("\r\n                                                        ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 36 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
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
                BeginContext(2334, 548, true);
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
#line 32 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
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
            BeginContext(2889, 1180, true);
            WriteLiteral(@"
                                            <br />
                                        </div>
                                    </div>
                                    <div class=""table-scrollable"">
                                        <table class=""table table-striped table-bordered table-hover table-checkable order-column"" style=""width: 100%"" id=""example1"">
                                            <thead>
                                                <tr>
                                                    <th hidden></th>
                                                    <th class=""center""> Nombre del académico</th>
                                                    <th class=""center""> Nombre del alumno</th>
                                                    <th class=""center""> Periodo</th>
                                                    <th class=""center""> Propuesta</th>
                                                    <th class=""center""> Sugerencia</th>

      ");
            WriteLiteral("                                          </tr>\r\n                                            </thead>\r\n                                            <tbody>\r\n");
            EndContext();
#line 66 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
                                                 foreach (var item in modelo)
                                                {
                                                    var nameAca = item.nombreMaestro + " " + item.apePat + " " + item.apeMaP;
                                                    var name = item.nombreAlu + " " + item.apeAluP + " " + item.apeAluM;

#line default
#line hidden
            BeginContext(4448, 226, true);
            WriteLiteral("                                                    <tr class=\"odd gradeX\">\r\n                                                        <td hidden></td>\r\n                                                        <td class=\"center\">");
            EndContext();
            BeginContext(4675, 37, false);
#line 72 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
                                                                      Write(Html.DisplayFor(modelItem => nameAca));

#line default
#line hidden
            EndContext();
            BeginContext(4712, 82, true);
            WriteLiteral("</td>\r\n                                                        <td class=\"center\">");
            EndContext();
            BeginContext(4795, 34, false);
#line 73 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
                                                                      Write(Html.DisplayFor(modelItem => name));

#line default
#line hidden
            EndContext();
            BeginContext(4829, 82, true);
            WriteLiteral("</td>\r\n                                                        <td class=\"center\">");
            EndContext();
            BeginContext(4912, 42, false);
#line 74 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
                                                                      Write(Html.DisplayFor(modelItem => item.nomPeri));

#line default
#line hidden
            EndContext();
            BeginContext(4954, 82, true);
            WriteLiteral("</td>\r\n                                                        <td class=\"center\">");
            EndContext();
            BeginContext(5037, 44, false);
#line 75 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
                                                                      Write(Html.DisplayFor(modelItem => item.propuesta));

#line default
#line hidden
            EndContext();
            BeginContext(5081, 82, true);
            WriteLiteral("</td>\r\n                                                        <td class=\"center\">");
            EndContext();
            BeginContext(5164, 45, false);
#line 76 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
                                                                      Write(Html.DisplayFor(modelItem => item.sugerencia));

#line default
#line hidden
            EndContext();
            BeginContext(5209, 66, true);
            WriteLiteral("</td>\r\n                                                    </tr>\r\n");
            EndContext();
#line 78 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesBuzon\TablaAcademicos.cshtml"
                                                }

#line default
#line hidden
            BeginContext(5326, 373, true);
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
