namespace HappyBirthday.UI
{
    partial class BrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.PoemBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // PoemBrowser
            // 
            this.PoemBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PoemBrowser.Location = new System.Drawing.Point(0, 0);
            this.PoemBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.PoemBrowser.Name = "PoemBrowser";
            this.PoemBrowser.Size = new System.Drawing.Size(1148, 573);
            this.PoemBrowser.TabIndex = 0;
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 573);
            this.Controls.Add(this.PoemBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стихотворение";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser PoemBrowser;
    }
}