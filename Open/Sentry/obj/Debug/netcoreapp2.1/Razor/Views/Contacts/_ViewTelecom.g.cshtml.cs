#pragma checksum "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92c9db690157e3b16fc995fbc19b1aa39b385772"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contacts__ViewTelecom), @"mvc.1.0.view", @"/Views/Contacts/_ViewTelecom.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Contacts/_ViewTelecom.cshtml", typeof(AspNetCore.Views_Contacts__ViewTelecom))]
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
#line 1 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
using Open.Sentry.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92c9db690157e3b16fc995fbc19b1aa39b385772", @"/Views/Contacts/_ViewTelecom.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59898f1f519a9ae9f6b6759299108b34acce5888", @"/Views/_ViewImports.cshtml")]
    public class Views_Contacts__ViewTelecom : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Open.Facade.Party.TelecomAddressView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(76, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(79, 43, false);
#line 4 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
Write(Html.ViewingControlsFor(a => a.CountryCode));

#line default
#line hidden
            EndContext();
            BeginContext(122, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(125, 59, false);
#line 5 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
Write(Html.ViewingControlsFor(a => a.NationalDirectDialingPrefix));

#line default
#line hidden
            EndContext();
            BeginContext(184, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(187, 40, false);
#line 6 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
Write(Html.ViewingControlsFor(a => a.AreaCode));

#line default
#line hidden
            EndContext();
            BeginContext(227, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(230, 38, false);
#line 7 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
Write(Html.ViewingControlsFor(a => a.Number));

#line default
#line hidden
            EndContext();
            BeginContext(268, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(271, 41, false);
#line 8 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
Write(Html.ViewingControlsFor(a => a.Extension));

#line default
#line hidden
            EndContext();
            BeginContext(312, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(315, 42, false);
#line 9 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
Write(Html.ViewingControlsFor(a => a.DeviceType));

#line default
#line hidden
            EndContext();
            BeginContext(357, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(360, 41, false);
#line 10 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
Write(Html.ViewingControlsFor(a => a.ValidFrom));

#line default
#line hidden
            EndContext();
            BeginContext(401, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(404, 39, false);
#line 11 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
Write(Html.ViewingControlsFor(a => a.ValidTo));

#line default
#line hidden
            EndContext();
            BeginContext(443, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 13 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
 if (Model.RegisteredInAddresses.Count > 0) {

#line default
#line hidden
            BeginContext(494, 38, true);
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(533, 84, false);
#line 15 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
   Write(Html.LabelFor(m => m.RegisteredInAddresses, new {@class = "control-label col-md-2"}));

#line default
#line hidden
            EndContext();
            BeginContext(617, 95, true);
            WriteLiteral(",\r\n        <div class=\"col-md-4\" style=\"margin-top: 10px\">\r\n            <table class=\"table\">\r\n");
            EndContext();
#line 18 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
                   var x = Model.RegisteredInAddresses.FirstOrDefault(); 

#line default
#line hidden
            BeginContext(788, 71, true);
            WriteLiteral("                <thead>\r\n                <tr>\r\n                    <th>");
            EndContext();
            BeginContext(860, 29, false);
#line 21 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
                   Write(Html.LabelFor(a => x.Contact));

#line default
#line hidden
            EndContext();
            BeginContext(889, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(921, 31, false);
#line 22 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
                   Write(Html.LabelFor(a => x.ValidFrom));

#line default
#line hidden
            EndContext();
            BeginContext(952, 31, true);
            WriteLiteral("</th>\r\n                    <th>");
            EndContext();
            BeginContext(984, 29, false);
#line 23 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
                   Write(Html.LabelFor(a => x.ValidTo));

#line default
#line hidden
            EndContext();
            BeginContext(1013, 81, true);
            WriteLiteral("</th>\r\n                </tr>\r\n                </thead>\r\n                <tbody>\r\n");
            EndContext();
#line 27 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
                 foreach (var item in Model.RegisteredInAddresses) {

#line default
#line hidden
            BeginContext(1164, 54, true);
            WriteLiteral("                    <tr>\r\n                        <td>");
            EndContext();
            BeginContext(1219, 34, false);
#line 29 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
                       Write(Html.DisplayFor(a => item.Contact));

#line default
#line hidden
            EndContext();
            BeginContext(1253, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1289, 36, false);
#line 30 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
                       Write(Html.DisplayFor(a => item.ValidFrom));

#line default
#line hidden
            EndContext();
            BeginContext(1325, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(1361, 34, false);
#line 31 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
                       Write(Html.DisplayFor(a => item.ValidTo));

#line default
#line hidden
            EndContext();
            BeginContext(1395, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 33 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
                }

#line default
#line hidden
            BeginContext(1448, 76, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 38 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Contacts\_ViewTelecom.cshtml"
}

#line default
#line hidden
            BeginContext(1527, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Open.Facade.Party.TelecomAddressView> Html { get; private set; }
    }
}
#pragma warning restore 1591
