#pragma checksum "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Countries\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9310fc4df59c4f0d76c8c95a044040e0ebb436f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Countries_Delete), @"mvc.1.0.view", @"/Views/Countries/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Countries/Delete.cshtml", typeof(AspNetCore.Views_Countries_Delete))]
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
#line 1 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Countries\Delete.cshtml"
using Open.Sentry.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9310fc4df59c4f0d76c8c95a044040e0ebb436f", @"/Views/Countries/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59898f1f519a9ae9f6b6759299108b34acce5888", @"/Views/_ViewImports.cshtml")]
    public class Views_Countries_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Open.Facade.Party.CountryView>
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
            BeginContext(69, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Countries\Delete.cshtml"
  
    ViewBag.Title = "Delete";
    ViewBag.SubTitle = "Country";
    ViewBag.Button = "Delete";
    Layout = "_DeletePartial";

#line default
#line hidden
            BeginContext(208, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(210, 270, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84b92afd9a1b46a8b00defd30e7c6801", async() => {
                BeginContext(216, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(219, 50, false);
#line 12 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Countries\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.Alpha3Code));

#line default
#line hidden
                EndContext();
                BeginContext(269, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(272, 50, false);
#line 13 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Countries\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.Alpha2Code));

#line default
#line hidden
                EndContext();
                BeginContext(322, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(325, 44, false);
#line 14 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Countries\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.Name));

#line default
#line hidden
                EndContext();
                BeginContext(369, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(372, 49, false);
#line 15 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Countries\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.ValidFrom));

#line default
#line hidden
                EndContext();
                BeginContext(421, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(424, 47, false);
#line 16 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Countries\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.ValidTo));

#line default
#line hidden
                EndContext();
                BeginContext(471, 2, true);
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
            BeginContext(480, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Actions", async() => {
                BeginContext(501, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(508, 40, false);
#line 20 "C:\Users\Stella.Leego.HLP030\RiderProjects\SiilSonicBank\Open\Sentry\Views\Countries\Delete.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
                EndContext();
                BeginContext(548, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(553, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Open.Facade.Party.CountryView> Html { get; private set; }
    }
}
#pragma warning restore 1591
