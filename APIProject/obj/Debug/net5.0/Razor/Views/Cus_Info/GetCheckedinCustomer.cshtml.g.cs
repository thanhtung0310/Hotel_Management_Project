#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "acce80a8b3a518177d9a7763bd6f9db77927fee7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cus_Info_GetCheckedinCustomer), @"mvc.1.0.view", @"/Views/Cus_Info/GetCheckedinCustomer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cus_Info/GetCheckedinCustomer.cshtml", typeof(AspNetCore.Views_Cus_Info_GetCheckedinCustomer))]
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
#line 1 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
using Entity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"acce80a8b3a518177d9a7763bd6f9db77927fee7", @"/Views/Cus_Info/GetCheckedinCustomer.cshtml")]
    public class Views_Cus_Info_GetCheckedinCustomer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<checked_cus_info>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(69, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
  
    ViewData["Title"] = "Information of customer who has checked-in";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(196, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(236, 29, true);
            WriteLiteral("\r\n<h1>Customer\'s information ");
            EndContext();
            BeginContext(265, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acce80a8b3a518177d9a7763bd6f9db77927fee74287", async() => {
                BeginContext(318, 4, true);
                WriteLiteral("Back");
                EndContext();
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
            EndContext();
            BeginContext(326, 11, true);
            WriteLiteral("</h1>\r\n<h3>");
            EndContext();
            BeginContext(338, 18, false);
#line 12 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
Write(ViewBag.StatusCode);

#line default
#line hidden
            EndContext();
            BeginContext(356, 30, true);
            WriteLiteral("</h3>\r\n<h3 style=\"color:red;\">");
            EndContext();
            BeginContext(387, 15, false);
#line 13 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                  Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(402, 9, true);
            WriteLiteral("</h3>\r\n\r\n");
            EndContext();
#line 15 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(435, 527, true);
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th>Customer's ID</th>
                <th>Customer's first name</th>
                <th>Customer's last name</th>
                <th>Customer's contact number</th>
                <th>Room number</th>
                <th>Room type</th>
                <th>Room status</th>
                <th>Customer's check-in date</th>
                <th>Customer's expected check-out date</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 32 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1019, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(1066, 16, false);
#line 35 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                   Write(item.customer_id);

#line default
#line hidden
            EndContext();
            BeginContext(1082, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1114, 24, false);
#line 36 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                   Write(item.customer_first_name);

#line default
#line hidden
            EndContext();
            BeginContext(1138, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1170, 23, false);
#line 37 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                   Write(item.customer_last_name);

#line default
#line hidden
            EndContext();
            BeginContext(1193, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1225, 28, false);
#line 38 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                   Write(item.customer_contact_number);

#line default
#line hidden
            EndContext();
            BeginContext(1253, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1285, 16, false);
#line 39 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                   Write(item.room_number);

#line default
#line hidden
            EndContext();
            BeginContext(1301, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1333, 19, false);
#line 40 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                   Write(item.room_type_name);

#line default
#line hidden
            EndContext();
            BeginContext(1352, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1384, 21, false);
#line 41 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                   Write(item.room_status_name);

#line default
#line hidden
            EndContext();
            BeginContext(1405, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1437, 18, false);
#line 42 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                   Write(item.check_in_date);

#line default
#line hidden
            EndContext();
            BeginContext(1455, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1487, 28, false);
#line 43 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
                   Write(item.expected_check_out_date);

#line default
#line hidden
            EndContext();
            BeginContext(1515, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 45 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
            }

#line default
#line hidden
            BeginContext(1560, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 48 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Cus_Info\GetCheckedinCustomer.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<checked_cus_info>> Html { get; private set; }
    }
}
#pragma warning restore 1591
