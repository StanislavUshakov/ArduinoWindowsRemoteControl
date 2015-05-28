namespace ArduinoWindowsRemoteControl
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btAddNew = new System.Windows.Forms.Button();
            this.commandListPanel = new System.Windows.Forms.Panel();
            this.mainTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.btAddNewApplication = new System.Windows.Forms.Button();
            this.lbApplication = new System.Windows.Forms.Label();
            this.cbApplication = new System.Windows.Forms.ComboBox();
            this.tbNewAppName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btAddNew
            // 
            this.btAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddNew.Location = new System.Drawing.Point(525, 269);
            this.btAddNew.Name = "btAddNew";
            this.btAddNew.Size = new System.Drawing.Size(174, 23);
            this.btAddNew.TabIndex = 0;
            this.btAddNew.Text = "Add new command";
            this.mainTooltip.SetToolTip(this.btAddNew, "Test");
            this.btAddNew.UseVisualStyleBackColor = true;
            this.btAddNew.Click += new System.EventHandler(this.btAddNew_Click);
            // 
            // commandListPanel
            // 
            this.commandListPanel.AutoScroll = true;
            this.commandListPanel.BackColor = System.Drawing.SystemColors.Control;
            this.commandListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commandListPanel.Location = new System.Drawing.Point(5, 39);
            this.commandListPanel.Name = "commandListPanel";
            this.commandListPanel.Size = new System.Drawing.Size(694, 224);
            this.commandListPanel.TabIndex = 1;
            // 
            // btAddNewApplication
            // 
            this.btAddNewApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btAddNewApplication.Location = new System.Drawing.Point(525, 6);
            this.btAddNewApplication.Name = "btAddNewApplication";
            this.btAddNewApplication.Size = new System.Drawing.Size(174, 23);
            this.btAddNewApplication.TabIndex = 5;
            this.btAddNewApplication.Text = "Add new application";
            this.mainTooltip.SetToolTip(this.btAddNewApplication, "Test");
            this.btAddNewApplication.UseVisualStyleBackColor = true;
            this.btAddNewApplication.Click += new System.EventHandler(this.btAddNewApplication_Click);
            // 
            // lbApplication
            // 
            this.lbApplication.AutoSize = true;
            this.lbApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbApplication.Location = new System.Drawing.Point(12, 9);
            this.lbApplication.Name = "lbApplication";
            this.lbApplication.Size = new System.Drawing.Size(78, 16);
            this.lbApplication.TabIndex = 2;
            this.lbApplication.Text = "Application:";
            // 
            // cbApplication
            // 
            this.cbApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbApplication.FormattingEnabled = true;
            this.cbApplication.Location = new System.Drawing.Point(96, 6);
            this.cbApplication.Name = "cbApplication";
            this.cbApplication.Size = new System.Drawing.Size(193, 24);
            this.cbApplication.TabIndex = 3;
            this.cbApplication.SelectedIndexChanged += new System.EventHandler(this.cbApplication_SelectedIndexChanged);
            // 
            // tbNewAppName
            // 
            this.tbNewAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNewAppName.Location = new System.Drawing.Point(340, 6);
            this.tbNewAppName.Name = "tbNewAppName";
            this.tbNewAppName.Size = new System.Drawing.Size(179, 22);
            this.tbNewAppName.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 299);
            this.Controls.Add(this.btAddNewApplication);
            this.Controls.Add(this.tbNewAppName);
            this.Controls.Add(this.cbApplication);
            this.Controls.Add(this.lbApplication);
            this.Controls.Add(this.commandListPanel);
            this.Controls.Add(this.btAddNew);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Windows Remote Control Center";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddNew;
        private System.Windows.Forms.Panel commandListPanel;
        private System.Windows.Forms.ToolTip mainTooltip;
        private System.Windows.Forms.Label lbApplication;
        private System.Windows.Forms.ComboBox cbApplication;
        private System.Windows.Forms.TextBox tbNewAppName;
        private System.Windows.Forms.Button btAddNewApplication;
    }
}

