namespace _02_Thread_生命周期管理
{
    partial class Main
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
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnInterrupt = new System.Windows.Forms.Button();
            this.btnResume = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(452, 186);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(75, 23);
            this.btnAbort.TabIndex = 3;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnInterrupt
            // 
            this.btnInterrupt.Location = new System.Drawing.Point(342, 186);
            this.btnInterrupt.Name = "btnInterrupt";
            this.btnInterrupt.Size = new System.Drawing.Size(75, 23);
            this.btnInterrupt.TabIndex = 4;
            this.btnInterrupt.Text = "Interrupt";
            this.btnInterrupt.UseVisualStyleBackColor = true;
            this.btnInterrupt.Click += new System.EventHandler(this.btnInterrupt_Click);
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(236, 186);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 5;
            this.btnResume.Text = "Resume";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnSuspend
            // 
            this.btnSuspend.Location = new System.Drawing.Point(131, 186);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(75, 23);
            this.btnSuspend.TabIndex = 6;
            this.btnSuspend.Text = "Suspend";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(29, 186);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(24, 22);
            this.txtNumber.Multiline = true;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(512, 129);
            this.txtNumber.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 256);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnInterrupt);
            this.Controls.Add(this.btnResume);
            this.Controls.Add(this.btnSuspend);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtNumber);
            this.Name = "Main";
            this.Text = "Thread实例方法介绍之生命周期管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Button btnInterrupt;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtNumber;
    }
}

