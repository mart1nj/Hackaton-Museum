#pragma checksum "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Countries\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a8b753ad96fbc980bc93a80afb8151c690f4563"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Countries_Create), @"mvc.1.0.view", @"/Views/Countries/Create.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Countries/Create.cshtml", typeof(AspNetCore.Views_Countries_Create))]
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
#line 1 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Countries\Create.cshtml"
using Open.Sentry.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a8b753ad96fbc980bc93a80afb8151c690f4563", @"/Views/Countries/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59898f1f519a9ae9f6b6759299108b34acce5888", @"/Views/_ViewImports.cshtml")]
    public class Views_Countries_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Open.Facade.Party.CountryView>
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
#line 4 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Countries\Create.cshtml"
  
    ViewBag.Title = "Create";
    ViewBag.SubTitle = "Country";
    ViewBag.Button = "Create";
    Layout = "_EditPartial";

#line default
#line hidden
            BeginContext(206, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(208, 290, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d3182be58c5749a4b97b614118cfb68c", async() => {
                BeginContext(214, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(221, 50, false);
#line 12 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Countries\Create.cshtml"
Write(Html.EditingControlsFor(model => model.Alpha3Code));

#line default
#line hidden
                EndContext();
                BeginContext(271, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(278, 50, false);
#line 13 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Countries\Create.cshtml"
Write(Html.EditingControlsFor(model => model.Alpha2Code));

#line default
#line hidden
                EndContext();
                BeginContext(328, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(335, 44, false);
#line 14 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Countries\Create.cshtml"
Write(Html.EditingControlsFor(model => model.Name));

#line default
#line hidden
                EndContext();
                BeginContext(379, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(386, 49, false);
#line 15 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Countries\Create.cshtml"
Write(Html.EditingControlsFor(model => model.ValidFrom));

#line default
#line hidden
                EndContext();
                BeginContext(435, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(442, 47, false);
#line 16 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Countries\Create.cshtml"
Write(Html.EditingControlsFor(model => model.ValidTo));

#line default
#line hidden
                EndContext();
                BeginContext(489, 2, true);
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
            BeginContext(498, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Actions", async() => {
                BeginContext(519, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(526, 40, false);
#line 20 "C:\Users\birgi\Documents\Äriinfotehnoloogia\infosüs -  andmebaas\Open\Open\Sentry\Views\Countries\Create.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
                EndContext();
                BeginContext(566, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(571, 4, true);
            WriteLiteral("\r\n\r\n");
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
