#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0303a020d81a9778c0193016f21a7a745f4c57e0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistic_GetOrderNumInMonth), @"mvc.1.0.view", @"/Views/Statistic/GetOrderNumInMonth.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Statistic/GetOrderNumInMonth.cshtml", typeof(AspNetCore.Views_Statistic_GetOrderNumInMonth))]
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
#line 1 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml"
using Entity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0303a020d81a9778c0193016f21a7a745f4c57e0", @"/Views/Statistic/GetOrderNumInMonth.cshtml")]
    public class Views_Statistic_GetOrderNumInMonth : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<order_number_statistic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(69, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml"
  
    ViewData["Title"] = "Number of orders in a month";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(181, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(214, 63, true);
            WriteLiteral("\r\n<h1><a id=\"printedHeader\">The number of orders in a month</a>");
            EndContext();
            BeginContext(277, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0303a020d81a9778c0193016f21a7a745f4c57e04868", async() => {
                BeginContext(330, 4, true);
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
            BeginContext(338, 11, true);
            WriteLiteral("</h1>\r\n<h3>");
            EndContext();
            BeginContext(350, 18, false);
#line 12 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml"
Write(ViewBag.StatusCode);

#line default
#line hidden
            EndContext();
            BeginContext(368, 30, true);
            WriteLiteral("</h3>\r\n<h3 style=\"color:red;\">");
            EndContext();
            BeginContext(399, 15, false);
#line 13 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml"
                  Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(414, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
            BeginContext(421, 328, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0303a020d81a9778c0193016f21a7a745f4c57e07080", async() => {
                BeginContext(441, 301, true);
                WriteLiteral(@"
    <div class=""form-group"">
        <label for=""date"">Input date:</label>
        <input type=""date"" class=""form-control"" name=""date"" />
    </div>
    <div class=""text-center panel-body"">
        <button type=""submit"" class=""btn btn-sm btn-primary"">Get statistic</button>
    </div> <br />
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(749, 122, true);
            WriteLiteral("\r\n\r\n<input class=\"btn btn-sm btn-secondary\" type=\"button\" value=\"Print report\" onclick=\"printDiv()\" />\r\n<br />\r\n<br />\r\n\r\n");
            EndContext();
#line 28 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(895, 373, true);
            WriteLiteral(@"    <div id=""printedDiv"">
        <table class=""table table-sm table-striped table-bordered m-2"">
            <thead>
                <tr>
                    <th>Month</th>
                    <th>Year</th>
                    <th>Number of Orders</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>");
            EndContext();
            BeginContext(1269, 11, false);
#line 41 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml"
                   Write(Model.date1);

#line default
#line hidden
            EndContext();
            BeginContext(1280, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1312, 11, false);
#line 42 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml"
                   Write(Model.date2);

#line default
#line hidden
            EndContext();
            BeginContext(1323, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1355, 11, false);
#line 43 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml"
                   Write(Model.count);

#line default
#line hidden
            EndContext();
            BeginContext(1366, 82, true);
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 48 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumInMonth.cshtml"
}

#line default
#line hidden
            BeginContext(1451, 606, true);
            WriteLiteral(@"
<script>
    function printDiv() {
        var divContents = document.getElementById(""printedDiv"").innerHTML;
        var headerContents = document.getElementById(""printedHeader"").innerHTML;

        var a = window.open('', '', 'height=1000, width=500');

        a.document.write('<html>');
        a.document.write('<body> ');
        a.document.write('<h1> ');
        a.document.write(headerContents);
        a.document.write('</h1> ');
        a.document.write(divContents);
        a.document.write('</body></html>');
        a.document.close();
        a.print();
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<order_number_statistic> Html { get; private set; }
    }
}
#pragma warning restore 1591
