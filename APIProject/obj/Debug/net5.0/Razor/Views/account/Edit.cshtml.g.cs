#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Account\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ddda9f1af835c22ed07531ae7cbd0f58c890b770"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Edit), @"mvc.1.0.view", @"/Views/Account/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ddda9f1af835c22ed07531ae7cbd0f58c890b770", @"/Views/Account/Edit.cshtml")]
    #nullable restore
    public class Views_Account_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DatabaseProvider.account>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Account\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>account</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""acc_id"" />
            <div class=""form-group"">
                <label asp-for=""emp_id"" class=""control-label""></label>
                <input asp-for=""emp_id"" class=""form-control"" />
                <span asp-validation-for=""emp_id"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""customer_id"" class=""control-label""></label>
                <input asp-for=""customer_id"" class=""form-control"" />
                <span asp-validation-for=""customer_id"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""acc_username"" class=""control-label""></label>
                <input asp-for=""acc_username"" class=""form-control"" />
              ");
            WriteLiteral(@"  <span asp-validation-for=""acc_username"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""acc_password"" class=""control-label""></label>
                <input asp-for=""acc_password"" class=""form-control"" />
                <span asp-validation-for=""acc_password"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""role_id"" class=""control-label""></label>
                <input asp-for=""role_id"" class=""form-control"" />
                <span asp-validation-for=""role_id"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 54 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Account\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DatabaseProvider.account> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
