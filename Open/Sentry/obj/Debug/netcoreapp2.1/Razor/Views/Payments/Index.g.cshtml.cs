#pragma checksum "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9eaa9340ed17a5ca81c1c0abbfd9d5ea7540b09c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payments_Index), @"mvc.1.0.view", @"/Views/Payments/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Payments/Index.cshtml", typeof(AspNetCore.Views_Payments_Index))]
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
#line 1 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 1 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
using Open.Sentry.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9eaa9340ed17a5ca81c1c0abbfd9d5ea7540b09c", @"/Views/Payments/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59898f1f519a9ae9f6b6759299108b34acce5888", @"/Views/_ViewImports.cshtml")]
    public class Views_Payments_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Open.Core.IPaginatedList<Open.Facade.Quantity.PaymentView>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
  
    ViewBag.Title = "Payments";
    Layout = "_IndexPartial";

#line default
#line hidden
            BeginContext(169, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Create", async() => {
                BeginContext(188, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(194, 35, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9570e027c276473ea1cf3dca86025c4a", async() => {
                    BeginContext(215, 10, true);
                    WriteLiteral("Create New");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(229, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(234, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(236, 1434, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60a693b4bfcc48c685028a552881fe73", async() => {
                BeginContext(242, 29, true);
                WriteLiteral("\r\n    <table class=\"table\">\r\n");
                EndContext();
#line 14 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
           var payment = Model.FirstOrDefault();

#line default
#line hidden
                BeginContext(322, 51, true);
                WriteLiteral("        <thead>\r\n            <tr>\r\n                ");
                EndContext();
                BeginContext(374, 69, false);
#line 17 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
           Write(Html.SortColumnHeaderFor(ViewData["SortAmount"], x => payment.Amount));

#line default
#line hidden
                EndContext();
                BeginContext(443, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(462, 75, false);
#line 18 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
           Write(Html.SortColumnHeaderFor(ViewData["SortCurrency"], x => payment.CurrencyID));

#line default
#line hidden
                EndContext();
                BeginContext(537, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(556, 78, false);
#line 19 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
           Write(Html.SortColumnHeaderFor(ViewData["SortMethod"], x => payment.PaymentMethodID));

#line default
#line hidden
                EndContext();
                BeginContext(634, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(653, 71, false);
#line 20 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
           Write(Html.SortColumnHeaderFor(ViewData["SortDateDue"], x => payment.DateDue));

#line default
#line hidden
                EndContext();
                BeginContext(724, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(743, 74, false);
#line 21 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
           Write(Html.SortColumnHeaderFor(ViewData["SortValidFrom"], x => payment.DateMade));

#line default
#line hidden
                EndContext();
                BeginContext(817, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(836, 71, false);
#line 22 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
           Write(Html.SortColumnHeaderFor(ViewData["SortValidTo"], x => payment.ValidTo));

#line default
#line hidden
                EndContext();
                BeginContext(907, 83, true);
                WriteLiteral("\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
                EndContext();
#line 27 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
                BeginContext(1047, 46, true);
                WriteLiteral("                <tr>\r\n                    <td>");
                EndContext();
                BeginContext(1094, 41, false);
#line 30 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
                EndContext();
                BeginContext(1135, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(1167, 45, false);
#line 31 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.CurrencyID));

#line default
#line hidden
                EndContext();
                BeginContext(1212, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(1244, 50, false);
#line 32 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PaymentMethodID));

#line default
#line hidden
                EndContext();
                BeginContext(1294, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(1326, 42, false);
#line 33 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DateDue));

#line default
#line hidden
                EndContext();
                BeginContext(1368, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(1400, 43, false);
#line 34 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.DateMade));

#line default
#line hidden
                EndContext();
                BeginContext(1443, 31, true);
                WriteLiteral("</td>\r\n                    <td>");
                EndContext();
                BeginContext(1475, 42, false);
#line 35 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ValidTo));

#line default
#line hidden
                EndContext();
                BeginContext(1517, 27, true);
                WriteLiteral("</td>\r\n                    ");
                EndContext();
                BeginContext(1545, 46, false);
#line 36 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
               Write(Html.EditDetailDeleteFor(modelItem => item.ID));

#line default
#line hidden
                EndContext();
                BeginContext(1591, 25, true);
                WriteLiteral("\r\n                </tr>\r\n");
                EndContext();
#line 38 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Payments\Index.cshtml"
            }

#line default
#line hidden
                BeginContext(1631, 32, true);
                WriteLiteral("        </tbody>\r\n    </table>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Open.Core.IPaginatedList<Open.Facade.Quantity.PaymentView>> Html { get; private set; }
    }
}
#pragma warning restore 1591
