namespace Client
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
            this.label_IP = new System.Windows.Forms.Label();
            this.label_Port = new System.Windows.Forms.Label();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.btn_FilePath = new System.Windows.Forms.Button();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_connect = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label_Path = new System.Windows.Forms.Label();
            this.label_File = new System.Windows.Forms.Label();
            this.textBox_Path = new System.Windows.Forms.TextBox();
            this.textBox_File = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label_IP
            // 
            this.label_IP.AutoSize = true;
            this.label_IP.Location = new System.Drawing.Point(32, 37);
            this.label_IP.Name = "label_IP";
            this.label_IP.Size = new System.Drawing.Size(24, 12);
            this.label_IP.TabIndex = 0;
            this.label_IP.Text = "IP :";
            // 
            // label_Port
            // 
            this.label_Port.AutoSize = true;
            this.label_Port.Location = new System.Drawing.Point(248, 37);
            this.label_Port.Name = "label_Port";
            this.label_Port.Size = new System.Drawing.Size(35, 12);
            this.label_Port.TabIndex = 1;
            this.label_Port.Text = "Port :";
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(76, 34);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(100, 21);
            this.textBox_IP.TabIndex = 2;
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(289, 34);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(100, 21);
            this.textBox_Port.TabIndex = 3;
            // 
            // btn_FilePath
            // 
            this.btn_FilePath.Location = new System.Drawing.Point(64, 82);
            this.btn_FilePath.Name = "btn_FilePath";
            this.btn_FilePath.Size = new System.Drawing.Size(75, 23);
            this.btn_FilePath.TabIndex = 4;
            this.btn_FilePath.Text = "File Path";
            this.btn_FilePath.UseVisualStyleBackColor = true;
            this.btn_FilePath.Click += new System.EventHandler(this.btn_FilePath_Click);
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Location = new System.Drawing.Point(173, 82);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectFile.TabIndex = 5;
            this.btn_SelectFile.Text = "Select File";
            this.btn_SelectFile.UseVisualStyleBackColor = true;
            this.btn_SelectFile.Click += new System.EventHandler(this.btn_SelectFile_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(289, 82);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 6;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(64, 111);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(300, 23);
            this.btn_connect.TabIndex = 7;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(55, 231);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(309, 205);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listview_dc);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(55, 202);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(309, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 9;
            // 
            // label_Path
            // 
            this.label_Path.AutoSize = true;
            this.label_Path.Location = new System.Drawing.Point(63, 149);
            this.label_Path.Name = "label_Path";
            this.label_Path.Size = new System.Drawing.Size(30, 12);
            this.label_Path.TabIndex = 10;
            this.label_Path.Text = "Path";
            // 
            // label_File
            // 
            this.label_File.AutoSize = true;
            this.label_File.Location = new System.Drawing.Point(63, 176);
            this.label_File.Name = "label_File";
            this.label_File.Size = new System.Drawing.Size(25, 12);
            this.label_File.TabIndex = 11;
            this.label_File.Text = "File";
            // 
            // textBox_Path
            // 
            this.textBox_Path.Enabled = false;
            this.textBox_Path.Location = new System.Drawing.Point(107, 146);
            this.textBox_Path.Name = "textBox_Path";
            this.textBox_Path.Size = new System.Drawing.Size(226, 21);
            this.textBox_Path.TabIndex = 12;
            // 
            // textBox_File
            // 
            this.textBox_File.Enabled = false;
            this.textBox_File.Location = new System.Drawing.Point(107, 173);
            this.textBox_File.Name = "textBox_File";
            this.textBox_File.Size = new System.Drawing.Size(226, 21);
            this.textBox_File.TabIndex = 13;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 480);
            this.Controls.Add(this.textBox_File);
            this.Controls.Add(this.textBox_Path);
            this.Controls.Add(this.label_File);
            this.Controls.Add(this.label_Path);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.btn_SelectFile);
            this.Controls.Add(this.btn_FilePath);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.label_Port);
            this.Controls.Add(this.label_IP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_IP;
        private System.Windows.Forms.Label label_Port;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Button btn_FilePath;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label_Path;
        private System.Windows.Forms.Label label_File;
        private System.Windows.Forms.TextBox textBox_Path;
        private System.Windows.Forms.TextBox textBox_File;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

