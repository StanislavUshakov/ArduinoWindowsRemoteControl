namespace ArduinoWindowsRemoteControl.UI
{
    partial class EditCommandForm
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
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.cbRemoteCommand = new System.Windows.Forms.ComboBox();
            this.lbRemoteCommand = new System.Windows.Forms.Label();
            this.tbCommand = new ArduinoWindowsRemoteControl.UI.KeyboardCommandTextBox(true);
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(344, 164);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(428, 164);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 1;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // cbRemoteCommand
            // 
            this.cbRemoteCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRemoteCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbRemoteCommand.FormattingEnabled = true;
            this.cbRemoteCommand.Location = new System.Drawing.Point(12, 29);
            this.cbRemoteCommand.Name = "cbRemoteCommand";
            this.cbRemoteCommand.Size = new System.Drawing.Size(121, 24);
            this.cbRemoteCommand.TabIndex = 2;
            // 
            // lbRemoteCommand
            // 
            this.lbRemoteCommand.AutoSize = true;
            this.lbRemoteCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbRemoteCommand.Location = new System.Drawing.Point(12, 9);
            this.lbRemoteCommand.Name = "lbRemoteCommand";
            this.lbRemoteCommand.Size = new System.Drawing.Size(124, 16);
            this.lbRemoteCommand.TabIndex = 3;
            this.lbRemoteCommand.Text = "Remote Command:";
            // 
            // tbCommand
            // 
            this.tbCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCommand.Location = new System.Drawing.Point(151, 29);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(352, 22);
            this.tbCommand.TabIndex = 4;
            // 
            // EditCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 199);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.lbRemoteCommand);
            this.Controls.Add(this.cbRemoteCommand);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.Name = "Add Command For";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditCommandForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ComboBox cbRemoteCommand;
        private System.Windows.Forms.Label lbRemoteCommand;
        private System.Windows.Forms.TextBox tbCommand;
    }
}