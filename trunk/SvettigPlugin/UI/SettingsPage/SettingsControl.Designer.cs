namespace SvettigPlugin
{
    partial class SettingsControl
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.gbAccount = new System.Windows.Forms.GroupBox();
            this.actMappingsGroupBox = new System.Windows.Forms.GroupBox();
            this.actMappingsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.equipmentMappingsGroupBox = new System.Windows.Forms.GroupBox();
            this.eqMappingsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.svettigPictureBox = new System.Windows.Forms.PictureBox();
            this.checkHiddenComment = new System.Windows.Forms.CheckBox();
            this.gbExportInfo = new System.Windows.Forms.GroupBox();
            this.gbAccount.SuspendLayout();
            this.actMappingsGroupBox.SuspendLayout();
            this.equipmentMappingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svettigPictureBox)).BeginInit();
            this.gbExportInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(6, 17);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(148, 17);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(151, 36);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(146, 20);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(9, 36);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(136, 20);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // gbAccount
            // 
            this.gbAccount.Controls.Add(this.lblPassword);
            this.gbAccount.Controls.Add(this.txtUsername);
            this.gbAccount.Controls.Add(this.txtPassword);
            this.gbAccount.Controls.Add(this.lblUsername);
            this.gbAccount.Location = new System.Drawing.Point(3, 3);
            this.gbAccount.Name = "gbAccount";
            this.gbAccount.Size = new System.Drawing.Size(303, 71);
            this.gbAccount.TabIndex = 4;
            this.gbAccount.TabStop = false;
            this.gbAccount.Text = "Account information";
            // 
            // actMappingsGroupBox
            // 
            this.actMappingsGroupBox.AutoSize = true;
            this.actMappingsGroupBox.Controls.Add(this.actMappingsFlowLayoutPanel);
            this.actMappingsGroupBox.Location = new System.Drawing.Point(3, 80);
            this.actMappingsGroupBox.Name = "actMappingsGroupBox";
            this.actMappingsGroupBox.Size = new System.Drawing.Size(760, 107);
            this.actMappingsGroupBox.TabIndex = 5;
            this.actMappingsGroupBox.TabStop = false;
            this.actMappingsGroupBox.Text = "Activity Mappings";
            // 
            // actMappingsFlowLayoutPanel
            // 
            this.actMappingsFlowLayoutPanel.AutoScroll = true;
            this.actMappingsFlowLayoutPanel.AutoSize = true;
            this.actMappingsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actMappingsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.actMappingsFlowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.actMappingsFlowLayoutPanel.Name = "actMappingsFlowLayoutPanel";
            this.actMappingsFlowLayoutPanel.Size = new System.Drawing.Size(754, 88);
            this.actMappingsFlowLayoutPanel.TabIndex = 6;
            this.actMappingsFlowLayoutPanel.WrapContents = false;
            // 
            // equipmentMappingsGroupBox
            // 
            this.equipmentMappingsGroupBox.AutoSize = true;
            this.equipmentMappingsGroupBox.Controls.Add(this.eqMappingsFlowLayoutPanel);
            this.equipmentMappingsGroupBox.Location = new System.Drawing.Point(3, 193);
            this.equipmentMappingsGroupBox.Name = "equipmentMappingsGroupBox";
            this.equipmentMappingsGroupBox.Size = new System.Drawing.Size(760, 107);
            this.equipmentMappingsGroupBox.TabIndex = 8;
            this.equipmentMappingsGroupBox.TabStop = false;
            this.equipmentMappingsGroupBox.Text = "Equipment Mappings (shoes, bikes)";
            // 
            // eqMappingsFlowLayoutPanel
            // 
            this.eqMappingsFlowLayoutPanel.AutoScroll = true;
            this.eqMappingsFlowLayoutPanel.AutoSize = true;
            this.eqMappingsFlowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.eqMappingsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eqMappingsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.eqMappingsFlowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.eqMappingsFlowLayoutPanel.Name = "eqMappingsFlowLayoutPanel";
            this.eqMappingsFlowLayoutPanel.Size = new System.Drawing.Size(754, 88);
            this.eqMappingsFlowLayoutPanel.TabIndex = 6;
            this.eqMappingsFlowLayoutPanel.WrapContents = false;
            // 
            // svettigPictureBox
            // 
            this.svettigPictureBox.Image = global::SvettigPlugin.Properties.Resources.SvettigLogo;
            this.svettigPictureBox.InitialImage = null;
            this.svettigPictureBox.Location = new System.Drawing.Point(658, 10);
            this.svettigPictureBox.Name = "svettigPictureBox";
            this.svettigPictureBox.Size = new System.Drawing.Size(64, 64);
            this.svettigPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.svettigPictureBox.TabIndex = 10;
            this.svettigPictureBox.TabStop = false;
            // 
            // checkHiddenComment
            // 
            this.checkHiddenComment.AutoSize = true;
            this.checkHiddenComment.Location = new System.Drawing.Point(20, 29);
            this.checkHiddenComment.Name = "checkHiddenComment";
            this.checkHiddenComment.Size = new System.Drawing.Size(149, 17);
            this.checkHiddenComment.TabIndex = 11;
            this.checkHiddenComment.Text = "Export to hidden comment";
            this.checkHiddenComment.UseVisualStyleBackColor = true;
            this.checkHiddenComment.CheckedChanged += new System.EventHandler(this.checkHiddenComment_CheckedChanged);
            // 
            // gbExportInfo
            // 
            this.gbExportInfo.Controls.Add(this.checkHiddenComment);
            this.gbExportInfo.Location = new System.Drawing.Point(312, 3);
            this.gbExportInfo.Name = "gbExportInfo";
            this.gbExportInfo.Size = new System.Drawing.Size(303, 71);
            this.gbExportInfo.TabIndex = 5;
            this.gbExportInfo.TabStop = false;
            this.gbExportInfo.Text = "Generic export settings";
            // 
            // SettingsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.gbExportInfo);
            this.Controls.Add(this.svettigPictureBox);
            this.Controls.Add(this.equipmentMappingsGroupBox);
            this.Controls.Add(this.actMappingsGroupBox);
            this.Controls.Add(this.gbAccount);
            this.Name = "SettingsControl";
            this.Size = new System.Drawing.Size(770, 318);
            this.gbAccount.ResumeLayout(false);
            this.gbAccount.PerformLayout();
            this.actMappingsGroupBox.ResumeLayout(false);
            this.actMappingsGroupBox.PerformLayout();
            this.equipmentMappingsGroupBox.ResumeLayout(false);
            this.equipmentMappingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.svettigPictureBox)).EndInit();
            this.gbExportInfo.ResumeLayout(false);
            this.gbExportInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.GroupBox gbAccount;
        private System.Windows.Forms.GroupBox actMappingsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel actMappingsFlowLayoutPanel;
        private System.Windows.Forms.GroupBox equipmentMappingsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel eqMappingsFlowLayoutPanel;
        private System.Windows.Forms.PictureBox svettigPictureBox;
        private System.Windows.Forms.CheckBox checkHiddenComment;
        private System.Windows.Forms.GroupBox gbExportInfo;
    }
}
