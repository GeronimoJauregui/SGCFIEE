#pragma checksum "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0564dfadb458805547cc8a21da7a962dc63f3afa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AcademicosPublicaciones_AcademicosCapituloLibros), @"mvc.1.0.view", @"/Views/AcademicosPublicaciones/AcademicosCapituloLibros.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AcademicosPublicaciones/AcademicosCapituloLibros.cshtml", typeof(AspNetCore.Views_AcademicosPublicaciones_AcademicosCapituloLibros))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0564dfadb458805547cc8a21da7a962dc63f3afa", @"/Views/AcademicosPublicaciones/AcademicosCapituloLibros.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225633a62ddc17bf9f6645008885b94288a8c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_AcademicosPublicaciones_AcademicosCapituloLibros : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SGCFIEE.Models.TablaAcadCapLibros>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/plugins/sweet-alert/sweetalert.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/plugins/sweet-alert/sweetalert.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/pages/sweet-alert/sweet-alert-data.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AcademicosPublicaciones", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GuardarAcadCapLibros", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IndexCapitulos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm m-b-10"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("float:right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/pages/table/table_data.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
  
    ViewData["Title"] = "AcadArticulos";
    Layout = "~/Views/Home/Principal.cshtml";
    var acade = (IEnumerable<Academicos>)ViewData["academicos"];
    var Acad = (Academicocaplibro)ViewData["Acad"];
    var tipo = (int)ViewData["tipo"];

