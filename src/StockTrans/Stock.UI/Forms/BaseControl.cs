using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Commons.Extensions;

namespace Stock.Forms
{
    public partial class BaseControl<T> : UserControl
    {
        public BaseControl(string name)
        {
            InitializeComponent();

            //_typ = T;
            _value = default(T);

            Label l = new Label();
            l.Size = new Size(80,15);
            //l.AutoSize = true;
            l.Text = name;
            l.Top += 3;

            _input = new Control();

            if (typeof(T) == typeof(Int32))
            {
                _input = new TextBox();
                _input.Size = new Size(70,15);
                _input.Top = l.Top - 3;
                _input.Left = l.Width + 10;
                //_input.Text = "cos cos";
            }

            this.Controls.Add(_input);
            this.Controls.Add(l);
        }
        public T InputValue
        {
            get
            {
                string t = _input.Text.Trim();
                return t.Parse<T>();
            }
            set
            {
                _input.Text = value.ToString();
            }
        }

        //protected T _typ;
        protected T _value;
        protected string _name;
        protected Control _input;

    }
}
