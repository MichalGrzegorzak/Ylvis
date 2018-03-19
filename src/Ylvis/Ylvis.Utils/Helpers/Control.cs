using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace ExtensionsLib.Web
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Finds a control, and cast to type
        /// </summary>
        public static HtmlGenericControl FindControlHtmlGeneric(this Control item, string ctrlName)
        {
            HtmlGenericControl ctrl = item.FindControl(ctrlName) as HtmlGenericControl;
            return ctrl;
        }
    }
}
