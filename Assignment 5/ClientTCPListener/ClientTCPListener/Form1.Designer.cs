namespace ClientTCPListener
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnconnect = new System.Windows.Forms.Button();
            this.lbxmsgs = new System.Windows.Forms.ListBox();
            this.txtmsg = new System.Windows.Forms.TextBox();
            this.btsend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Not Connected";
            // 
            // btnconnect
            // 
            this.btnconnect.Location = new System.Drawing.Point(179, 2);
            this.btnconnect.Name = "btnconnect";
            this.btnconnect.Size = new System.Drawing.Size(99, 31);
            this.btnconnect.TabIndex = 1;
            this.btnconnect.Text = "Connect";
            this.btnconnect.UseVisualStyleBackColor = true;
            this.btnconnect.Click += new System.EventHandler(this.btnconnect_Click);
            // 
            // lbxmsgs
            // 
            this.lbxmsgs.FormattingEnabled = true;
            this.lbxmsgs.ItemHeight = 24;
            this.lbxmsgs.Location = new System.Drawing.Point(3, 104);
            this.lbxmsgs.Name = "lbxmsgs";
            this.lbxmsgs.Size = new System.Drawing.Size(286, 292);
            this.lbxmsgs.TabIndex = 2;
            // 
            // txtmsg
            // 
            this.txtmsg.Location = new System.Drawing.Point(16, 36);
            this.txtmsg.Name = "txtmsg";
            this.txtmsg.Size = new System.Drawing.Size(260, 29);
            this.txtmsg.TabIndex = 3;
            // 
            // btsend
            // 
            this.btsend.Location = new System.Drawing.Point(16, 71);
            this.btsend.Name = "btsend";
            this.btsend.Size = new System.Drawing.Size(99, 31);
            this.btsend.TabIndex = 4;
            this.btsend.Text = "Send";
            this.btsend.UseVisualStyleBackColor = true;
            this.btsend.Click += new System.EventHandler(this.btsend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 393);
            this.Controls.Add(this.btsend);
            this.Controls.Add(this.txtmsg);
            this.Controls.Add(this.lbxmsgs);
            this.Controls.Add(this.btnconnect);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnconnect;
        private System.Windows.Forms.ListBox lbxmsgs;
        private System.Windows.Forms.TextBox txtmsg;
        private System.Windows.Forms.Button btsend;
    }
}

