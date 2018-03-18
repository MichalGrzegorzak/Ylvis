using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ExtensionsLib.Web
{
    /// <summary>
    /// Extends Repeater item, for finding html control and fill it up
    /// </summary>
    public static class RepeaterItemExtensions
    {
        /// <summary>
        /// Finds a control, and cast to type
        /// </summary>
        public static T FindControl<T>(this RepeaterItem item, string ctrlName) where T : class
        {
            T ctrl = item.FindControl(ctrlName) as T;
            return ctrl;
        }

        /// <summary>
        /// Finds a control, and executes a delegate on it
        /// </summary>
        public static void FindAndFill<T>(this RepeaterItem item, string ctrlName, Action<T> a) where T : class
        {
            T ctrl = item.FindControl(ctrlName) as T;
            if (ctrl != null)
            {
                a.Invoke(ctrl);
            }
        }

        public static void FindAndFillHtmlAnchor
            (this RepeaterItem item, string ctrlName, string link, string title) 
        {
            item.FindAndFill<HtmlAnchor>(ctrlName, a =>
                                                       {
                                                           a.HRef = link;

                                                           if (title.IsNotNullOrEmpty())
                                                           {
                                                               a.Title = title;
                                                               a.InnerText = title;
                                                           }
                                                       });
        }

        public static void FindAndFillHtmlAnchor
            (this RepeaterItem item, string ctrlName, string link, string title, bool addTitleToInnerHtml)
        {
            item.FindAndFill<HtmlAnchor>(ctrlName, a =>
            {
                a.HRef = link;

                if (title.IsNotNullOrEmpty())
                {
                    a.Title = title;
                    a.InnerHtml += title; //(!!!)
                }
            });
        }
        
    }
}
