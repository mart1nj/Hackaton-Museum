using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry.Extensions;

namespace Open.Tests.Sentry.Extensions {
    [TestClass]
    public class HtmlExtensionTests : BaseTests {
       // private IHtmlHelper<AccountView> helper;
        private StringWriter writer;

        [TestInitialize]
        public override void TestInitialize() {
            base.TestInitialize();
            type = typeof(HtmlExtension);
           // helper = new mockHtmlHelper<AccountView>();
            writer = new StringWriter();
        }

        [TestMethod]
        public void EditingControlsForEnumTest() {
           /* var h = new mockHtmlHelper<TelecomAddressView>();
            var v = h.EditingControlsForEnum(x => x.DeviceType);
            v.WriteTo(writer, new HtmlTestEncoder());
            const string expected =
                "<div class=\"form-group\">" +
                "LabelFor DeviceType { class = control-label col-md-4 }" +
                "<div class=\"col-md-4\">" +
                "DropDownListFor DeviceType { class = form-control }" +
                "ValidationMessageFor DeviceType { class = text-danger }" +
                "</div>" +
                "</div>";
            Assert.AreEqual(expected, writer.ToString());*/
            Assert.Inconclusive();
        }

        [TestMethod]
        public void EditingControlsForTest() {
            /*var v = helper.EditingControlsFor(x => x.Balance);
            v.WriteTo(writer, new HtmlTestEncoder());
            const string expected =
                "<div class=\"form-group\">" +
                "LabelFor Balance { class = control-label col-md-4, style = font-weight: bold }" +
                "<div class=\"col-md-4\">" +
                "EditorFor Balance { htmlAttributes = { class = form-control } }" +
                "ValidationMessageFor Balance { class = text-danger }" +
                "</div>" +
                "</div>";
            Assert.AreEqual(expected, writer.ToString());*/
            Assert.Inconclusive();
        }

        [TestMethod]
        public void ViewingControlsForTest() {
         /*   var v = helper.ViewingControlsFor(x => x.Balance);
            v.WriteTo(writer, new HtmlTestEncoder());
            const string expected =
                "<div class=\"form-group\">" +
                "LabelFor Balance { class = control-label col-md-4, style = font-weight: bold }" +
                "<div class=\"col-md-10\" style=\"margin-top:10px\">" +
                "DisplayFor Balance { htmlAttributes = { class = form-control } }" +
                "</div>" +
                "</div>";
            Assert.AreEqual(expected, writer.ToString());*/
            Assert.Inconclusive();
        }

        [TestMethod]
        public void SortColumnHeaderForTest() {
            /* var s = GetRandom.String();
             var v = helper.SortColumnHeaderFor(x => x.Balance, s);
             v.WriteTo(writer, new HtmlTestEncoder());
             var expected =
                 "<th>" +
                 "ActionLink Index { SortOrder = " +
                 s +
                 " }" +
                 "</th>";
             Assert.AreEqual(expected, writer.ToString());*/
            Assert.Inconclusive();

        }

        [TestMethod]
        public void EditDetailDeleteForTest() {
            /* var v = helper.EditDetailDeleteFor(x => x.Balance);
             v.WriteTo(writer, new HtmlTestEncoder());
             const string expected =
                 "<th>" +
                 "ActionLink Edit { id = Balance }" +
                 " | " +
                 "ActionLink Details { id = Balance }" +
                 " | " +
                 "ActionLink Delete { id = Balance }" +
                 "</th>";
             Assert.AreEqual(expected, writer.ToString());*/
            Assert.Inconclusive();

        }

        [TestMethod]
        public void EditingControlsForCountryTest() {
            /*  var v = helper.EditingControlsFor(x => x.Balance);
              v.WriteTo(writer, new HtmlTestEncoder());
              const string expected =
                  "<div class=\"form-group\">" +
                  "LabelFor Balance { class = control-label col-md-4, style = font-weight: bold }" +
                  "<div class=\"col-md-4\">" +
                  "EditorFor Balance { htmlAttributes = { class = form-control } }" +
                  "ValidationMessageFor Balance { class = text-danger }" +
                  "</div>" +
                  "</div>";
              Assert.AreEqual(expected, writer.ToString());*/
            Assert.Inconclusive();

        }
    }
}
