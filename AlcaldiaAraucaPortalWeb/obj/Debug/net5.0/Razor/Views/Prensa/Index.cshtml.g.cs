#pragma checksum "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31d6e8b55d8e63a9433f45baf6f473aa21f57523"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prensa_Index), @"mvc.1.0.view", @"/Views/Prensa/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\_ViewImports.cshtml"
using AlcaldiaAraucaPortalWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\_ViewImports.cshtml"
using AlcaldiaAraucaPortalWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31d6e8b55d8e63a9433f45baf6f473aa21f57523", @"/Views/Prensa/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f21565cfdda8f56a5e6e3a1e6d89d5ce40c98a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Prensa_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AlcaldiaAraucaPortalWeb.Data.Entities.Cont.Content>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
  
    ViewData["Title"] = "Contenido";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31d6e8b55d8e63a9433f45baf6f473aa21f575235553", async() => {
                WriteLiteral("\r\n    <section>\r\n        <div class=\"row\" style=\"width:100%;\">\r\n            <di class=\"col-md-10\">\r\n                <h2>");
#nullable restore
#line 10 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
               Write(ViewBag.LineName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n            </di>\r\n            <di class=\"col-md-2 text-right\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31d6e8b55d8e63a9433f45baf6f473aa21f575236292", async() => {
                    WriteLiteral("<i class=\"bi bi-file-earmark-fill\"></i> Nuevo");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </di>\r\n        </div>\r\n\r\n    </section>\r\n    <section>\r\n        <table id=\"MyTable\" class=\"table table-striped\" style=\"width:100%\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
#nullable restore
#line 23 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ContentDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 26 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ContentTitle));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 29 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ContentText));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 32 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.ContentUrlImg));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 35 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.StateId));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </th>\r\n                    <th>Proceso</th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 41 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 45 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ContentDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 48 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ContentTitle));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 51 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ContentText));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <img");
                BeginWriteAttribute("src", " src=\"", 1949, "\"", 1987, 1);
#nullable restore
#line 54 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
WriteAttributeValue("", 1955, Url.Content(item.ContentUrlImg), 1955, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-rounded\" alt=\"Image\" style=\"width:60px;height:60px;max-width: 60%; height: auto;\" />\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 57 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.State.StateName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31d6e8b55d8e63a9433f45baf6f473aa21f5752312381", async() => {
                    WriteLiteral("<i class=\"bi bi-pencil-fill\"></i> Editar");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                                                   WriteLiteral(item.ContentId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" |\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31d6e8b55d8e63a9433f45baf6f473aa21f5752314817", async() => {
                    WriteLiteral("<i class=\"bi bi-trash2-fill\"></i> Eliminar");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 61 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                                                     WriteLiteral(item.ContentId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 64 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Prensa\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </section>\r\n    <footer>\r\n        <h4 style=\"color:white;\">Avisos legales</h4>\r\n        <a href=\"#\"style=\"color:white\">Política de cookies</a>\r\n    </footer>\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#MyTable').DataTable({
                language: {
                    ""url"": ""//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json""
                }
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AlcaldiaAraucaPortalWeb.Data.Entities.Cont.Content>> Html { get; private set; }
    }
}
#pragma warning restore 1591
