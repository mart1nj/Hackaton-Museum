#pragma checksum "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c03b9d14fe618adb92a3f540b75148dedfbc68aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c03b9d14fe618adb92a3f540b75148dedfbc68aa", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59898f1f519a9ae9f6b6759299108b34acce5888", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "SonicBank";

#line default
#line hidden
            BeginContext(45, 36, true);
            WriteLiteral("\r\n<div class =\"jumbotron\">\r\n    <h1>");
            EndContext();
            BeginContext(82, 17, false);
#line 6 "D:\Documents\Rider\Source\SiilSonicBank\Open\Sentry\Views\Home\Index.cshtml"
   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(99, 1009, true);
            WriteLiteral(@"</h1>
</div>

<div class=""row"">
    <div class=""col-md-4"">
        <h2>Welcome, customer_name</h2>
        <table style=""width:100%"">
            <tr>
                <th>Account Number</th>
                <th>Balance</th>
            </tr>
            <tr>
                <td>EE1234567890</td>
                <td>115,67 €</td>
            </tr>
            <tr>
                <td>EE0987655432321</td>
                <td>0,01 €</td>
            </tr>
        </table>
    </div>
        <div class=""col-md-2"" style=""text-align: end"">
            <h3>Shortcuts</h3>
            <p>
                <a class=""btn btn-default""
                   href=""../Home/Transaction"">Account transactions &raquo;</a>
                <a class=""btn btn-default""
                   href=""http://google.com"">Make a transaction &raquo;</a>
                <a class=""btn btn-default""
                   href=""http://google.com"">My profile &raquo;</a>
            </p>
        </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
