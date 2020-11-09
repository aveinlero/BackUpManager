namespace BackUpManager
{
    partial class FormSettings
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
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.buttonSetPath = new System.Windows.Forms.Button();
            this.textBoxBackUp = new System.Windows.Forms.TextBox();
            this.labelBackUpPath = new System.Windows.Forms.Label();
            this.buttonSetBackUpFolder = new System.Windows.Forms.Button();
            this.labelSettings = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxSource
            // 
            this.textBoxSource.Enabled = false;
            this.textBoxSource.Location = new System.Drawing.Point(68, 66);
            this.textBoxSource.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(298, 20);
            this.textBoxSource.TabIndex = 15;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(13, 69);
            this.labelSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(44, 13);
            this.labelSource.TabIndex = 14;
            this.labelSource.Text = "Source:";
            // 
            // buttonSetPath
            // 
            this.buttonSetPath.Location = new System.Drawing.Point(372, 64);
            this.buttonSetPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSetPath.Name = "buttonSetPath";
            this.buttonSetPath.Size = new System.Drawing.Size(103, 23);
            this.buttonSetPath.TabIndex = 13;
            this.buttonSetPath.Text = "Set Source";
            this.buttonSetPath.UseVisualStyleBackColor = true;
            this.buttonSetPath.Click += new System.EventHandler(this.buttonSetPath_Click);
            // 
            // textBoxBackUp
            // 
            this.textBoxBackUp.Enabled = false;
            this.textBoxBackUp.Location = new System.Drawing.Point(68, 92);
            this.textBoxBackUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxBackUp.Name = "textBoxBackUp";
            this.textBoxBackUp.Size = new System.Drawing.Size(298, 20);
            this.textBoxBackUp.TabIndex = 12;
            // 
            // labelBackUpPath
            // 
            this.labelBackUpPath.AutoSize = true;
            this.labelBackUpPath.Location = new System.Drawing.Point(13, 95);
            this.labelBackUpPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBackUpPath.Name = "labelBackUpPath";
            this.labelBackUpPath.Size = new System.Drawing.Size(49, 13);
            this.labelBackUpPath.TabIndex = 11;
            this.labelBackUpPath.Text = "BackUp:";
            // 
            // buttonSetBackUpFolder
            // 
            this.buttonSetBackUpFolder.Location = new System.Drawing.Point(372, 90);
            this.buttonSetBackUpFolder.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonSetBackUpFolder.Name = "buttonSetBackUpFolder";
            this.buttonSetBackUpFolder.Size = new System.Drawing.Size(103, 23);
            this.buttonSetBackUpFolder.TabIndex = 10;
            this.buttonSetBackUpFolder.Text = "Set BackUp folder";
            this.buttonSetBackUpFolder.UseVisualStyleBackColor = true;
            this.buttonSetBackUpFolder.Click += new System.EventHandler(this.buttonSetBackUpFolder_Click);
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSettings.Location = new System.Drawing.Point(12, 9);
            this.labelSettings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(164, 24);
            this.labelSettings.TabIndex = 16;
            this.labelSettings.Text = "Back Up settings";
            this.labelSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(372, 124);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(68, 40);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(407, 20);
            this.textBoxName.TabIndex = 19;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 43);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 18;
            this.labelName.Text = "Name:";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 159);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelSettings);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.buttonSetPath);
            this.Controls.Add(this.textBoxBackUp);
            this.Controls.Add(this.labelBackUpPath);
            this.Controls.Add(this.buttonSetBackUpFolder);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Button buttonSetPath;
        private System.Windows.Forms.TextBox textBoxBackUp;
        private System.Windows.Forms.Label labelBackUpPath;
        private System.Windows.Forms.Button buttonSetBackUpFolder;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
    }
}