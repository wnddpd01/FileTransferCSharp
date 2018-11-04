namespace Software3
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.IpLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.PortTb = new System.Windows.Forms.TextBox();
            this.IpTb = new System.Windows.Forms.TextBox();
            this.FSPLabel = new System.Windows.Forms.Label();
            this.FSPTb = new System.Windows.Forms.TextBox();
            this.Btn_Path = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_start = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(12, 22);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(24, 12);
            this.IpLabel.TabIndex = 0;
            this.IpLabel.Text = "IP :";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(267, 22);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(34, 12);
            this.PortLabel.TabIndex = 1;
            this.PortLabel.Text = "port :";
            // 
            // PortTb
            // 
            this.PortTb.Location = new System.Drawing.Point(307, 19);
            this.PortTb.Name = "PortTb";
            this.PortTb.Size = new System.Drawing.Size(100, 21);
            this.PortTb.TabIndex = 2;
            // 
            // IpTb
            // 
            this.IpTb.Enabled = false;
            this.IpTb.Location = new System.Drawing.Point(42, 19);
            this.IpTb.Name = "IpTb";
            this.IpTb.Size = new System.Drawing.Size(199, 21);
            this.IpTb.TabIndex = 3;
            // 
            // FSPLabel
            // 
            this.FSPLabel.AutoSize = true;
            this.FSPLabel.Location = new System.Drawing.Point(12, 77);
            this.FSPLabel.Name = "FSPLabel";
            this.FSPLabel.Size = new System.Drawing.Size(109, 12);
            this.FSPLabel.TabIndex = 4;
            this.FSPLabel.Text = "File Storage Path :";
            // 
            // FSPTb
            // 
            this.FSPTb.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.FSPTb.Location = new System.Drawing.Point(42, 92);
            this.FSPTb.Name = "FSPTb";
            this.FSPTb.ReadOnly = true;
            this.FSPTb.Size = new System.Drawing.Size(259, 21);
            this.FSPTb.TabIndex = 5;
            // 
            // Btn_Path
            // 
            this.Btn_Path.Location = new System.Drawing.Point(307, 92);
            this.Btn_Path.Name = "Btn_Path";
            this.Btn_Path.Size = new System.Drawing.Size(75, 23);
            this.Btn_Path.TabIndex = 6;
            this.Btn_Path.Text = "Path";
            this.Btn_Path.UseVisualStyleBackColor = true;
            this.Btn_Path.Click += new System.EventHandler(this.Btn_Path_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(177, 136);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(124, 60);
            this.btn_start.TabIndex = 7;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // log
            // 
            this.log.Enabled = false;
            this.log.Location = new System.Drawing.Point(33, 214);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(393, 175);
            this.log.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 476);
            this.Controls.Add(this.log);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.Btn_Path);
            this.Controls.Add(this.FSPTb);
            this.Controls.Add(this.FSPLabel);
            this.Controls.Add(this.IpTb);
            this.Controls.Add(this.PortTb);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.IpLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox PortTb;
        private System.Windows.Forms.TextBox IpTb;
        private System.Windows.Forms.Label FSPLabel;
        private System.Windows.Forms.TextBox FSPTb;
        private System.Windows.Forms.Button Btn_Path;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox log;
    }
}

