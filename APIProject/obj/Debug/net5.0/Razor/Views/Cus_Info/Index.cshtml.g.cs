#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8fbdc02d212902adf722b615a1779258bd55ee9c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cus_Info_Index), @"mvc.1.0.view", @"/Views/Cus_Info/Index.cshtml")]
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
#line 1 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
using Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8fbdc02d212902adf722b615a1779258bd55ee9c", @"/Views/Cus_Info/Index.cshtml")]
    #nullable restore
    public class Views_Cus_Info_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<cus_info>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n");
            WriteLiteral(@"<table class=""table"">
    <thead>
        <tr>
            <th>
                Customer's ID
            </th>
            <th>
                Customer's First name
            </th>
            <th>
                Customer's Last name
            </th>
            <th>
                Customer's private account username
            </th>
            <th>
                Customer's private account password
            </th>
            <th>
                Customer's home address
            </th>
            <th>
                Customer's personal contact number
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 42 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
               Write(item.customer_id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
               Write(item.customer_first_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
               Write(item.customer_last_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
               Write(item.acc_username);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
               Write(item.acc_password);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
               Write(item.customer_address);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 64 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
               Write(item.customer_contact_number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            WriteLiteral("                </td>\r\n                <td>\r\n                    <a asp-action=\"GetCustomerByID\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1791, "\"", 1823, 1);
#nullable restore
#line 70 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
WriteAttributeValue("", 1806, item.customer_id, 1806, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a>\r\n                </td>\r\n                <td>\r\n                    <form asp-action=\"DeleteCustomerInfo\" method=\"post\">\r\n                        <a>Delete</a>\r\n                    </form>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 78 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<cus_info>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591