#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07c446eb41fbff932d69658cdfd9f5529e440bc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Emp_Info_GetEmployeeByName), @"mvc.1.0.view", @"/Views/Emp_Info/GetEmployeeByName.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Emp_Info/GetEmployeeByName.cshtml", typeof(AspNetCore.Views_Emp_Info_GetEmployeeByName))]
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
#line 1 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
using DatabaseProvider;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07c446eb41fbff932d69658cdfd9f5529e440bc8", @"/Views/Emp_Info/GetEmployeeByName.cshtml")]
    public class Views_Emp_Info_GetEmployeeByName : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<employee>>
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
            BeginContext(79, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
  
    ViewData["Title"] = "Get employee Information by Name";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(196, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(228, 41, true);
            WriteLiteral("\r\n<h1>Get employee\'s information by Name ");
            EndContext();
            BeginContext(269, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07c446eb41fbff932d69658cdfd9f5529e440bc84841", async() => {
                BeginContext(322, 4, true);
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
            BeginContext(330, 11, true);
            WriteLiteral("</h1>\r\n<h3>");
            EndContext();
            BeginContext(342, 18, false);
#line 12 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
Write(ViewBag.StatusCode);

#line default
#line hidden
            EndContext();
            BeginContext(360, 30, true);
            WriteLiteral("</h3>\r\n<h3 style=\"color:red;\">");
            EndContext();
            BeginContext(391, 15, false);
#line 13 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
                  Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(406, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
            BeginContext(413, 352, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "07c446eb41fbff932d69658cdfd9f5529e440bc87049", async() => {
                BeginContext(433, 325, true);
                WriteLiteral(@"
    <div class=""form-group"">
        <label for=""search_string"">Name:</label>
        <input class=""form-control"" name=""search_string"" placeholder=""Please enter name"" />
    </div>
    <div class=""text-center panel-body"">
        <button type=""submit"" class=""btn btn-sm btn-primary"">Get Employee</button>
    </div>
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
            BeginContext(765, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 24 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(793, 431, true);
            WriteLiteral(@"    <h2>Employee's information</h2>
    <table class=""table table-sm table-striped table-bordered m-2"">
        <thead>
            <tr>
                <th>Employee's ID</th>
                <th>Employee's name</th>
                <th>Employee's working floor</th>
                <th>Employee's date of birth</th>
                <th>Employee's contact number</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 38 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1281, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(1328, 11, false);
#line 41 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
                   Write(item.emp_id);

#line default
#line hidden
            EndContext();
            BeginContext(1339, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1371, 13, false);
#line 42 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
                   Write(item.emp_name);

#line default
#line hidden
            EndContext();
            BeginContext(1384, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1416, 17, false);
#line 43 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
                   Write(item.emp_position);

#line default
#line hidden
            EndContext();
            BeginContext(1433, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1465, 12, false);
#line 44 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
                   Write(item.emp_dob);

#line default
#line hidden
            EndContext();
            BeginContext(1477, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1509, 23, false);
#line 45 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
                   Write(item.emp_contact_number);

#line default
#line hidden
            EndContext();
            BeginContext(1532, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 47 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
            }

#line default
#line hidden
            BeginContext(1577, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 50 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Emp_Info\GetEmployeeByName.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
