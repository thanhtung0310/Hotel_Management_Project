#pragma checksum "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95eb860b165119174ec2f2880d44ea2df2b41569"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Function_CheckOutPaidRoomResult), @"mvc.1.0.view", @"/Views/Function/CheckOutPaidRoomResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Function/CheckOutPaidRoomResult.cshtml", typeof(AspNetCore.Views_Function_CheckOutPaidRoomResult))]
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
#line 1 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
using Entity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95eb860b165119174ec2f2880d44ea2df2b41569", @"/Views/Function/CheckOutPaidRoomResult.cshtml")]
    public class Views_Function_CheckOutPaidRoomResult : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<room_check_out>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckOut", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
  
    ViewData["Title"] = "Check out Paid room";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(173, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(198, 24, true);
            WriteLiteral("\r\n<h1>Check out Results ");
            EndContext();
            BeginContext(222, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95eb860b165119174ec2f2880d44ea2df2b415694264", async() => {
                BeginContext(278, 4, true);
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
            BeginContext(286, 11, true);
            WriteLiteral("</h1>\r\n<h3>");
            EndContext();
            BeginContext(298, 18, false);
#line 12 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
Write(ViewBag.StatusCode);

#line default
#line hidden
            EndContext();
            BeginContext(316, 30, true);
            WriteLiteral("</h3>\r\n<h3 style=\"color:red;\">");
            EndContext();
            BeginContext(347, 15, false);
#line 13 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
                  Write(ViewBag.Message);

#line default
#line hidden
            EndContext();
            BeginContext(362, 9, true);
            WriteLiteral("</h3>\r\n\r\n");
            EndContext();
#line 15 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
 if (@ViewBag.StatusCode == "Success" && Model != null)
{

#line default
#line hidden
            BeginContext(431, 89, true);
            WriteLiteral("    <h3>You have checked out room successfully! </h3>\r\n    <h5>\r\n        Customer ID:    ");
            EndContext();
            BeginContext(521, 17, false);
#line 19 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
                   Write(Model.customer_id);

#line default
#line hidden
            EndContext();
            BeginContext(538, 23, true);
            WriteLiteral("\r\n    </h5>\r\n    <h5>\r\n");
            EndContext();
#line 22 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
          
            string room_number = "";
            if (Model.room_id == 1)
                room_number = "Room 101";
            else if (Model.room_id == 2)
                room_number = "Room 102";
            else if (Model.room_id == 3)
                room_number = "Room 103";
            else if (Model.room_id == 4)
                room_number = "Room 104";
            else if (Model.room_id == 5)
                room_number = "Room 105";
            else if (Model.room_id == 6)
                room_number = "Room 106";
            else if (Model.room_id == 7)
                room_number = "Room 201";
            else if (Model.room_id == 8)
                room_number = "Room 202";
            else if (Model.room_id == 9)
                room_number = "Room 203";
            else if (Model.room_id == 10)
                room_number = "Room 204";
            else if (Model.room_id == 11)
                room_number = "Room 205";
            else if (Model.room_id == 12)
                room_number = "Room 206";
            else if (Model.room_id == 13)
                room_number = "Room 301";
            else if (Model.room_id == 14)
                room_number = "Room 302";
            else if (Model.room_id == 15)
                room_number = "Room 303";
            else if (Model.room_id == 16)
                room_number = "Room 304";
            else if (Model.room_id == 17)
                room_number = "Room 305";
            else if (Model.room_id == 18)
                room_number = "Room 306";
        

#line default
#line hidden
            BeginContext(2156, 25, true);
            WriteLiteral("        Room number:     ");
            EndContext();
            BeginContext(2182, 11, false);
#line 61 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
                    Write(room_number);

#line default
#line hidden
            EndContext();
            BeginContext(2193, 23, true);
            WriteLiteral("\r\n    </h5>\r\n    <h5>\r\n");
            EndContext();
#line 64 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
          
            string room_type_name = "";
            if (Model.room_type_id == 1)
                room_type_name = "King Room";
            else if (Model.room_type_id == 2)
                room_type_name = "Queen Room";
            else if (Model.room_type_id == 3)
                room_type_name = "4-people Family Room";
            else if (Model.room_type_id == 4)
                room_type_name = "3-people Family Room";
            else if (Model.room_type_id == 5)
                room_type_name = "Single Room";
            else if (Model.room_type_id == 6)
                room_type_name = "Couple Room";
            else if (Model.room_type_id == 7)
                room_type_name = "4-Bunk Room";
        

#line default
#line hidden
            BeginContext(2962, 23, true);
            WriteLiteral("        Room type:     ");
            EndContext();
            BeginContext(2986, 14, false);
#line 81 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
                  Write(room_type_name);

#line default
#line hidden
            EndContext();
            BeginContext(3000, 49, true);
            WriteLiteral("\r\n    </h5>\r\n    <h5>\r\n        Check-in date:    ");
            EndContext();
            BeginContext(3050, 19, false);
#line 84 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
                     Write(Model.check_in_date);

#line default
#line hidden
            EndContext();
            BeginContext(3069, 50, true);
            WriteLiteral("\r\n    </h5>\r\n    <h5>\r\n        Check-out date:    ");
            EndContext();
            BeginContext(3120, 20, false);
#line 87 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
                      Write(Model.check_out_date);

#line default
#line hidden
            EndContext();
            BeginContext(3140, 23, true);
            WriteLiteral("\r\n    </h5>\r\n    <h5>\r\n");
            EndContext();
#line 90 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
          
            string payment_type_name = "";
            if (Model.payment_type_id == 1)
                payment_type_name = "Cash";
            else if (Model.payment_type_id == 2)
                payment_type_name = "Credit card";
            else if (Model.payment_type_id == 3)
                payment_type_name = "Debit card";

        

#line default
#line hidden
            BeginContext(3525, 26, true);
            WriteLiteral("        Payment type:     ");
            EndContext();
            BeginContext(3552, 17, false);
#line 100 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
                     Write(payment_type_name);

#line default
#line hidden
            EndContext();
            BeginContext(3569, 50, true);
            WriteLiteral("\r\n    </h5>\r\n    <h5>\r\n        Payment amount:    ");
            EndContext();
            BeginContext(3620, 20, false);
#line 103 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
                      Write(Model.payment_amount);

#line default
#line hidden
            EndContext();
            BeginContext(3640, 52, true);
            WriteLiteral(" VND\r\n    </h5>\r\n    <h5>\r\n        Payment date:    ");
            EndContext();
            BeginContext(3693, 18, false);
#line 106 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
                    Write(Model.payment_date);

#line default
#line hidden
            EndContext();
            BeginContext(3711, 13, true);
            WriteLiteral("\r\n    </h5>\r\n");
            EndContext();
            BeginContext(3726, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(3730, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95eb860b165119174ec2f2880d44ea2df2b4156913829", async() => {
                BeginContext(3786, 24, true);
                WriteLiteral("Return to Check out Page");
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
            BeginContext(3814, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 110 "D:\Tung\VMO\Tuan 3\Projects\Hotel_Management_Project\APIProject\Views\Function\CheckOutPaidRoomResult.cshtml"
}

#line default
#line hidden
            BeginContext(3819, 91, true);
            WriteLiteral("\r\n<style>\r\n    h5 {\r\n        color: orangered;\r\n        font-weight: bold;\r\n    }\r\n</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<room_check_out> Html { get; private set; }
    }
}
#pragma warning restore 1591
