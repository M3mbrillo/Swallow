using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Swallow.Utils.Extensions
{
    public static class IHtmlHelperExtensions
    {
        public static IHtmlContent EditorFor_withClass<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string @classes)
        {
            return htmlHelper.EditorFor(expression, new { @class = @classes });
        }

        public static IHtmlContent LabelFor_withClass<TModel, TResult>(this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TResult>> expression, string @classes)
        {
            return htmlHelper.LabelFor(expression, new { @class = @classes });
        }

    }
}
