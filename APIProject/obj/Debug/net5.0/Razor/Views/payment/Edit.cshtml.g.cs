#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Payment\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50c5f42e766ef1d6caf436b6e7e6180e12185b81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment_Edit), @"mvc.1.0.view", @"/Views/Payment/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50c5f42e766ef1d6caf436b6e7e6180e12185b81", @"/Views/Payment/Edit.cshtml")]
    #nullable restore
    public class Views_Payment_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DatabaseProvider.payment>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Payment\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>payment</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""payment_id"" />
            <div class=""form-group"">
                <label asp-for=""payment_type_id"" class=""control-label""></label>
                <input asp-for=""payment_type_id"" class=""form-control"" />
                <span asp-validation-for=""payment_type_id"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""reception_id"" class=""control-label""></label>
                <input asp-for=""reception_id"" class=""form-control"" />
                <span asp-validation-for=""reception_id"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""payment_amount"" class=""control-label""></label>
                <input asp-for=""payment_amount"" c");
            WriteLiteral(@"lass=""form-control"" />
                <span asp-validation-for=""payment_amount"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""payment_date"" class=""control-label""></label>
                <input asp-for=""payment_date"" class=""form-control"" />
                <span asp-validation-for=""payment_date"" class=""text-danger""></span>
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
#line 49 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Payment\Edit.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DatabaseProvider.payment> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
