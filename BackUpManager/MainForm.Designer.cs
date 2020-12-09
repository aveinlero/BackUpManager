

namespace BackUpManager
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewBackUp = new System.Windows.Forms.ListView();
            this.BackUpName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OnStartup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ByPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Period = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelBackUpPath = new System.Windows.Forms.Label();
            this.textBoxBackUp = new System.Windows.Forms.TextBox();
            this.labelListViewBackUp = new System.Windows.Forms.Label();
            this.listViewVersions = new System.Windows.Forms.ListView();
            this.labelBackUpVersion = new System.Windows.Forms.Label();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.buttonAddBackUpObj = new System.Windows.Forms.Button();
            this.buttonDeleteBackUpObj = new System.Windows.Forms.Button();
            this.buttonAddVersion = new System.Windows.Forms.Button();
            this.buttonDeleteVersion = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonRecovery = new System.Windows.Forms.Button();
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewBackUp
            // 
            this.listViewBackUp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BackUpName,
            this.Size,
            this.OnStartup,
            this.ByPeriod,
            this.Period,
            this.Time});
            this.listViewBackUp.HideSelection = false;
            this.listViewBackUp.Location = new System.Drawing.Point(12, 24);
            this.listViewBackUp.MultiSelect = false;
            this.listViewBackUp.Name = "listViewBackUp";
            this.listViewBackUp.Size = new System.Drawing.Size(376, 219);
            this.listViewBackUp.TabIndex = 0;
            this.listViewBackUp.UseCompatibleStateImageBehavior = false;
            this.listViewBackUp.View = System.Windows.Forms.View.Details;
            this.listViewBackUp.ItemActivate += new System.EventHandler(this.listViewBackUp_ItemActivate);
            this.listViewBackUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listViewBackUp_MouseUp);
            // 
            // BackUpName
            // 
            this.BackUpName.Text = "Name";
            this.BackUpName.Width = 119;
            // 
            // OnStartup
            // 
            this.OnStartup.Text = "OnStartup";
            // 
            // ByPeriod
            // 
            this.ByPeriod.Text = "ByPeriod";
            // 
            // Period
            // 
            this.Period.Text = "Days";
            this.Period.Width = 37;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            // 
            // labelBackUpPath
            // 
            this.labelBackUpPath.AutoSize = true;
            this.labelBackUpPath.Location = new System.Drawing.Point(12, 316);
            this.labelBackUpPath.Name = "labelBackUpPath";
            this.labelBackUpPath.Size = new System.Drawing.Size(49, 13);
            this.labelBackUpPath.TabIndex = 2;
            this.labelBackUpPath.Text = "BackUp:";
            // 
            // textBoxBackUp
            // 
            this.textBoxBackUp.Enabled = false;
            this.textBoxBackUp.Location = new System.Drawing.Point(67, 313);
            this.textBoxBackUp.Name = "textBoxBackUp";
            this.textBoxBackUp.Size = new System.Drawing.Size(564, 20);
            this.textBoxBackUp.TabIndex = 3;
            // 
            // labelListViewBackUp
            // 
            this.labelListViewBackUp.AutoSize = true;
            this.labelListViewBackUp.Location = new System.Drawing.Point(9, 8);
            this.labelListViewBackUp.Name = "labelListViewBackUp";
            this.labelListViewBackUp.Size = new System.Drawing.Size(65, 13);
            this.labelListViewBackUp.TabIndex = 4;
            this.labelListViewBackUp.Text = "BackUp List";
            // 
            // listViewVersions
            // 
            this.listViewVersions.HideSelection = false;
            this.listViewVersions.Location = new System.Drawing.Point(394, 24);
            this.listViewVersions.Name = "listViewVersions";
            this.listViewVersions.Size = new System.Drawing.Size(237, 219);
            this.listViewVersions.TabIndex = 5;
            this.listViewVersions.UseCompatibleStateImageBehavior = false;
            this.listViewVersions.View = System.Windows.Forms.View.List;
            // 
            // labelBackUpVersion
            // 
            this.labelBackUpVersion.AutoSize = true;
            this.labelBackUpVersion.Location = new System.Drawing.Point(391, 8);
            this.labelBackUpVersion.Name = "labelBackUpVersion";
            this.labelBackUpVersion.Size = new System.Drawing.Size(45, 13);
            this.labelBackUpVersion.TabIndex = 6;
            this.labelBackUpVersion.Text = "Version:";
            // 
            // textBoxSource
            // 
            this.textBoxSource.Enabled = false;
            this.textBoxSource.Location = new System.Drawing.Point(67, 287);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.Size = new System.Drawing.Size(564, 20);
            this.textBoxSource.TabIndex = 9;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(12, 290);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(44, 13);
            this.labelSource.TabIndex = 8;
            this.labelSource.Text = "Source:";
            // 
            // buttonAddBackUpObj
            // 
            this.buttonAddBackUpObj.Location = new System.Drawing.Point(12, 249);
            this.buttonAddBackUpObj.Name = "buttonAddBackUpObj";
            this.buttonAddBackUpObj.Size = new System.Drawing.Size(75, 23);
            this.buttonAddBackUpObj.TabIndex = 10;
            this.buttonAddBackUpObj.Text = "Add";
            this.buttonAddBackUpObj.UseVisualStyleBackColor = true;
            this.buttonAddBackUpObj.Click += new System.EventHandler(this.buttonAddBackUpObj_Click);
            // 
            // buttonDeleteBackUpObj
            // 
            this.buttonDeleteBackUpObj.Location = new System.Drawing.Point(174, 249);
            this.buttonDeleteBackUpObj.Name = "buttonDeleteBackUpObj";
            this.buttonDeleteBackUpObj.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteBackUpObj.TabIndex = 11;
            this.buttonDeleteBackUpObj.Text = "Delete";
            this.buttonDeleteBackUpObj.UseVisualStyleBackColor = true;
            this.buttonDeleteBackUpObj.Click += new System.EventHandler(this.buttonDeleteBackUpObj_Click);
            // 
            // buttonAddVersion
            // 
            this.buttonAddVersion.Location = new System.Drawing.Point(394, 249);
            this.buttonAddVersion.Name = "buttonAddVersion";
            this.buttonAddVersion.Size = new System.Drawing.Size(75, 23);
            this.buttonAddVersion.TabIndex = 12;
            this.buttonAddVersion.Text = "Add";
            this.buttonAddVersion.UseVisualStyleBackColor = true;
            this.buttonAddVersion.Click += new System.EventHandler(this.buttonAddVersion_Click);
            // 
            // buttonDeleteVersion
            // 
            this.buttonDeleteVersion.Location = new System.Drawing.Point(556, 249);
            this.buttonDeleteVersion.Name = "buttonDeleteVersion";
            this.buttonDeleteVersion.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteVersion.TabIndex = 13;
            this.buttonDeleteVersion.Text = "Delete";
            this.buttonDeleteVersion.UseVisualStyleBackColor = true;
            this.buttonDeleteVersion.Click += new System.EventHandler(this.buttonDeleteVersion_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(93, 249);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 14;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonRecovery
            // 
            this.buttonRecovery.Location = new System.Drawing.Point(475, 249);
            this.buttonRecovery.Name = "buttonRecovery";
            this.buttonRecovery.Size = new System.Drawing.Size(75, 23);
            this.buttonRecovery.TabIndex = 15;
            this.buttonRecovery.Text = "Recovery";
            this.buttonRecovery.UseVisualStyleBackColor = true;
            this.buttonRecovery.Click += new System.EventHandler(this.buttonRecovery_Click);
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.Width = 35;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 342);
            this.Controls.Add(this.buttonRecovery);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDeleteVersion);
            this.Controls.Add(this.buttonAddVersion);
            this.Controls.Add(this.buttonDeleteBackUpObj);
            this.Controls.Add(this.buttonAddBackUpObj);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.labelBackUpVersion);
            this.Controls.Add(this.listViewVersions);
            this.Controls.Add(this.labelListViewBackUp);
            this.Controls.Add(this.textBoxBackUp);
            this.Controls.Add(this.labelBackUpPath);
            this.Controls.Add(this.listViewBackUp);
            this.Name = "MainForm";
            this.Text = "BackUp Manager";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewBackUp;
        private System.Windows.Forms.Label labelBackUpPath;
        private System.Windows.Forms.TextBox textBoxBackUp;
        private System.Windows.Forms.Label labelListViewBackUp;
        private System.Windows.Forms.ListView listViewVersions;
        private System.Windows.Forms.Label labelBackUpVersion;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Button buttonAddBackUpObj;
        private System.Windows.Forms.Button buttonDeleteBackUpObj;
        private System.Windows.Forms.Button buttonAddVersion;
        private System.Windows.Forms.Button buttonDeleteVersion;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ColumnHeader BackUpName;
        private System.Windows.Forms.ColumnHeader OnStartup;
        private System.Windows.Forms.ColumnHeader ByPeriod;
        private System.Windows.Forms.ColumnHeader Period;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.Button buttonRecovery;
        private System.Windows.Forms.ColumnHeader Size;
    }
}

