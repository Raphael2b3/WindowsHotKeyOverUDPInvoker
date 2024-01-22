namespace WindowsHotKeyOverUDPInvoker
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
            this.label2 = new System.Windows.Forms.Label();
            this.porttext = new System.Windows.Forms.TextBox();
            this.hostip = new System.Windows.Forms.TextBox();
            this.reload_server = new System.Windows.Forms.Button();
            this.addnewhotkey = new System.Windows.Forms.Button();
            this.hotkeylist = new System.Windows.Forms.FlowLayoutPanel();
            this.runningindic = new System.Windows.Forms.Label();
            this.stop = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.logfield = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PORT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "HOST IP";
            // 
            // porttext
            // 
            this.porttext.Location = new System.Drawing.Point(113, 27);
            this.porttext.Name = "porttext";
            this.porttext.Size = new System.Drawing.Size(115, 20);
            this.porttext.TabIndex = 2;
            this.porttext.TextChanged += new System.EventHandler(this.porttext_TextChanged);
            // 
            // hostip
            // 
            this.hostip.Location = new System.Drawing.Point(113, 63);
            this.hostip.Name = "hostip";
            this.hostip.Size = new System.Drawing.Size(115, 20);
            this.hostip.TabIndex = 3;
            this.hostip.TextChanged += new System.EventHandler(this.hostip_TextChanged);
            // 
            // reload_server
            // 
            this.reload_server.Location = new System.Drawing.Point(455, 25);
            this.reload_server.Name = "reload_server";
            this.reload_server.Size = new System.Drawing.Size(101, 23);
            this.reload_server.TabIndex = 4;
            this.reload_server.Text = "Reload/Start";
            this.reload_server.UseVisualStyleBackColor = true;
            this.reload_server.Click += new System.EventHandler(this.reload_server_Click);
            // 
            // addnewhotkey
            // 
            this.addnewhotkey.Location = new System.Drawing.Point(575, 148);
            this.addnewhotkey.Name = "addnewhotkey";
            this.addnewhotkey.Size = new System.Drawing.Size(101, 23);
            this.addnewhotkey.TabIndex = 5;
            this.addnewhotkey.Text = "add hotkey";
            this.addnewhotkey.UseVisualStyleBackColor = true;
            this.addnewhotkey.Click += new System.EventHandler(this.addnewhotkey_Click);
            // 
            // hotkeylist
            // 
            this.hotkeylist.AutoScroll = true;
            this.hotkeylist.Location = new System.Drawing.Point(27, 177);
            this.hotkeylist.Name = "hotkeylist";
            this.hotkeylist.Size = new System.Drawing.Size(756, 243);
            this.hotkeylist.TabIndex = 6;
            // 
            // runningindic
            // 
            this.runningindic.AutoSize = true;
            this.runningindic.Location = new System.Drawing.Point(572, 27);
            this.runningindic.Name = "runningindic";
            this.runningindic.Size = new System.Drawing.Size(42, 13);
            this.runningindic.TabIndex = 8;
            this.runningindic.Text = "running";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(455, 58);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(101, 23);
            this.stop.TabIndex = 9;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(682, 148);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(101, 23);
            this.save.TabIndex = 10;
            this.save.Text = "Save All";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Logs:";
            // 
            // logfield
            // 
            this.logfield.Location = new System.Drawing.Point(233, 31);
            this.logfield.Name = "logfield";
            this.logfield.Size = new System.Drawing.Size(216, 139);
            this.logfield.TabIndex = 13;
            this.logfield.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logfield);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.save);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.runningindic);
            this.Controls.Add(this.hotkeylist);
            this.Controls.Add(this.addnewhotkey);
            this.Controls.Add(this.reload_server);
            this.Controls.Add(this.hostip);
            this.Controls.Add(this.porttext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox porttext;
        private System.Windows.Forms.TextBox hostip;
        private System.Windows.Forms.Button reload_server;
        private System.Windows.Forms.Button addnewhotkey;
        private System.Windows.Forms.FlowLayoutPanel hotkeylist;
        private System.Windows.Forms.Label runningindic;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox logfield;
    }
}