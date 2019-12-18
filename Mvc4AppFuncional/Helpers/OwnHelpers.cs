using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc ;

namespace Mvc4AppFuncional.Helpers
{
    public static  class OwnHelpers
    {
        public static MvcHtmlString List(this HtmlHelper helper, IEnumerable<string> items)
        {
            var result = "<ul>";
            foreach (var itm in items)
            {
                result += string.Format("<li>{0}</li>", itm);
            }
            result += "</ul>";

            return new MvcHtmlString(result);
        }
    }
}