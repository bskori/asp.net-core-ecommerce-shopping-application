#pragma checksum "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "134013ee25c41e715cba1757a68e8c643e5d6f0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserOrderControllers_ViewDispatchDetails), @"mvc.1.0.view", @"/Views/UserOrderControllers/ViewDispatchDetails.cshtml")]
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
#line 1 "D:\Project\StoreApp\StoreApp\Views\_ViewImports.cshtml"
using StoreApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\StoreApp\StoreApp\Views\_ViewImports.cshtml"
using StoreApp.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"134013ee25c41e715cba1757a68e8c643e5d6f0c", @"/Views/UserOrderControllers/ViewDispatchDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e3a08dc818599154c8905eebd11bdd7caedf6a4", @"/Views/_ViewImports.cshtml")]
    public class Views_UserOrderControllers_ViewDispatchDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UserOrderDispatch>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n\r\n    <div class=\"row\">\r\n\r\n        <div class=\"col-md-12\">\r\n            <br />\r\n            <br />\r\n\r\n                <h2 class=\"alert-danger text-center\">");
#nullable restore
#line 11 "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml"
                                                Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <br />\r\n            <br />\r\n");
#nullable restore
#line 14 "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml"
             if (Model != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table table-bordered table-hover"">
                    <tr>
                        <th>Order Id</th>
                        <th>Dispatch Date</th>
                        <th>Agency Name</th>
                        <th>Expected Reach Date</th>
                    </tr>
");
#nullable restore
#line 23 "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml"
                     foreach (var temp in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 26 "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml"
                           Write(temp.UserOrderID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 27 "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml"
                           Write(temp.DispatchDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 28 "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml"
                           Write(temp.DispatchAgency.DispatchAgencyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 29 "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml"
                           Write(temp.ExpectedReachDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 31 "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </table>\r\n");
#nullable restore
#line 34 "D:\Project\StoreApp\StoreApp\Views\UserOrderControllers\ViewDispatchDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UserOrderDispatch>> Html { get; private set; }
    }
}
#pragma warning restore 1591
