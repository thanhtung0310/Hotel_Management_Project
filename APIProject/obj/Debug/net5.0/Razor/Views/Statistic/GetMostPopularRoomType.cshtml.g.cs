#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetMostPopularRoomType.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f064d1dec3e15a21da6e484e10a5662acf8ef61f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistic_GetMostPopularRoomType), @"mvc.1.0.view", @"/Views/Statistic/GetMostPopularRoomType.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Statistic/GetMostPopularRoomType.cshtml", typeof(AspNetCore.Views_Statistic_GetMostPopularRoomType))]
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
#line 1 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetMostPopularRoomType.cshtml"
using Entity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f064d1dec3e15a21da6e484e10a5662acf8ef61f", @"/Views/Statistic/GetMostPopularRoomType.cshtml")]
    public class Views_Statistic_GetMostPopularRoomType : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<room_popular_statistic>>
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
#line 4 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetMostPopularRoomType.cshtml"
  
    ViewData["Title"] = "Most popular room type";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(176, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(222, 54, true);
            WriteLiteral("\r\n<h1><a id=\"printedHeader\">Most popular room type</a>");
            EndContext();
            BeginContext(276, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f064d1dec3e15a21da6e484e10a5662acf8ef61f4326", async() => {
                BeginContext(329, 4, true);
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
            BeginContext(337, 127, true);
            WriteLiteral("</h1>\r\n\r\n<input class=\"btn btn-sm btn-secondary\" type=\"button\" value=\"Print report\" onclick=\"printDiv()\" />\r\n<br />\r\n<br />\r\n\r\n");
            EndContext();
#line 17 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetMostPopularRoomType.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(488, 287, true);
            WriteLiteral(@"    <div id=""printedDiv"">
        <table class=""table"">
            <thead>
                <tr>
                    <th>Room type's name</th>
                    <th>Number of customers had used the room type</th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 28 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetMostPopularRoomType.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(840, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(895, 19, false);
#line 31 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetMostPopularRoomType.cshtml"
                       Write(item.room_type_name);

#line default
#line hidden
            EndContext();
            BeginContext(914, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(950, 10, false);
#line 32 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetMostPopularRoomType.cshtml"
                       Write(item.count);

#line default
#line hidden
            EndContext();
            BeginContext(960, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 34 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetMostPopularRoomType.cshtml"
                }

#line default
#line hidden
            BeginContext(1013, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
#line 38 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Statistic\GetMostPopularRoomType.cshtml"
}

#line default
#line hidden
            BeginContext(1068, 606, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<room_popular_statistic>> Html { get; private set; }
    }
}
#pragma warning restore 1591
