namespace NightreignSaveManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bttn_save = new System.Windows.Forms.Button();
            this.bttn_restoreSaves = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttn_save
            // 
            this.bttn_save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttn_save.Location = new System.Drawing.Point(617, 12);
            this.bttn_save.Name = "bttn_save";
            this.bttn_save.Size = new System.Drawing.Size(171, 45);
            this.bttn_save.TabIndex = 0;
            this.bttn_save.Text = "Save";
            this.bttn_save.UseVisualStyleBackColor = true;
            this.bttn_save.Click += new System.EventHandler(this.bttn_save_Click);
            // 
            // bttn_restoreSaves
            // 
            this.bttn_restoreSaves.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttn_restoreSaves.Location = new System.Drawing.Point(617, 63);
            this.bttn_restoreSaves.Name = "bttn_restoreSaves";
            this.bttn_restoreSaves.Size = new System.Drawing.Size(171, 45);
            this.bttn_restoreSaves.TabIndex = 1;
            this.bttn_restoreSaves.Text = "Restore Saves";
            this.bttn_restoreSaves.UseVisualStyleBackColor = true;
            this.bttn_restoreSaves.Click += new System.EventHandler(this.bttn_restoreSaves_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttn_restoreSaves);
            this.Controls.Add(this.bttn_save);
            this.Name = "MainForm";
            this.Text = "Nightreign Save Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private Button bttn_save;
        private Button bttn_restoreSaves;
    }
}