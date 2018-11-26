using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Open.Aids;

namespace Open.Sentry.Extensions {
    public static class HtmlExtension {
        public static IHtmlContent DisplayForSignalR<TModel, TResult>() {
            // TODO: write method body
            
            return new HtmlContentBuilder();
        }
        
        public static IHtmlContent EditingControlsForEnum<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) {
            var selectList = new SelectList(Enum.GetNames(typeof(TResult)));
            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new { @class = "control-label col-md-4" }),
                new HtmlString("<div class=\"col-md-4\">"),
                htmlHelper.DropDownListFor(expression, selectList, new { @class = "form-control" }),
                htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent EditingControlsFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) {
            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new { @class = "control-label col-md-4", style = "font-weight: bold" }),
                new HtmlString("<div class=\"col-md-4\">"),
                htmlHelper.EditorFor(expression,
                    new { htmlAttributes = new { @class = "form-control" } }),
                htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent ViewingControlsFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) {
            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new { @class = "control-label col-md-4", style = "font-weight: bold" }),
                new HtmlString("<div class=\"col-md-10\" style=\"margin-top:10px\">"),
                htmlHelper.DisplayFor(expression,
                    new { htmlAttributes = new { @class = "form-control" } }),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent SortColumnHeaderFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, object sortString,
            Expression<Func<TModel, TResult>> expression) {
            var linkName = htmlHelper.DisplayNameFor(expression);
            var action = "Index";
            var htmlStrings = new List<object> {
                new HtmlString("<th>"),
                htmlHelper.ActionLink(linkName, action, new { SortOrder = sortString }),
                new HtmlString("</th>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent EditDetailDeleteFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) {
            var edit = "Edit";
            var details = "Details";
            var delete = "Delete";
            var index = htmlHelper.ValueFor(expression);
            var htmlStrings = new List<object> {
                new HtmlString("<th>"),
                htmlHelper.ActionLink("Edit", edit, new { id = index }),
                new HtmlString(" | "),
                htmlHelper.ActionLink("Details", details, new { id = index }),
                new HtmlString(" | "),
                htmlHelper.ActionLink("Delete", delete, new { id = index }),
                new HtmlString("</th>")
            };
            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent EditingControlsForCountry<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) {
            var countryList = new List<string>();
            foreach (RegionInfo region in SystemRegionInfo.GetRegionsList()) {
                countryList.Add(region.DisplayName);
            }
            var selectList = new SelectList(countryList);
            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new { @class = "control-label" }),
                htmlHelper.DropDownListFor(expression, selectList, new { @class = "form-control" }),
                htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }),
                new HtmlString("</div>"),
            };

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent EditingControlsForDecimal<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression) {
            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.LabelFor(expression, new { @class = "control-label col-md-4", style = "font-weight: bold" }),
                new HtmlString("<div class=\"col-md-4\">"),
                htmlHelper.EditorFor(expression, new {
                    htmlAttributes = new
                        { @class = "form-control", @type = "number", @min = "0", @step = ".01", @value = "0", }
                }),
                htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }

        public static IHtmlContent ViewingControlsCustomLabelFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string label) {
            var htmlStrings = new List<object> {
                new HtmlString("<div class=\"form-group\">"),
                htmlHelper.Label(expression.ToString(), label,
                    new { @class = "control-label col-md-4", style = "font-weight: bold" }),
                new HtmlString("<div class=\"col-md-10\" style=\"margin-top:10px\">"),
                htmlHelper.DisplayFor(expression,
                    new { htmlAttributes = new { @class = "form-control" } }),
                new HtmlString("</div>"),
                new HtmlString("</div>")
            };

            return new HtmlContentBuilder(htmlStrings);
        }
    }
}
