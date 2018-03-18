using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ExtensionsLib.Web
{
    public static class DropDownListExtensions
    {
        public static void SelectById(this DropDownList ddl, int id)
        {
            ListItem d = ddl.Items.FindByValue(id.ToString());
            int idx = ddl.Items.IndexOf(d);
            ddl.SelectedIndex = idx;
        }
    }
}
