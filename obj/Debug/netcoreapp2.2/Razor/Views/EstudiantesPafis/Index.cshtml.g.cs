#pragma checksum "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53088734a5cb8a93b8cbb2ab29158a64a50d6451"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EstudiantesPafis_Index), @"mvc.1.0.view", @"/Views/EstudiantesPafis/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/EstudiantesPafis/Index.cshtml", typeof(AspNetCore.Views_EstudiantesPafis_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53088734a5cb8a93b8cbb2ab29158a64a50d6451", @"/Views/EstudiantesPafis/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1225633a62ddc17bf9f6645008885b94288a8c6a", @"/Views/_ViewImports.cshtml")]
    public class Views_EstudiantesPafis_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SGCFIEE.Models.TablaPafi>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/js/pages/table/table_data.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "EstudiantesPafis", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SolicitudPafi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm m-b-10"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetallesPafi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-xs infoextra"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Toda la información"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Inscribir", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-xs eliminar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Enlistar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Desenlistar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-xs eliminar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Desenlistar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
  
    ViewData["Title"] = "Index";
    var x = (int)ViewData["tipo"];
    Layout = "~/Views/Home/Principal.cshtml";

#line default
#line hidden
            BeginContext(171, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(175, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53088734a5cb8a93b8cbb2ab29158a64a50d64518113", async() => {
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
            BeginContext(236, 795, true);
            WriteLiteral(@"
<!DOCTYPE html>

<html>
<div class=""profile-content"">
    <div class=""row"">
        <div class=""col-md-12 col-sm-12"">
            <div class=""card card-topline-green"">
                <div class=""card-head"">
                    <header>PAFIs</header>
                    <div class=""tools"">
                        <a class=""fa fa-repeat btn-color box-refresh"" href=""javascript:;""></a>
                        <a class=""t-collapse btn-color fa fa-chevron-down"" href=""javascript:;""></a>
                        <a class=""t-close btn-color fa fa-times"" href=""javascript:;""></a>
                    </div>
                </div>
            
            <div class=""card-body"">
                <div class=""row p-b-20"">
                    <div class=""col-md-6 col-sm-6 col-6"">
");
            EndContext();
#line 27 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                         if (x == 3)
                        {

#line default
#line hidden
            BeginContext(1096, 85, true);
            WriteLiteral("                            <div class=\"btn-group\">\r\n                                ");
            EndContext();
            BeginContext(1181, 192, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53088734a5cb8a93b8cbb2ab29158a64a50d645110496", async() => {
                BeginContext(1283, 86, true);
                WriteLiteral("\r\n                                    Solicitar pafi\r\n                                ");
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
            BeginContext(1373, 38, true);
            WriteLiteral("\r\n                            </div>\r\n");
            EndContext();
#line 34 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(1438, 1047, true);
            WriteLiteral(@"                    </div>
                </div>
                <div class=""table-scrollable"">
                    <table class=""table table-striped table-bordered table-hover table-checkable order-column"" style=""width: 100%"" id=""example1"">
                        <thead>
                            <tr>
                                <th hidden></th>
                                <th class=""center"">Alumnos inscritos</th>
                                <th class=""center"">Nombre del PAFI</th>
                                <th class=""center"">Horario</th>
                                <th class=""center"">Nombre del académico</th>
                                <th class=""center"">Salón</th>
                                <th class=""center"">Programa educativo al que impacta</th>
                                <th class=""center"">Tipo de PAFI</th>
                                <th class=""center"">Acción</th>

                            </tr>
                        </thead>
          ");
            WriteLiteral("              <tbody>\r\n");
            EndContext();
#line 54 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
            BeginContext(2574, 166, true);
            WriteLiteral("                                <tr class=\"odd gradeX\">\r\n                                    <td hidden></td>\r\n                                    <td class=\"center\">");
            EndContext();
            BeginContext(2741, 44, false);
#line 58 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.TotalAlum));

#line default
#line hidden
            EndContext();
            BeginContext(2785, 62, true);
            WriteLiteral("</td>\r\n                                    <td class=\"center\">");
            EndContext();
            BeginContext(2848, 45, false);
#line 59 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.NombrePafi));

#line default
#line hidden
            EndContext();
            BeginContext(2893, 62, true);
            WriteLiteral("</td>\r\n                                    <td class=\"center\">");
            EndContext();
            BeginContext(2956, 42, false);
#line 60 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.Horario));

#line default
#line hidden
            EndContext();
            BeginContext(2998, 62, true);
            WriteLiteral("</td>\r\n                                    <td class=\"center\">");
            EndContext();
            BeginContext(3061, 48, false);
#line 61 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.NombreMaestro));

#line default
#line hidden
            EndContext();
            BeginContext(3109, 62, true);
            WriteLiteral("</td>\r\n                                    <td class=\"center\">");
            EndContext();
            BeginContext(3172, 43, false);
#line 62 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.ClvSalon));

#line default
#line hidden
            EndContext();
            BeginContext(3215, 62, true);
            WriteLiteral("</td>\r\n                                    <td class=\"center\">");
            EndContext();
            BeginContext(3278, 45, false);
#line 63 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                                  Write(Html.DisplayFor(modelItem => item.ProgrmaEdu));

#line default
#line hidden
            EndContext();
            BeginContext(3323, 64, true);
            WriteLiteral("</td>\r\n                                    <td class=\"center\">\r\n");
            EndContext();
#line 65 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                     if(item.TipoPafi == 0)
                                    {

#line default
#line hidden
            BeginContext(3487, 64, true);
            WriteLiteral("                                        <div>Nivelatorio</div>\r\n");
            EndContext();
#line 68 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(3671, 61, true);
            WriteLiteral("                                        <div>Remedial</div>\r\n");
            EndContext();
#line 72 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                    }

#line default
#line hidden
            BeginContext(3771, 100, true);
            WriteLiteral("                                    </td>\r\n                                    <td class=\"center\">\r\n");
            EndContext();
#line 75 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                         if (x == 1)
                                        {

#line default
#line hidden
            BeginContext(3968, 44, true);
            WriteLiteral("                                            ");
            EndContext();
            BeginContext(4012, 287, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53088734a5cb8a93b8cbb2ab29158a64a50d645118482", async() => {
                BeginContext(4172, 123, true);
                WriteLiteral("\r\n                                                <i class=\"fa fa-check\"></i>\r\n                                            ");
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
#line 77 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                                 WriteLiteral(item.idPafi);

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
            BeginContext(4299, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 80 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                        }

#line default
#line hidden
            BeginContext(4344, 40, true);
            WriteLiteral("                                        ");
            EndContext();
#line 81 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                         if (x == 3)
                                        {
                                            

#line default
#line hidden
#line 83 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                             if (item.inscrito == 0)
                                            {

#line default
#line hidden
            BeginContext(4558, 48, true);
            WriteLiteral("                                                ");
            EndContext();
            BeginContext(4606, 283, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53088734a5cb8a93b8cbb2ab29158a64a50d645122293", async() => {
                BeginContext(4751, 134, true);
                WriteLiteral("\r\n                                                    <i class=\"fa fa-sign-in \"></i>\r\n                                                ");
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
#line 85 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                                     WriteLiteral(item.idPafi);

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
            BeginContext(4889, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 88 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                            }

#line default
#line hidden
#line 89 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                             if (item.inscrito == 1)
                                            {

#line default
#line hidden
            BeginContext(5055, 48, true);
            WriteLiteral("                                                ");
            EndContext();
            BeginContext(5103, 288, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53088734a5cb8a93b8cbb2ab29158a64a50d645125714", async() => {
                BeginContext(5252, 135, true);
                WriteLiteral("\r\n                                                    <i class=\"fa fa-sign-out \"></i>\r\n                                                ");
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
#line 91 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                                     WriteLiteral(item.idPafi);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5391, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 94 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                            }

#line default
#line hidden
#line 94 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                                             
                                        }

#line default
#line hidden
            BeginContext(5483, 82, true);
            WriteLiteral("                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 98 "C:\Users\dxvm1\Desktop\sgc cuarentena\SGCFIEE\Views\EstudiantesPafis\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(5596, 171, true);
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SGCFIEE.Models.TablaPafi>> Html { get; private set; }
    }
}
#pragma warning restore 1591
