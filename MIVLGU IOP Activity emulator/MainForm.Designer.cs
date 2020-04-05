namespace MIVLGU_IOP_Activity_emulator
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
            this.lbLog = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRandomTimestamp = new System.Windows.Forms.CheckBox();
            this.bStop = new System.Windows.Forms.Button();
            this.cbAutoLoginIfDisconnected = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLog
            // 
            this.lbLog.FormattingEnabled = true;
            this.lbLog.Location = new System.Drawing.Point(12, 12);
            this.lbLog.Name = "lbLog";
            this.lbLog.Size = new System.Drawing.Size(398, 290);
            this.lbLog.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your IOP Login:";
            // 
            // tbLogin
            // 
            this.tbLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLogin.Location = new System.Drawing.Point(6, 25);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(147, 20);
            this.tbLogin.TabIndex = 2;
            this.tbLogin.Text = "pks-117-student";
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Location = new System.Drawing.Point(6, 64);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(147, 20);
            this.tbPassword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your IOP Password:";
            // 
            // bStart
            // 
            this.bStart.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.bStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStart.Location = new System.Drawing.Point(6, 99);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(147, 23);
            this.bStart.TabIndex = 5;
            this.bStart.Text = "Start Emulate Session";
            this.bStart.UseVisualStyleBackColor = false;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bStop);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.bStart);
            this.panel1.Controls.Add(this.tbLogin);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(416, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 156);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbAutoLoginIfDisconnected);
            this.panel2.Controls.Add(this.cbRandomTimestamp);
            this.panel2.Location = new System.Drawing.Point(416, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 99);
            this.panel2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(420, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Login:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Settings:";
            // 
            // cbRandomTimestamp
            // 
            this.cbRandomTimestamp.AutoSize = true;
            this.cbRandomTimestamp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbRandomTimestamp.Location = new System.Drawing.Point(2, 3);
            this.cbRandomTimestamp.Name = "cbRandomTimestamp";
            this.cbRandomTimestamp.Size = new System.Drawing.Size(120, 17);
            this.cbRandomTimestamp.TabIndex = 0;
            this.cbRandomTimestamp.Text = "Random Timestamp";
            this.cbRandomTimestamp.UseVisualStyleBackColor = false;
            // 
            // bStop
            // 
            this.bStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStop.Location = new System.Drawing.Point(6, 128);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(147, 23);
            this.bStop.TabIndex = 6;
            this.bStop.Text = "Stop Emulate Session";
            this.bStop.UseVisualStyleBackColor = false;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // cbAutoLoginIfDisconnected
            // 
            this.cbAutoLoginIfDisconnected.AutoSize = true;
            this.cbAutoLoginIfDisconnected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cbAutoLoginIfDisconnected.Location = new System.Drawing.Point(2, 26);
            this.cbAutoLoginIfDisconnected.Name = "cbAutoLoginIfDisconnected";
            this.cbAutoLoginIfDisconnected.Size = new System.Drawing.Size(148, 17);
            this.cbAutoLoginIfDisconnected.TabIndex = 1;
            this.cbAutoLoginIfDisconnected.Text = "Auto login if disconnected";
            this.cbAutoLoginIfDisconnected.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 314);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "MIVLGU IOP Activity Emulator. By F11GAR0";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbAutoLoginIfDisconnected;
        private System.Windows.Forms.CheckBox cbRandomTimestamp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

