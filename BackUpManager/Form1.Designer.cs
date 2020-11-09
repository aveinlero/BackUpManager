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
            this.labelBackUpPath = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelListViewBackUp = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.labelBackUpVersion = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.buttonAddBackUpObj = new System.Windows.Forms.Button();
            this.buttonDeleteBackUpObj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewBackUp
            // 
            this.listViewBackUp.HideSelection = false;
            this.listViewBackUp.Location = new System.Drawing.Point(12, 43);
            this.listViewBackUp.Name = "listViewBackUp";
            this.listViewBackUp.Size = new System.Drawing.Size(192, 219);
            this.listViewBackUp.TabIndex = 0;
            this.listViewBackUp.UseCompatibleStateImageBehavior = false;
            // 
            // labelBackUpPath
            // 
            this.labelBackUpPath.AutoSize = true;
            this.labelBackUpPath.Location = new System.Drawing.Point(12, 335);
            this.labelBackUpPath.Name = "labelBackUpPath";
            this.labelBackUpPath.Size = new System.Drawing.Size(49, 13);
            this.labelBackUpPath.TabIndex = 2;
            this.labelBackUpPath.Text = "BackUp:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 332);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(407, 20);
            this.textBox1.TabIndex = 3;
            // 
            // labelListViewBackUp
            // 
            this.labelListViewBackUp.AutoSize = true;
            this.labelListViewBackUp.Location = new System.Drawing.Point(12, 18);
            this.labelListViewBackUp.Name = "labelListViewBackUp";
            this.labelListViewBackUp.Size = new System.Drawing.Size(65, 13);
            this.labelListViewBackUp.TabIndex = 4;
            this.labelListViewBackUp.Text = "BackUp List";
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(240, 43);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 219);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // labelBackUpVersion
            // 
            this.labelBackUpVersion.AutoSize = true;
            this.labelBackUpVersion.Location = new System.Drawing.Point(237, 18);
            this.labelBackUpVersion.Name = "labelBackUpVersion";
            this.labelBackUpVersion.Size = new System.Drawing.Size(45, 13);
            this.labelBackUpVersion.TabIndex = 6;
            this.labelBackUpVersion.Text = "Version:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(67, 306);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(407, 20);
            this.textBox2.TabIndex = 9;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(12, 309);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(44, 13);
            this.labelSource.TabIndex = 8;
            this.labelSource.Text = "Source:";
            // 
            // buttonAddBackUpObj
            // 
            this.buttonAddBackUpObj.Location = new System.Drawing.Point(12, 268);
            this.buttonAddBackUpObj.Name = "buttonAddBackUpObj";
            this.buttonAddBackUpObj.Size = new System.Drawing.Size(75, 23);
            this.buttonAddBackUpObj.TabIndex = 10;
            this.buttonAddBackUpObj.Text = "Add";
            this.buttonAddBackUpObj.UseVisualStyleBackColor = true;
            this.buttonAddBackUpObj.Click += new System.EventHandler(this.buttonAddBackUpObj_Click);
            // 
            // buttonDeleteBackUpObj
            // 
            this.buttonDeleteBackUpObj.Location = new System.Drawing.Point(93, 268);
            this.buttonDeleteBackUpObj.Name = "buttonDeleteBackUpObj";
            this.buttonDeleteBackUpObj.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteBackUpObj.TabIndex = 11;
            this.buttonDeleteBackUpObj.Text = "Delete";
            this.buttonDeleteBackUpObj.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 366);
            this.Controls.Add(this.buttonDeleteBackUpObj);
            this.Controls.Add(this.buttonAddBackUpObj);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.labelBackUpVersion);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.labelListViewBackUp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelBackUpPath);
            this.Controls.Add(this.listViewBackUp);
            this.Name = "MainForm";
            this.Text = "BackUp Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewBackUp;
        private System.Windows.Forms.Label labelBackUpPath;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelListViewBackUp;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label labelBackUpVersion;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Button buttonAddBackUpObj;
        private System.Windows.Forms.Button buttonDeleteBackUpObj;
    }
}

