#pragma checksum "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a7900c03f205aeba148c36f1f9aeb598179c590"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_LineStrategic_GeneViewHorizontal1), @"mvc.1.0.view", @"/Views/LineStrategic/GeneViewHorizontal1.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a7900c03f205aeba148c36f1f9aeb598179c590", @"/Views/LineStrategic/GeneViewHorizontal1.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9f21565cfdda8f56a5e6e3a1e6d89d5ce40c98a3", @"/Views/_ViewImports.cshtml")]
    public class Views_LineStrategic_GeneViewHorizontal1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AlcaldiaAraucaPortalWeb.Models.ContentModelView>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<style>\r\n    #header {\r\n        background: url(");
#nullable restore
#line 9 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml"
                   Write(ViewBag.RulImagen);

#line default
#line hidden
#nullable disable
            WriteLiteral(") center center / cover no-repeat;\r\n    }\r\n</style>\r\n<section id=\"header\" class=\"jumbotron text-center\">\r\n    <h1 class=\"display-3\">");
#nullable restore
#line 13 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml"
                     Write(ViewBag.TituloHead);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p class=\"lead\">");
#nullable restore
#line 14 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml"
               Write(ViewBag.SubTituloHead);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</section>\r\n\r\n<section id=\"gallery\">\r\n    <div class=\"container\">\r\n        <div class=\"row d-flex justify-content-center text-center g-0\">\r\n");
#nullable restore
#line 20 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-lg-4 mb-4\">\r\n                    <div class=\"card\" style=\"width:20em;margin:10px;\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 722, "\"", 737, 1);
#nullable restore
#line 24 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml"
WriteAttributeValue("", 728, item.img, 728, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"card-img-top\" />\r\n                        <div class=\"card-body\">\r\n                            <h5 class=\"card-title\">");
#nullable restore
#line 26 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml"
                                              Write(item.title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <p class=\"card-text\">");
#nullable restore
#line 27 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml"
                                            Write(item.text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 977, "\"", 984, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-success btn-sm\">Read More</a>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 33 "C:\Mbel\DanielCorregida\AlcaldiaAraucaPortalWeb\AlcaldiaAraucaPortalWeb\Views\LineStrategic\GeneViewHorizontal1.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AlcaldiaAraucaPortalWeb.Models.ContentModelView>> Html { get; private set; }
    }
}
#pragma warning restore 1591
