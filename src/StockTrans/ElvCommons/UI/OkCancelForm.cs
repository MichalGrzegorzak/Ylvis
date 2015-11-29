using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Core;

namespace Commons.UI
{
    public delegate void DecisionHandler(bool decision);

    public partial class OkCancelForm<U> : Form where U : ContainerControl, IQuestion, new()
    {
        private int _timeLeft = 0;
        public event DecisionHandler HandleUserDecison;
        
        private System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        #region .Ctors
        public OkCancelForm(string[] question) : this(0, question)
        {
        }

        public OkCancelForm(int timer, string[] question)
        {
            InitializeComponent();
            InitializeDisplayControl(question);

            if (timer > 0)
            {
                _timeLeft = timer;
                StartTimer(timer);
            }
            
            player.SoundLocation = Directory.GetCurrentDirectory() + @"\Resources\ringin.wav";
            player.PlayLooping();
        } 

        ~OkCancelForm()
        {
            player = null;
        }

        #endregion

        #region User control declarations
        private U _displayControl;

        public U DisplayControl { get { return _displayControl; } }

        private void InitializeDisplayControl(params string[] question)
        {
            _displayControl = new U();
            _displayControl.Dock = DockStyle.Fill;
            displayPanel.Controls.Add(_displayControl);

            _displayControl.Question = question[0];
            _displayControl.QuestionDetails = question[1];
        } 
        #endregion

        private void btnYes_Click(object sender, EventArgs e)
        {
            DecisionMade(true);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DecisionMade(false);
        }

        private void StartTimer(int sec)
        {
            timer1.Enabled = true;
            timer1.Start();
        }

        private void DecisionMade(bool? decision)
        {
            player.Stop();

            if (decision != null)
            {
                HandleUserDecison.Invoke((bool)decision);
            }
            HandleUserDecison = null;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_timeLeft <= 1)
            {
                timer1.Stop();
                DecisionMade(null);
            }

            _timeLeft--;
            lblTimer.Text = _timeLeft.ToString();
        }
    }
}
