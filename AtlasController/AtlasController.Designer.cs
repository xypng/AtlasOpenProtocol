namespace AtlasController
{
    partial class AtlasController
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnAddPset = new System.Windows.Forms.Button();
            this.btnDeletePset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 36);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 309);
            this.tabControl1.TabIndex = 0;
            // 
            // btnAddPset
            // 
            this.btnAddPset.Location = new System.Drawing.Point(12, 7);
            this.btnAddPset.Name = "btnAddPset";
            this.btnAddPset.Size = new System.Drawing.Size(75, 23);
            this.btnAddPset.TabIndex = 1;
            this.btnAddPset.Text = "添加Pset";
            this.btnAddPset.UseVisualStyleBackColor = true;
            this.btnAddPset.Click += new System.EventHandler(this.btnAddPset_Click);
            // 
            // btnDeletePset
            // 
            this.btnDeletePset.Location = new System.Drawing.Point(93, 7);
            this.btnDeletePset.Name = "btnDeletePset";
            this.btnDeletePset.Size = new System.Drawing.Size(75, 23);
            this.btnDeletePset.TabIndex = 2;
            this.btnDeletePset.Text = "删除Pset";
            this.btnDeletePset.UseVisualStyleBackColor = true;
            this.btnDeletePset.Click += new System.EventHandler(this.btnDeletePset_Click);
            // 
            // AtlasController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 357);
            this.Controls.Add(this.btnDeletePset);
            this.Controls.Add(this.btnAddPset);
            this.Controls.Add(this.tabControl1);
            this.Name = "AtlasController";
            this.Text = "拧紧枪";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AtlasController_FormClosing);
            this.Load += new System.EventHandler(this.AtlasController_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnAddPset;
        private System.Windows.Forms.Button btnDeletePset;
    }
}

