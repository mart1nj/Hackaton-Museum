#pragma checksum "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ac052a19ef36b36e91b044c7e0c96be864ea93d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payments_Delete), @"mvc.1.0.view", @"/Views/Payments/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Payments/Delete.cshtml", typeof(AspNetCore.Views_Payments_Delete))]
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
#line 1 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 1 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
using Open.Sentry.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac052a19ef36b36e91b044c7e0c96be864ea93d4", @"/Views/Payments/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59898f1f519a9ae9f6b6759299108b34acce5888", @"/Views/_ViewImports.cshtml")]
    public class Views_Payments_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Open.Facade.Quantity.PaymentView>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(72, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
  
    ViewBag.Title = "Delete";
    ViewBag.SubTitle = "Payment";
    ViewBag.Button = "Delete";
    Layout = "_DeletePartial";

#line default
#line hidden
            BeginContext(211, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(213, 278, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f64d50cffe054a80a36d40f0607fef26", async() => {
                BeginContext(219, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(222, 38, false);
#line 12 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
Write(Html.ViewingControlsFor(x => x.Amount));

#line default
#line hidden
                EndContext();
                BeginContext(260, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(263, 42, false);
#line 13 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
Write(Html.ViewingControlsFor(x => x.CurrencyID));

#line default
#line hidden
                EndContext();
                BeginContext(305, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(308, 47, false);
#line 14 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
Write(Html.ViewingControlsFor(x => x.PaymentMethodID));

#line default
#line hidden
                EndContext();
                BeginContext(355, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(358, 39, false);
#line 15 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
Write(Html.ViewingControlsFor(x => x.DateDue));

#line default
#line hidden
                EndContext();
                BeginContext(397, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(400, 40, false);
#line 16 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
Write(Html.ViewingControlsFor(x => x.DateMade));

#line default
#line hidden
                EndContext();
                BeginContext(440, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(443, 39, false);
#line 17 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
Write(Html.ViewingControlsFor(x => x.ValidTo));

#line default
#line hidden
                EndContext();
                BeginContext(482, 2, true);
                WriteLiteral("\r\n");
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
            BeginContext(491, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Actions", async() => {
                BeginContext(512, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(519, 54, false);
#line 21 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.ID }));

#line default
#line hidden
                EndContext();
                BeginContext(573, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(580, 40, false);
#line 22 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Payments\Delete.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
                EndContext();
                BeginContext(620, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Open.Facade.Quantity.PaymentView> Html { get; private set; }
    }
}
#pragma warning restore 1591
