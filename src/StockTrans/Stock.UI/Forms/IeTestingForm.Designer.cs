namespace Stock.Forms
{
    partial class IeTestingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cEXWB1 = new csExWB.cEXWB();
            this.SuspendLayout();
            // 
            // cEXWB1
            // 
            this.cEXWB1.Border3DEnabled = false;
            this.cEXWB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cEXWB1.DocumentSource = "<HTML><HEAD></HEAD>\r\n<BODY></BODY></HTML>";
            this.cEXWB1.DocumentTitle = "";
            this.cEXWB1.DownloadActiveX = false;
            this.cEXWB1.DownloadFrames = true;
            this.cEXWB1.DownloadImages = false;
            this.cEXWB1.DownloadJava = false;
            this.cEXWB1.DownloadScripts = true;
            this.cEXWB1.DownloadSounds = false;
            this.cEXWB1.DownloadVideo = false;
            this.cEXWB1.FileDownloadDirectory = "C:\\Documents and Settings\\user\\Moje dokumenty\\";
            this.cEXWB1.Location = new System.Drawing.Point(0, 0);
            this.cEXWB1.LocationUrl = "about:blank";
            this.cEXWB1.Name = "cEXWB1";
            this.cEXWB1.ObjectForScripting = null;
            this.cEXWB1.OffLine = false;
            this.cEXWB1.RegisterAsBrowser = false;
            this.cEXWB1.RegisterAsDropTarget = false;
            this.cEXWB1.RegisterForInternalDragDrop = true;
            this.cEXWB1.ScrollBarsEnabled = true;
            this.cEXWB1.SendSourceOnDocumentCompleteWBEx = false;
            this.cEXWB1.Silent = false;
            this.cEXWB1.Size = new System.Drawing.Size(613, 328);
            this.cEXWB1.TabIndex = 2;
            this.cEXWB1.Text = "cEXWB1";
            this.cEXWB1.TextSize = IfacesEnumsStructsClasses.TextSizeWB.Medium;
            this.cEXWB1.UseInternalDownloadManager = true;
            this.cEXWB1.WBDOCDOWNLOADCTLFLAG = 1280;
            this.cEXWB1.WBDOCHOSTUIDBLCLK = IfacesEnumsStructsClasses.DOCHOSTUIDBLCLK.DEFAULT;
            this.cEXWB1.WBDOCHOSTUIFLAG = 262276;
            // 
            // IeTestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 328);
            this.Controls.Add(this.cEXWB1);
            this.Name = "IeTestingForm";
            this.Text = "IeTestingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private csExWB.cEXWB cEXWB1;
    }
}