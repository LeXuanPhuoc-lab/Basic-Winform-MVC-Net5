#pragma checksum "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6650315dd7d4ef8cbf213925922e9e17d42d545f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
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
#line 1 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
using DemoPagingAndCart.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6650315dd7d4ef8cbf213925922e9e17d42d545f", @"/Views/Product/List.cshtml")]
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("url", "/Product/List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("active-class", "active", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::DemoPagingAndCart.Tags.PagerTagHelper __DemoPagingAndCart_Tags_PagerTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6650315dd7d4ef8cbf213925922e9e17d42d545f3680", async() => {
                WriteLiteral("\r\n        <title>");
#nullable restore
#line 8 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
          Write(ViewData["title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
        <style>
            a {
                text-decoration: none;
                color: blue;
            }
            a:hover {
                text-decoration: underline;
                font-weight: bold;
            }

            .active{
                color: red;
            }

           
        </style>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6650315dd7d4ef8cbf213925922e9e17d42d545f5276", async() => {
                WriteLiteral("\r\n        <div>\r\n            <div style=\"width: 25%; float: left;\">\r\n                <ul>\r\n                    <li><a href=\"/Product/List\"");
                BeginWriteAttribute("class", " class=\"", 673, "\"", 735, 1);
#nullable restore
#line 30 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
WriteAttributeValue("", 681, (int)ViewData["CurrentCategory"] == 0 ? "active":"", 681, 54, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">All Products</a></li>\r\n");
#nullable restore
#line 31 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                     foreach(Category c in ViewBag.Categories)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <li>\r\n                    <a");
                BeginWriteAttribute("href", " href=\"", 899, "\"", 933, 2);
                WriteAttributeValue("", 906, "/Product/List/", 906, 14, true);
#nullable restore
#line 34 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
WriteAttributeValue("", 920, c.CategoryId, 920, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("class", " \r\n                               class=\"", 934, "\"", 1037, 1);
#nullable restore
#line 35 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
WriteAttributeValue("", 975, (int)ViewData["CurrentCategory"]==c.CategoryId ?"active":"", 975, 62, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                            ");
#nullable restore
#line 36 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                       Write(c.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </a>\r\n                        </li>\r\n");
#nullable restore
#line 39 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </ul>\r\n            </div>\r\n            <div style=\"width: 75%; float: left;\">\r\n");
#nullable restore
#line 43 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                 if(Model.Count == 0)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p>Not Found Any Products</p>\r\n");
#nullable restore
#line 46 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                     foreach(Product p in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <div>\r\n                            ");
#nullable restore
#line 52 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                       Write(p.ProductId);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 52 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                                      Write(p.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 52 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                                                Write(p.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 54 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <div>\r\n");
                WriteLiteral("            </div>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("pager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6650315dd7d4ef8cbf213925922e9e17d42d545f10530", async() => {
                    WriteLiteral("\r\n                    ");
                }
                );
                __DemoPagingAndCart_Tags_PagerTagHelper = CreateTagHelper<global::DemoPagingAndCart.Tags.PagerTagHelper>();
                __tagHelperExecutionContext.Add(__DemoPagingAndCart_Tags_PagerTagHelper);
#nullable restore
#line 68 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
__DemoPagingAndCart_Tags_PagerTagHelper.TotalPage = (int)@ViewData["TotalPage"];

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("total-page", __DemoPagingAndCart_Tags_PagerTagHelper.TotalPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 69 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
__DemoPagingAndCart_Tags_PagerTagHelper.CurrentCategory = (int)@ViewData["CurrentCategory"];

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("current-category", __DemoPagingAndCart_Tags_PagerTagHelper.CurrentCategory, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 70 "D:\SE171957-Phuoclx-FPTHCM\PRN211-DemoCode\SE171957-Solution\DemoPagingAndCart\Views\Product\List.cshtml"
__DemoPagingAndCart_Tags_PagerTagHelper.CurrentPage = (int)@ViewData["CurrentPage"];

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("current-page", __DemoPagingAndCart_Tags_PagerTagHelper.CurrentPage, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __DemoPagingAndCart_Tags_PagerTagHelper.Url = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __DemoPagingAndCart_Tags_PagerTagHelper.ActiveClass = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n    ");
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
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591