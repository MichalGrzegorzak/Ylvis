using System;
using Commons.UI;
using Core;

namespace Commons.UI
{
    public partial class QuestionUserCtrl : ucMyDesignable, IQuestion
    {
        public QuestionUserCtrl()
        {
            InitializeComponent();
        }

        public string Question
        {
            get
            {
                return "";
            }
            set
            {
                label1.Text = value;
            }
        }

        public string QuestionDetails
        {
            get
            {
                return lblDetails.Text;
            }
            set
            {
                lblDetails.Text = value;
            }
        }
    }
}
