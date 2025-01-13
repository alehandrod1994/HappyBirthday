namespace HappyBirthday.UI
{
    partial class SuccessfullyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuccessfullyForm));
            this.CloseButton = new System.Windows.Forms.Button();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.labelPath2 = new System.Windows.Forms.Label();
            this.labelPath1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(462, 201);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(155, 39);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenFolderButton.Location = new System.Drawing.Point(268, 201);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(155, 39);
            this.OpenFolderButton.TabIndex = 8;
            this.OpenFolderButton.Text = "Открыть папку";
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenFileButton.Location = new System.Drawing.Point(76, 201);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(155, 39);
            this.OpenFileButton.TabIndex = 7;
            this.OpenFileButton.Text = "Открыть";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // labelPath2
            // 
            this.labelPath2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPath2.Location = new System.Drawing.Point(76, 99);
            this.labelPath2.Name = "labelPath2";
            this.labelPath2.Size = new System.Drawing.Size(541, 39);
            this.labelPath2.TabIndex = 6;
            this.labelPath2.Text = "E:\\Диск C\\Пользователи\\Documents\\Visual Studio 2015\\Projects\\SectorCounting\\Secto" +
    "rCounting\\bin\\Debug";
            this.labelPath2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelPath1
            // 
            this.labelPath1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPath1.Location = new System.Drawing.Point(224, 19);
            this.labelPath1.Name = "labelPath1";
            this.labelPath1.Size = new System.Drawing.Size(230, 23);
            this.labelPath1.TabIndex = 5;
            this.labelPath1.Text = "Файл успешно сохранён:";
            this.labelPath1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HappyBirthday.UI.Properties.Resources.CheckMark;
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // SuccessfullyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 265);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.labelPath2);
            this.Controls.Add(this.labelPath1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SuccessfullyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Успешно";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OpenFolderButton;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Label labelPath2;
        private System.Windows.Forms.Label labelPath1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}