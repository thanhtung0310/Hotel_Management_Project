#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumBetweenDates.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b79876341d6aeaab88931f4a807f718d25f40ce8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistic_GetOrderNumBetweenDates), @"mvc.1.0.view", @"/Views/Statistic/GetOrderNumBetweenDates.cshtml")]
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
#line 1 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumBetweenDates.cshtml"
using Entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b79876341d6aeaab88931f4a807f718d25f40ce8", @"/Views/Statistic/GetOrderNumBetweenDates.cshtml")]
    #nullable restore
    public class Views_Statistic_GetOrderNumBetweenDates : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<order_number_statistic>
    #nullable disable
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
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumBetweenDates.cshtml"
  
    ViewData["Title"] = "Number of orders between dates";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>The number of orders between dates ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b79876341d6aeaab88931f4a807f718d25f40ce84573", async() => {
                WriteLiteral("Back");
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
            WriteLiteral("</h1>\r\n<h3>");
#nullable restore
#line 12 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumBetweenDates.cshtml"
Write(ViewBag.StatusCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b79876341d6aeaab88931f4a807f718d25f40ce86078", async() => {
                WriteLiteral(@"
    <div class=""form-group"">
        <label for=""date1"">From:</label>
        <input type=""date"" class=""form-control"" name=""date1"" />
    </div>
    <div class=""form-group"">
        <label for=""date2"">From:</label>
        <input type=""date"" class=""form-control"" name=""date2"" />
    </div>
    <div class=""text-center panel-body"">
        <button type=""submit"" class=""btn btn-sm btn-primary"">Get statistic</button>
    </div> 
");
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 27 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumBetweenDates.cshtml"
 if (Model != null)
{ 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-sm table-striped table-bordered m-2"">
        <thead>
            <tr>
                <th>From</th>
                <th>To</th>
                <th>Number of Orders</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>");
#nullable restore
#line 39 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumBetweenDates.cshtml"
               Write(Model.date1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumBetweenDates.cshtml"
               Write(Model.date2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 41 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumBetweenDates.cshtml"
               Write(Model.count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 45 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetOrderNumBetweenDates.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<order_number_statistic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
