namespace woodsandfloors
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
            this.CreateInsertPhotosButton = new System.Windows.Forms.Button();
            this.selectSourceFolderButton = new System.Windows.Forms.Button();
            this.CreateInsertProductsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.resultScriptRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.sourceFolderPathComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // CreateInsertPhotosButton
            // 
            this.CreateInsertPhotosButton.Location = new System.Drawing.Point(23, 58);
            this.CreateInsertPhotosButton.Name = "CreateInsertPhotosButton";
            this.CreateInsertPhotosButton.Size = new System.Drawing.Size(173, 23);
            this.CreateInsertPhotosButton.TabIndex = 1;
            this.CreateInsertPhotosButton.Text = "Create Insert Photos Script";
            this.CreateInsertPhotosButton.UseVisualStyleBackColor = true;
            this.CreateInsertPhotosButton.Click += new System.EventHandler(this.CreateInsertPhotosButton_Click);
            // 
            // selectSourceFolderButton
            // 
            this.selectSourceFolderButton.Location = new System.Drawing.Point(946, 18);
            this.selectSourceFolderButton.Name = "selectSourceFolderButton";
            this.selectSourceFolderButton.Size = new System.Drawing.Size(106, 23);
            this.selectSourceFolderButton.TabIndex = 3;
            this.selectSourceFolderButton.Text = "Select Folder";
            this.selectSourceFolderButton.UseVisualStyleBackColor = true;
            this.selectSourceFolderButton.Click += new System.EventHandler(this.selectSourceFolderButton_Click);
            // 
            // CreateInsertProductsButton
            // 
            this.CreateInsertProductsButton.Location = new System.Drawing.Point(205, 58);
            this.CreateInsertProductsButton.Name = "CreateInsertProductsButton";
            this.CreateInsertProductsButton.Size = new System.Drawing.Size(181, 23);
            this.CreateInsertProductsButton.TabIndex = 4;
            this.CreateInsertProductsButton.Text = "Create Insert Product Script";
            this.CreateInsertProductsButton.UseVisualStyleBackColor = true;
            this.CreateInsertProductsButton.Click += new System.EventHandler(this.CreateInsertProductsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source Folder Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Script:";
            // 
            // resultScriptRichTextBox
            // 
            this.resultScriptRichTextBox.Location = new System.Drawing.Point(12, 115);
            this.resultScriptRichTextBox.Name = "resultScriptRichTextBox";
            this.resultScriptRichTextBox.Size = new System.Drawing.Size(1058, 765);
            this.resultScriptRichTextBox.TabIndex = 7;
            this.resultScriptRichTextBox.Text = "";
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(401, 58);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(119, 23);
            this.ClearButton.TabIndex = 8;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // sourceFolderPathComboBox
            // 
            this.sourceFolderPathComboBox.FormattingEnabled = true;
            this.sourceFolderPathComboBox.Location = new System.Drawing.Point(150, 20);
            this.sourceFolderPathComboBox.Name = "sourceFolderPathComboBox";
            this.sourceFolderPathComboBox.Size = new System.Drawing.Size(790, 21);
            this.sourceFolderPathComboBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 892);
            this.Controls.Add(this.sourceFolderPathComboBox);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.resultScriptRichTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateInsertProductsButton);
            this.Controls.Add(this.selectSourceFolderButton);
            this.Controls.Add(this.CreateInsertPhotosButton);
            this.Name = "Form1";
            this.Text = "Woods and Floors Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CreateInsertPhotosButton;
        private System.Windows.Forms.Button selectSourceFolderButton;
        private System.Windows.Forms.Button CreateInsertProductsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox resultScriptRichTextBox;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.ComboBox sourceFolderPathComboBox;
    }
}

