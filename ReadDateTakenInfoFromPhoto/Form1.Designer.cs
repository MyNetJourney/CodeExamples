namespace ReadDateTakenInfoFromPhoto
{
    partial class Form1
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
            this.GetDateTakenButton = new System.Windows.Forms.Button();
            this.OpenFolderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetDateTakenButton
            // 
            this.GetDateTakenButton.Location = new System.Drawing.Point(160, 11);
            this.GetDateTakenButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GetDateTakenButton.Name = "GetDateTakenButton";
            this.GetDateTakenButton.Size = new System.Drawing.Size(164, 30);
            this.GetDateTakenButton.TabIndex = 0;
            this.GetDateTakenButton.Text = "Get date taken!";
            this.GetDateTakenButton.UseVisualStyleBackColor = true;
            this.GetDateTakenButton.Click += new System.EventHandler(this.GetDateTakenButton_Click);
            // 
            // OpenFolderButton
            // 
            this.OpenFolderButton.Location = new System.Drawing.Point(12, 11);
            this.OpenFolderButton.Name = "OpenFolderButton";
            this.OpenFolderButton.Size = new System.Drawing.Size(143, 30);
            this.OpenFolderButton.TabIndex = 1;
            this.OpenFolderButton.Text = "Open folder";
            this.OpenFolderButton.UseVisualStyleBackColor = true;
            this.OpenFolderButton.Click += new System.EventHandler(this.OpenFolderButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 289);
            this.Controls.Add(this.OpenFolderButton);
            this.Controls.Add(this.GetDateTakenButton);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetDateTakenButton;
        private System.Windows.Forms.Button OpenFolderButton;
    }
}

