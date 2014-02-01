namespace SvettigPlugin
{
    partial class ActivityMappingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSTActivity = new System.Windows.Forms.Label();
            this.cbSvettigCategory = new System.Windows.Forms.ComboBox();
            this.cbSvettigSubcategory = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblSTActivity
            // 
            this.lblSTActivity.AutoSize = true;
            this.lblSTActivity.Location = new System.Drawing.Point(3, 6);
            this.lblSTActivity.Name = "lblSTActivity";
            this.lblSTActivity.Size = new System.Drawing.Size(0, 13);
            this.lblSTActivity.TabIndex = 0;
            // 
            // cbSvettigCategory
            // 
            this.cbSvettigCategory.FormattingEnabled = true;
            this.cbSvettigCategory.Location = new System.Drawing.Point(278, 3);
            this.cbSvettigCategory.Name = "cbSvettigCategory";
            this.cbSvettigCategory.Size = new System.Drawing.Size(200, 21);
            this.cbSvettigCategory.TabIndex = 1;
            this.cbSvettigCategory.SelectedIndexChanged += new System.EventHandler(this.cbSvettigCategory_SelectedIndexChanged);
            // 
            // cbSvettigSubcategory
            // 
            this.cbSvettigSubcategory.FormattingEnabled = true;
            this.cbSvettigSubcategory.Location = new System.Drawing.Point(494, 3);
            this.cbSvettigSubcategory.Name = "cbSvettigSubcategory";
            this.cbSvettigSubcategory.Size = new System.Drawing.Size(200, 21);
            this.cbSvettigSubcategory.TabIndex = 2;
            this.cbSvettigSubcategory.SelectedIndexChanged += new System.EventHandler(this.cbSvettigSubcategory_SelectedIndexChanged);
            // 
            // ActivityMappingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbSvettigSubcategory);
            this.Controls.Add(this.cbSvettigCategory);
            this.Controls.Add(this.lblSTActivity);
            this.Name = "ActivityMappingControl";
            this.Size = new System.Drawing.Size(720, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSTActivity;
        private System.Windows.Forms.ComboBox cbSvettigCategory;
        private System.Windows.Forms.ComboBox cbSvettigSubcategory;
    }
}