#line default
#line hidden
            BeginContext(311, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(313, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "0564dfadb458805547cc8a21da7a962dc63f3afa8620", async() => {
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
            BeginContext(391, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(393, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0564dfadb458805547cc8a21da7a962dc63f3afa9873", async() => {
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
            BeginContext(463, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(465, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0564dfadb458805547cc8a21da7a962dc63f3afa11050", async() => {
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
            BeginContext(538, 52, true);
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 17 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
         if (TempData["msg"] != null)
        {
            

#line default
#line hidden
            BeginContext(653, 25, false);
#line 19 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
       Write(Html.Raw(TempData["msg"]));

#line default
#line hidden
            EndContext();
#line 19 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                      
        }

#line default
#line hidden
            BeginContext(691, 618, true);
            WriteLiteral(@"        <div class=""col-md-12 col-sm-12"">
            <div class=""card card-box"">
                <div class=""card-topline-green card-head"">
                    <header>COLABORADORES</header>
                </div>
                <div class=""white-box"">
                    <div class=""tab-content"">
                        <div class=""tab-pane active fontawesome-demo"" id=""tab1"">
                            <div id=""Artículos"">
                                <div class=""row"">
                                    <div class=""col-md-12"">
                                        <div class=""card-body "">
");
            EndContext();
#line 33 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                 if (Acad != null || tipo == 1)
                                                {

#line default
#line hidden
            BeginContext(1441, 52, true);
            WriteLiteral("                                                    ");
            EndContext();
            BeginContext(1493, 2546, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0564dfadb458805547cc8a21da7a962dc63f3afa14150", async() => {
                BeginContext(1618, 81, true);
                WriteLiteral("\r\n                                                        <input name=\"Caplibros\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1699, "\"", 1731, 1);
#line 36 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
WriteAttributeValue("", 1707, ViewData["idCapLibros"], 1707, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1732, 598, true);
                WriteLiteral(@" type=""hidden""/>
                                                        <input name=""Lider"" value=""0"" type=""hidden""/>
                                                        <div class=""row p-b-20"">
                                                            <div class=""col-md-4 col-md-4"">
                                                                <div class=""form-group"">
                                                                    <label>Académico</label>
                                                                    <select name=""idAcademico"" class=""form-control"">
");
                EndContext();
#line 43 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                         foreach (var item in acade)
                                                                        {

#line default
#line hidden
                BeginContext(2507, 76, true);
                WriteLiteral("                                                                            ");
                EndContext();
                BeginContext(2583, 190, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0564dfadb458805547cc8a21da7a962dc63f3afa16209", async() => {
                    BeginContext(2619, 41, false);
#line 45 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                                                          Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
                    EndContext();
                    BeginContext(2660, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                    BeginContext(2662, 50, false);
#line 45 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                                                                                                     Write(Html.DisplayFor(modelItem => item.ApellidoPaterno));

#line default
#line hidden
                    EndContext();
                    BeginContext(2712, 1, true);
                    WriteLiteral(" ");
                    EndContext();
                    BeginContext(2714, 50, false);
#line 45 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                                                                                                                                                         Write(Html.DisplayFor(modelItem => item.ApellidoMaterno));

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 45 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                               WriteLiteral(item.IdAcademicos);

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
                BeginContext(2773, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 46 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                        }

#line default
#line hidden
                BeginContext(2850, 1182, true);
                WriteLiteral(@"                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class=""row p-b-20"">
                                                            <div class=""col-md-2 col-sm-6 col-2"">
                                                                <div class=""btn-group"">
                                                                    <button type=""submit"" class=""btn btn-success btn-sm m-b-10"" name=""Guardar"" style=""float:right"">
                                                                        Académico<i class=""fa fa-plus"" style=""color:white""></i>
                                                                    </button>
                                                                </div>
                          ");
                WriteLiteral("                                  </div>\r\n                                                        </div>\r\n                                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4039, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 61 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                }

#line default
#line hidden
            BeginContext(4092, 672, true);
            WriteLiteral(@"                                            <div class=""table-scrollable"">
                                                <table class=""table table-striped table-bordered table-hover table-checkable order-column""  style=""width: 100%"" id=""TablaArticulos"" >
                                                    <thead>
                                                        <tr>
                                                            <th hidden></th>
                                                            <th class=""center""> Numero de personal</th>
                                                            <th class=""center""> Nombre del académico</th>
");
            EndContext();
#line 69 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                             if(tipo == 2)
                                                            {
                                                                

#line default
#line hidden
#line 71 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                 if (Acad != null)
                                                                {

#line default
#line hidden
            BeginContext(5054, 101, true);
            WriteLiteral("                                                                    <th class=\"center\"> Acción</th>\r\n");
            EndContext();
#line 74 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                }

#line default
#line hidden
#line 74 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                 
                                                            }

#line default
#line hidden
            BeginContext(5285, 60, true);
            WriteLiteral("                                                            ");
            EndContext();
#line 76 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                             if(tipo == 1)
                                                            {

#line default
#line hidden
            BeginContext(5424, 97, true);
            WriteLiteral("                                                                <th class=\"center\"> Acción</th>\r\n");
            EndContext();
#line 79 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                            }

#line default
#line hidden
            BeginContext(5584, 186, true);
            WriteLiteral("                                                        </tr>\r\n                                                    </thead>\r\n                                                    <tbody>\r\n");
            EndContext();
#line 83 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                         foreach (var item in Model)
                                                        {

#line default
#line hidden
            BeginContext(5915, 235, true);
            WriteLiteral("                                                            <tr class=\"odd gradeX\">\r\n                                                                <td hidden></td>\r\n                                                                <td>");
            EndContext();
            BeginContext(6151, 46, false);
#line 87 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.NumPersonal));

#line default
#line hidden
            EndContext();
            BeginContext(6197, 75, true);
            WriteLiteral("</td>\r\n                                                                <td>");
            EndContext();
            BeginContext(6273, 41, false);
#line 88 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                               Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(6314, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(6316, 50, false);
#line 88 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                                                          Write(Html.DisplayFor(modelItem => item.ApellidoPaterno));

#line default
#line hidden
            EndContext();
            BeginContext(6366, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(6368, 50, false);
#line 88 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                                                                                                              Write(Html.DisplayFor(modelItem => item.ApellidoMaterno));

#line default
#line hidden
            EndContext();
            BeginContext(6418, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 89 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                 if (tipo == 2)
                                                                {
                                                                    

#line default
#line hidden
#line 91 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                     if (Acad != null)
                                                                    {

#line default
#line hidden
            BeginContext(6732, 184, true);
            WriteLiteral("                                                                        <td class=\"center\">\r\n                                                                            <a data-value=\"");
            EndContext();
            BeginContext(6917, 20, false);
#line 94 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                                      Write(item.IdAcadCapLibros);

#line default
#line hidden
            EndContext();
            BeginContext(6937, 11, true);
            WriteLiteral("\" data-id=\"");
            EndContext();
            BeginContext(6949, 16, false);
#line 94 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                                                                      Write(item.IdCapLibros);

#line default
#line hidden
            EndContext();
            BeginContext(6965, 468, true);
            WriteLiteral(@""" data-controlador=""AcademicosPublicaciones"" data-accion=""EliminarAcadCapLibros"" data-regreso=""AcademicosCapituloLibros"" name=""eliminaracademico"" class=""btn btn-danger btn-xs"" title=""Eliminar"">
                                                                                <i class=""fa fa-trash-o ""></i>
                                                                            </a>
                                                                        </td>
");
            EndContext();
#line 98 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                    }

#line default
#line hidden
#line 98 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                     
                                                                }

#line default
#line hidden
            BeginContext(7571, 64, true);
            WriteLiteral("                                                                ");
            EndContext();
#line 100 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                 if (tipo == 1)
                                                                {

#line default
#line hidden
            BeginContext(7719, 176, true);
            WriteLiteral("                                                                    <td class=\"center\">\r\n                                                                        <a data-value=\"");
            EndContext();
            BeginContext(7896, 20, false);
#line 103 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                                  Write(item.IdAcadCapLibros);

#line default
#line hidden
            EndContext();
            BeginContext(7916, 11, true);
            WriteLiteral("\" data-id=\"");
            EndContext();
            BeginContext(7928, 16, false);
#line 103 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                                                                  Write(item.IdCapLibros);

#line default
#line hidden
            EndContext();
            BeginContext(7944, 456, true);
            WriteLiteral(@""" data-controlador=""AcademicosPublicaciones"" data-accion=""EliminarAcadCapLibros"" data-regreso=""AcademicosCapituloLibros"" name=""eliminaracademico"" class=""btn btn-danger btn-xs"" title=""Eliminar"">
                                                                            <i class=""fa fa-trash-o ""></i>
                                                                        </a>
                                                                    </td>
");
            EndContext();
#line 107 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                                }

#line default
#line hidden
            BeginContext(8467, 67, true);
            WriteLiteral("                                                            </tr>\r\n");
            EndContext();
#line 109 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\AcademicosPublicaciones\AcademicosCapituloLibros.cshtml"
                                                        }

#line default
#line hidden
            BeginContext(8593, 216, true);
            WriteLiteral("                                                    </tbody>\r\n                                                </table>\r\n                                            </div>\r\n                                            ");
            EndContext();
            BeginContext(8809, 238, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0564dfadb458805547cc8a21da7a962dc63f3afa35072", async() => {
                BeginContext(8939, 104, true);
                WriteLiteral("\r\n                                                Regresar\r\n                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(9047, 317, true);
            WriteLiteral(@"
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
            BeginContext(9364, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0564dfadb458805547cc8a21da7a962dc63f3afa37238", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SGCFIEE.Models.TablaAcadCapLibros>> Html { get; private set; }
    }
}
#pragma warning restore 1591
