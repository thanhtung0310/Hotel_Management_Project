#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Room\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67269caa2084998293cc1aa092102c9f23d5b89d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Room_Details), @"mvc.1.0.view", @"/Views/Room/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67269caa2084998293cc1aa092102c9f23d5b89d", @"/Views/Room/Details.cshtml")]
    #nullable restore
    public class Views_Room_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DatabaseProvider.room>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Room\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>room</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Room\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.room_number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Room\Details.cshtml"
       Write(Html.DisplayFor(model => model.room_number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Room\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.room_type_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Room\Details.cshtml"
       Write(Html.DisplayFor(model => model.room_type_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Room\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.room_status_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 30 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Room\Details.cshtml"
       Write(Html.DisplayFor(model => model.room_status_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 913, "\"", 942, 1);
#nullable restore
#line 35 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Room\Details.cshtml"
WriteAttributeValue("", 928, Model.room_id, 928, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DatabaseProvider.room> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591