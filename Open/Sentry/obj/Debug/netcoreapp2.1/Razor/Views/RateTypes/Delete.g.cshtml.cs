#pragma checksum "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c7f446872c9e820d565e1fdd6959ff1c165dab4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RateTypes_Delete), @"mvc.1.0.view", @"/Views/RateTypes/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/RateTypes/Delete.cshtml", typeof(AspNetCore.Views_RateTypes_Delete))]
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
#line 1 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
using Open.Sentry.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c7f446872c9e820d565e1fdd6959ff1c165dab4", @"/Views/RateTypes/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59898f1f519a9ae9f6b6759299108b34acce5888", @"/Views/_ViewImports.cshtml")]
    public class Views_RateTypes_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Open.Facade.Quantity.RateTypeView>
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
            BeginContext(73, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
  
    ViewBag.Title = "Delete";
    ViewBag.SubTitle = "Exchange Rate Type";
    ViewBag.Button = "Delete";
    Layout = "_DeletePartial";

#line default
#line hidden
            BeginContext(223, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(225, 330, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "95c1e460f40e4cb4a8cda2673a615ec0", async() => {
                BeginContext(231, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(238, 42, false);
#line 12 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.ID));

#line default
#line hidden
                EndContext();
                BeginContext(280, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(287, 44, false);
#line 13 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.Code));

#line default
#line hidden
                EndContext();
                BeginContext(331, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(338, 44, false);
#line 14 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.Name));

#line default
#line hidden
                EndContext();
                BeginContext(382, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(385, 51, false);
#line 15 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.Description));

#line default
#line hidden
                EndContext();
                BeginContext(436, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(443, 49, false);
#line 16 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.ValidFrom));

#line default
#line hidden
                EndContext();
                BeginContext(492, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(499, 47, false);
#line 17 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
Write(Html.ViewingControlsFor(model => model.ValidTo));

#line default
#line hidden
                EndContext();
                BeginContext(546, 2, true);
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
            BeginContext(555, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Actions", async() => {
                BeginContext(576, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(583, 54, false);
#line 21 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.ID }));

#line default
#line hidden
                EndContext();
                BeginContext(637, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(644, 40, false);
#line 22 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\RateTypes\Delete.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
                EndContext();
                BeginContext(684, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Open.Facade.Quantity.RateTypeView> Html { get; private set; }
    }
}
#pragma warning restore 1591
