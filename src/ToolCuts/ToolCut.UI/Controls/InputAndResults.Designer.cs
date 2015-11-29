namespace ToolCut.UI.Controls
{
    partial class InputAndResults
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputControl1 = new InputControl();
            this.resultsControl1 = new ResultsControl();
            this.SuspendLayout();
            // 
            // inputControl1
            // 
            this.inputControl1.Location = new System.Drawing.Point(3, 3);
            this.inputControl1.Name = "inputControl1";
            this.inputControl1.Size = new System.Drawing.Size(292, 53);
            this.inputControl1.TabIndex = 0;
            // 
            // resultsControl1
            // 
            this.resultsControl1.Location = new System.Drawing.Point(0, 62);
            this.resultsControl1.Name = "resultsControl1";
            this.resultsControl1.Size = new System.Drawing.Size(370, 132);
            this.resultsControl1.TabIndex = 1;
            // 
            // InputAndResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resultsControl1);
            this.Controls.Add(this.inputControl1);
            this.Name = "InputAndResults";
            this.Size = new System.Drawing.Size(385, 211);
            this.ResumeLayout(false);

        }

        #endregion

        private InputControl inputControl1;
        private ResultsControl resultsControl1;

    }
}
