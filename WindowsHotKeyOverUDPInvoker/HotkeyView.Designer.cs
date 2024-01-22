namespace WindowsHotKeyOverUDPInvoker
{
    partial class HotkeyView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.idtext = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.recordkeylabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.recordbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // idtext
            // 
            this.idtext.Location = new System.Drawing.Point(20, 44);
            this.idtext.Name = "idtext";
            this.idtext.Size = new System.Drawing.Size(152, 20);
            this.idtext.TabIndex = 1;
            this.idtext.TextChanged += new System.EventHandler(this.idtext_TextChanged);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(424, 18);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 2;
            this.delete.Text = "delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // recordkeylabel
            // 
            this.recordkeylabel.AutoSize = true;
            this.recordkeylabel.Location = new System.Drawing.Point(282, 83);
            this.recordkeylabel.Name = "recordkeylabel";
            this.recordkeylabel.Size = new System.Drawing.Size(69, 13);
            this.recordkeylabel.TabIndex = 4;
            this.recordkeylabel.Text = "recorded key";
            // 
            // recordbutton
            // 
            this.recordbutton.Location = new System.Drawing.Point(424, 83);
            this.recordbutton.Name = "recordbutton";
            this.recordbutton.Size = new System.Drawing.Size(75, 23);
            this.recordbutton.TabIndex = 5;
            this.recordbutton.Text = "record key";
            this.recordbutton.UseVisualStyleBackColor = true;
            this.recordbutton.Click += new System.EventHandler(this.recordhotkey_Click);
            this.recordbutton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            this.recordbutton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form_KeyUp);
            // 
            // HotkeyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.recordbutton);
            this.Controls.Add(this.recordkeylabel);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.idtext);
            this.Controls.Add(this.label1);
            this.Name = "HotkeyView";
            this.Size = new System.Drawing.Size(542, 126);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idtext;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Label recordkeylabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button recordbutton;
    }
}
