#pragma checksum "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3cd13d55b65bd4f50a6a4a7f3dc86e8bae57930f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PaymentMethods__ViewCreditCard), @"mvc.1.0.view", @"/Views/PaymentMethods/_ViewCreditCard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PaymentMethods/_ViewCreditCard.cshtml", typeof(AspNetCore.Views_PaymentMethods__ViewCreditCard))]
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
#line 1 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 1 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
using Open.Sentry.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3cd13d55b65bd4f50a6a4a7f3dc86e8bae57930f", @"/Views/PaymentMethods/_ViewCreditCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59898f1f519a9ae9f6b6759299108b34acce5888", @"/Views/_ViewImports.cshtml")]
    public class Views_PaymentMethods__ViewCreditCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Open.Facade.Quantity.CreditCardView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(75, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(78, 42, false);
#line 4 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.NameOnCard));

#line default
#line hidden
            EndContext();
            BeginContext(120, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(123, 40, false);
#line 5 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.CardName));

#line default
#line hidden
            EndContext();
            BeginContext(163, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(166, 42, false);
#line 6 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.CardNumber));

#line default
#line hidden
            EndContext();
            BeginContext(208, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(211, 42, false);
#line 7 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.CurrencyID));

#line default
#line hidden
            EndContext();
            BeginContext(253, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(256, 43, false);
#line 8 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.CreditLimit));

#line default
#line hidden
            EndContext();
            BeginContext(299, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(302, 42, false);
#line 9 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.DailyLimit));

#line default
#line hidden
            EndContext();
            BeginContext(344, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(347, 46, false);
#line 10 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.BillingAddress));

#line default
#line hidden
            EndContext();
            BeginContext(393, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(396, 43, false);
#line 11 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.IssueNumber));

#line default
#line hidden
            EndContext();
            BeginContext(439, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(442, 48, false);
#line 12 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.VerificationCode));

#line default
#line hidden
            EndContext();
            BeginContext(490, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(493, 41, false);
#line 13 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.ValidFrom));

#line default
#line hidden
            EndContext();
            BeginContext(534, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(537, 42, false);
#line 14 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\PaymentMethods\_ViewCreditCard.cshtml"
Write(Html.ViewingControlsFor(a => a.ExpireDate));

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Open.Facade.Quantity.CreditCardView> Html { get; private set; }
    }
}
#pragma warning restore 1591
