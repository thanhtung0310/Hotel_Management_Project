#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\RoomStatus\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54c6c9d6a37d4adf6ec79865cbe0e16895820a54"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RoomStatus_Index), @"mvc.1.0.view", @"/Views/RoomStatus/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54c6c9d6a37d4adf6ec79865cbe0e16895820a54", @"/Views/RoomStatus/Index.cshtml")]
    #nullable restore
    public class Views_RoomStatus_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DatabaseProvider.roomStatus>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\RoomStatus\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\RoomStatus\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.room_status_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 23 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\RoomStatus\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 26 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\RoomStatus\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.room_status_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 643, "\"", 678, 1);
#nullable restore
#line 29 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\RoomStatus\Index.cshtml"
WriteAttributeValue("", 658, item.room_status_id, 658, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 731, "\"", 766, 1);
#nullable restore
#line 30 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\RoomStatus\Index.cshtml"
WriteAttributeValue("", 746, item.room_status_id, 746, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 821, "\"", 856, 1);
#nullable restore
#line 31 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\RoomStatus\Index.cshtml"
WriteAttributeValue("", 836, item.room_status_id, 836, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 34 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\RoomStatus\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DatabaseProvider.roomStatus>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
