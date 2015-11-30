using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Stock.Core.Domain;

namespace Stock.Forms
{
    public partial class GenericForm : Form
    {
        public GenericForm()
        {
            InitializeComponent();
            Init(new Credit());
        }

        public void Init(object item)
        {
            foreach (PropertyInfo itemProperty in item.GetType().GetProperties())
            {
                if (itemProperty.CanRead)
                {
                    //object valueToAssign = Convert.ChangeType(itemProperty.GetValue(item, null), itemProperty.PropertyType);
                    //Type t = item.GetType();
                    //BaseControl c1 = new BaseControl("nazwa1", t);
                    //c1.InputValue = valueToAssign.ToString().Parse<t>;
                }
            }
            
            //BaseControl<Int32> c1 = new BaseControl<int>("nazwa1");
            //c1.InputValue = 100;
            BaseControl<Int32> c2 = new BaseControl<int>("nazwa2");
            BaseControl<Int32> c3 = new BaseControl<int>("nazwa3");
            //flowLayoutPanel1.Controls.Add(c1);
            flowLayoutPanel1.Controls.Add(c2);
            flowLayoutPanel1.Controls.Add(c3);

            //int v = c1.InputValue;
            //label1.Text = v.ToString();
        }

    }
}
