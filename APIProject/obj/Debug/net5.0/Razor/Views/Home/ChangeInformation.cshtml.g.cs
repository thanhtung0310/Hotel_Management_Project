#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Home\ChangeInformation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ee51c75428d5535fdd29c9d767c66b6931e80c2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ChangeInformation), @"mvc.1.0.view", @"/Views/Home/ChangeInformation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ChangeInformation.cshtml", typeof(AspNetCore.Views_Home_ChangeInformation))]
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
#line 1 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Home\ChangeInformation.cshtml"
using Entity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ee51c75428d5535fdd29c9d767c66b6931e80c2", @"/Views/Home/ChangeInformation.cshtml")]
    public class Views_Home_ChangeInformation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserSession>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangeInformation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Home\ChangeInformation.cshtml"
  
    ViewData["Title"] = "Change user's information";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(179, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(201, 32, true);
            WriteLiteral("\r\n<h1>Change user\'s information ");
            EndContext();
            BeginContext(233, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ee51c75428d5535fdd29c9d767c66b6931e80c25083", async() => {
                BeginContext(288, 4, true);
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
            BeginContext(296, 9, true);
            WriteLiteral("</h1>\r\n\r\n");
            EndContext();
#line 13 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Home\ChangeInformation.cshtml"
 if (ViewBag.StatusCode == "Success" && Model != null)
{

#line default
#line hidden
            BeginContext(364, 1003, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ee51c75428d5535fdd29c9d767c66b6931e80c26746", async() => {
                BeginContext(415, 141, true);
                WriteLiteral("\r\n    <div class=\"form-group\">\r\n        <label for=\"acc_username\">Username: </label>\r\n        <input class=\"form-control\" name=\"acc_username\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 556, "\"", 583, 1);
#line 18 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Home\ChangeInformation.cshtml"
WriteAttributeValue("", 564, Model.acc_username, 564, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(584, 158, true);
                WriteLiteral(" readonly />\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"acc_name\">Full name: </label>\r\n        <input class=\"form-control\" name=\"acc_name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 742, "\"", 765, 1);
#line 22 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Home\ChangeInformation.cshtml"
WriteAttributeValue("", 750, Model.acc_name, 750, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(766, 160, true);
                WriteLiteral(" required />\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"acc_dob\">Date of birth: </label>\r\n        <input class=\"form-control\" name=\"acc_dob\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 926, "\"", 948, 1);
#line 26 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Home\ChangeInformation.cshtml"
WriteAttributeValue("", 934, Model.acc_dob, 934, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(949, 183, true);
                WriteLiteral(" readonly />\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label for=\"acc_contact_number\">Contact number: </label>\r\n        <input class=\"form-control\" name=\"acc_contact_number\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1132, "\"", 1165, 1);
#line 30 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Home\ChangeInformation.cshtml"
WriteAttributeValue("", 1140, Model.acc_contact_number, 1140, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1166, 194, true);
                WriteLiteral(" required />\r\n    </div>\r\n    <div class=\"text-center panel-body\">\r\n        <button type=\"submit\" onclick=\"RefreshPage()\" class=\"btn btn-sm btn-primary\">Change information</button>\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1367, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 36 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Home\ChangeInformation.cshtml"
}

#line default
#line hidden
            BeginContext(1372, 81, true);
            WriteLiteral("\r\n<script>\r\nfunction RefreshPage()\r\n{\r\n    window.location.reload()\r\n}\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserSession> Html { get; private set; }
    }
}
#pragma warning restore 1591
