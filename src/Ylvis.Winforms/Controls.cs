using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Ylvis.Winforms
{
    public static class ControlsExtensions
    {
        public static IEnumerable<Control> GetChildControls(this Control control)
        {
            var children = (control.Controls != null) ? control.Controls.OfType<Control>() : Enumerable.Empty<Control>();
            return children.SelectMany(c => GetChildControls(c)).Concat(children);
        }
        public static List<T> GetChildControlsOf<T>(this Control control)
        {
            return GetChildControls(control).Where(x => x is T).Cast<T>().ToList();
        }
        //public static IEnumerable<Control> GetChildControlsOfType(this Control control, Func<Control, bool> predicate = null )
        //{
        //    if (predicate == null)
        //        predicate = new Func<Control, bool>(x=> true);

        //    var children = (control.Controls != null) ? control.Controls.OfType<Control>() : Enumerable.Empty<Control>();
        //    return children.Where(predicate).SelectMany(c => GetChildControls(c)).Concat(children);
        //}

        public static void FlowBreak(this Control control, bool enable)
        {
            if (control.Tag == null)
                control.Tag = new TagMeta();

            TagMeta tag = control.Tag as TagMeta;
            if (tag != null)
                tag.FlowBreak = enable;
        }
    }

    public class TagMeta
    {
        public bool FlowBreak { get; set; }
    }
}