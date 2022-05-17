#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetCustomerTraffic.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7a27c091bdd2b4e12a3410e696191faaf90a906"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistic_GetCustomerTraffic), @"mvc.1.0.view", @"/Views/Statistic/GetCustomerTraffic.cshtml")]
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
#line 1 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetCustomerTraffic.cshtml"
using Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7a27c091bdd2b4e12a3410e696191faaf90a906", @"/Views/Statistic/GetCustomerTraffic.cshtml")]
    #nullable restore
    public class Views_Statistic_GetCustomerTraffic : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<cus_traffic_statistic>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetCustomerTraffic.cshtml"
  
    ViewData["Title"] = "Customer's information and hotel times";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<h1>Customers and their times of using Hotel services</h1>

<table class=""table"">
    <thead>
        <tr>
            <th>Customer's full name</th>
            <th>Customer's contact number</th>
            <th>Customer's address</th>
            <th>Number of times using hotel services</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 23 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetCustomerTraffic.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 26 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetCustomerTraffic.cshtml"
               Write(item.customer_full_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetCustomerTraffic.cshtml"
               Write(item.customer_contact_number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetCustomerTraffic.cshtml"
               Write(item.customer_address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 29 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetCustomerTraffic.cshtml"
               Write(item.count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 31 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetCustomerTraffic.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<cus_traffic_statistic>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591