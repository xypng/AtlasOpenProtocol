namespace EPClient
{
    partial class EPClient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dGVGuns = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dGVActions = new System.Windows.Forms.DataGridView();
            this.ActionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionGun = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ActionBatchCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionOkCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionNokCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GunId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GunCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GunIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GunPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GunStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.connect = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVGuns)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVActions)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dGVGuns);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(612, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拧紧枪";
            // 
            // dGVGuns
            // 
            this.dGVGuns.AllowUserToResizeRows = false;
            this.dGVGuns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVGuns.CausesValidation = false;
            this.dGVGuns.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dGVGuns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVGuns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GunId,
            this.GunCode,
            this.GunIp,
            this.GunPort,
            this.GunStatus,
            this.connect});
            this.dGVGuns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVGuns.Location = new System.Drawing.Point(2, 16);
            this.dGVGuns.Margin = new System.Windows.Forms.Padding(2);
            this.dGVGuns.Name = "dGVGuns";
            this.dGVGuns.RowTemplate.Height = 20;
            this.dGVGuns.Size = new System.Drawing.Size(608, 121);
            this.dGVGuns.TabIndex = 0;
            this.dGVGuns.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.CellValidating);
            this.dGVGuns.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dGVGuns_UserDeletingRow);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dGVActions);
            this.groupBox2.Location = new System.Drawing.Point(6, 154);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(615, 294);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工序";
            // 
            // dGVActions
            // 
            this.dGVActions.AllowUserToResizeRows = false;
            this.dGVActions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVActions.CausesValidation = false;
            this.dGVActions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dGVActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dGVActions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActionId,
            this.ActionName,
            this.ActionGun,
            this.ActionBatchCount,
            this.ActionOkCount,
            this.ActionNokCount});
            this.dGVActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVActions.Location = new System.Drawing.Point(2, 16);
            this.dGVActions.Margin = new System.Windows.Forms.Padding(2);
            this.dGVActions.Name = "dGVActions";
            this.dGVActions.RowTemplate.Height = 20;
            this.dGVActions.Size = new System.Drawing.Size(611, 276);
            this.dGVActions.TabIndex = 0;
            this.dGVActions.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.CellValidating);
            // 
            // ActionId
            // 
            this.ActionId.DataPropertyName = "ID";
            this.ActionId.HeaderText = "id";
            this.ActionId.Name = "ActionId";
            this.ActionId.ReadOnly = true;
            this.ActionId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionId.Visible = false;
            // 
            // ActionName
            // 
            this.ActionName.DataPropertyName = "Name";
            this.ActionName.HeaderText = "名称";
            this.ActionName.Name = "ActionName";
            // 
            // ActionGun
            // 
            this.ActionGun.DataPropertyName = "GunID";
            this.ActionGun.HeaderText = "拧紧枪";
            this.ActionGun.Name = "ActionGun";
            this.ActionGun.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActionGun.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ActionBatchCount
            // 
            this.ActionBatchCount.DataPropertyName = "Pset";
            this.ActionBatchCount.HeaderText = "挡位";
            this.ActionBatchCount.Name = "ActionBatchCount";
            // 
            // ActionOkCount
            // 
            this.ActionOkCount.DataPropertyName = "OkCount";
            this.ActionOkCount.HeaderText = "Ok个数";
            this.ActionOkCount.Name = "ActionOkCount";
            this.ActionOkCount.ReadOnly = true;
            // 
            // ActionNokCount
            // 
            this.ActionNokCount.DataPropertyName = "NokCount";
            this.ActionNokCount.HeaderText = "Nok个数";
            this.ActionNokCount.Name = "ActionNokCount";
            this.ActionNokCount.ReadOnly = true;
            // 
            // GunId
            // 
            this.GunId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GunId.DataPropertyName = "ID";
            this.GunId.HeaderText = "id";
            this.GunId.Name = "GunId";
            this.GunId.ReadOnly = true;
            this.GunId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GunId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GunId.Visible = false;
            // 
            // GunCode
            // 
            this.GunCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GunCode.DataPropertyName = "Code";
            this.GunCode.HeaderText = "编号";
            this.GunCode.Name = "GunCode";
            this.GunCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GunIp
            // 
            this.GunIp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GunIp.DataPropertyName = "IP";
            this.GunIp.HeaderText = "ip";
            this.GunIp.Name = "GunIp";
            this.GunIp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GunPort
            // 
            this.GunPort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GunPort.DataPropertyName = "Port";
            this.GunPort.HeaderText = "端口";
            this.GunPort.Name = "GunPort";
            this.GunPort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // GunStatus
            // 
            this.GunStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GunStatus.DataPropertyName = "Status";
            this.GunStatus.HeaderText = "状态";
            this.GunStatus.Name = "GunStatus";
            this.GunStatus.ReadOnly = true;
            this.GunStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // connect
            // 
            this.connect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.connect.HeaderText = "连接";
            this.connect.Name = "connect";
            this.connect.ReadOnly = true;
            this.connect.Visible = false;
            // 
            // EPClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 470);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(648, 491);
            this.Name = "EPClient";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVGuns)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGVActions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dGVGuns;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dGVActions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ActionGun;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionBatchCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionOkCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActionNokCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GunId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GunCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GunIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn GunPort;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GunStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn connect;
    }
}

