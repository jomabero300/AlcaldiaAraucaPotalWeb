#pragma checksum "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bfce68d4564ed68279797822959f49feb6cfef3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pqrs_Details), @"mvc.1.0.view", @"/Views/Pqrs/Details.cshtml")]
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
#line 1 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\_ViewImports.cshtml"
using AlcaldiaAraucaPortalWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\_ViewImports.cshtml"
using AlcaldiaAraucaPortalWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7bfce68d4564ed68279797822959f49feb6cfef3", @"/Views/Pqrs/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f21565cfdda8f56a5e6e3a1e6d89d5ce40c98a3", @"/Views/_ViewImports.cshtml")]
    public class Views_Pqrs_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AlcaldiaAraucaPortalWeb.Data.Entities.Gene.Pqrs>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Pqrs</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PqrsDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
       Write(Html.DisplayFor(model => model.PqrsDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PqrsMessage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
       Write(Html.DisplayFor(model => model.PqrsMessage));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PqrsCategory));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
       Write(Html.DisplayFor(model => model.PqrsCategory.PqrsCategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
       Write(Html.DisplayFor(model => model.ApplicationUser.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");
#nullable restore
#line 38 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
     if (Model.PqrsAttachments.Count > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-6\">\r\n            <table class=\"table\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>Ruta</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 48 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                     foreach (var item in Model.PqrsAttachments)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                         if (item.PqrsAttachmentsPath.EndsWith('f'))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td><a");
            BeginWriteAttribute("href", " href=\"", 1610, "\"", 1670, 2);
            WriteAttributeValue("", 1617, "../PDFViewerNewTab?fileName=", 1617, 28, true);
#nullable restore
#line 53 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
WriteAttributeValue("", 1645, item.PqrsAttachmentsPath, 1645, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"> ");
#nullable restore
#line 53 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                                                                                                                Write(item.PqrsAttachmentsPath);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                            </tr>\r\n");
#nullable restore
#line 55 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
        <div class=""col-md-6"">
            <table class=""table"">
                <thead>
                    <tr>
                        <th>Ruta</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 68 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                     foreach (var item in Model.PqrsAttachments)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                         if (item.PqrsAttachmentsPath.EndsWith('g'))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td><a");
            BeginWriteAttribute("href", " href=\"", 2367, "\"", 2427, 2);
            WriteAttributeValue("", 2374, "../PDFViewerNewTab?fileName=", 2374, 28, true);
#nullable restore
#line 73 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
WriteAttributeValue("", 2402, item.PqrsAttachmentsPath, 2402, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"> ");
#nullable restore
#line 73 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                                                                                                                Write(item.PqrsAttachmentsPath);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                            </tr>\r\n");
#nullable restore
#line 75 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 75 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n        </div>\r\n");
#nullable restore
#line 81 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bfce68d4564ed68279797822959f49feb6cfef312442", async() => {
                WriteLiteral("<i class=\"bi bi-pencil-fill\"></i>Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 84 "C:\Mbel\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\Pqrs\Details.cshtml"
                           WriteLiteral(Model.PqrsId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7bfce68d4564ed68279797822959f49feb6cfef314709", async() => {
                WriteLiteral("<i class=\"bi bi-chevron-double-left\"></i>Retornar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
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
            WriteLiteral("\r\n</div>\r\n<br />\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AlcaldiaAraucaPortalWeb.Data.Entities.Gene.Pqrs> Html { get; private set; }
    }
}
#pragma warning restore 1591
