namespace NumberToChinese
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb_input = new System.Windows.Forms.TextBox();
            this.lb_Output = new System.Windows.Forms.Label();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.lb_version = new System.Windows.Forms.Label();
            this.lb_hadCopyed_info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_input
            // 
            this.tb_input.ForeColor = System.Drawing.SystemColors.GrayText;
            resources.ApplyResources(this.tb_input, "tb_input");
            this.tb_input.Name = "tb_input";
            this.tb_input.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_input_KeyUp);
            // 
            // lb_Output
            // 
            this.lb_Output.AutoEllipsis = true;
            resources.ApplyResources(this.lb_Output, "lb_Output");
            this.lb_Output.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lb_Output.Name = "lb_Output";
            // 
            // btn_Copy
            // 
            this.btn_Copy.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Copy.FlatAppearance.BorderColor = System.Drawing.Color.PaleGreen;
            this.btn_Copy.FlatAppearance.BorderSize = 0;
            this.btn_Copy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_Copy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue;
            resources.ApplyResources(this.btn_Copy, "btn_Copy");
            this.btn_Copy.ForeColor = System.Drawing.Color.AliceBlue;
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.UseVisualStyleBackColor = false;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // lb_version
            // 
            resources.ApplyResources(this.lb_version, "lb_version");
            this.lb_version.Name = "lb_version";
            this.lb_version.Click += new System.EventHandler(this.lb_version_Click);
            // 
            // lb_hadCopyed_info
            // 
            resources.ApplyResources(this.lb_hadCopyed_info, "lb_hadCopyed_info");
            this.lb_hadCopyed_info.ForeColor = System.Drawing.Color.Black;
            this.lb_hadCopyed_info.Name = "lb_hadCopyed_info";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_hadCopyed_info);
            this.Controls.Add(this.lb_version);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.lb_Output);
            this.Controls.Add(this.tb_input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tb_input;
        private System.Windows.Forms.Label lb_Output;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Label lb_version;
        private System.Windows.Forms.Label lb_hadCopyed_info;
    }
}

