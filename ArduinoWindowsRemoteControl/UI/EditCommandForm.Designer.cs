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
            this.components = new System.ComponentModel.Container();
            this.btSave = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.cbRemoteCommand = new System.Windows.Forms.ComboBox();
            this.lbRemoteCommand = new System.Windows.Forms.Label();
            this.rbCommandInput = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbNormalInput = new System.Windows.Forms.RadioButton();
            this.tbCommand = new ArduinoWindowsRemoteControl.UI.KeyboardCommandTextBox();
            this.keyboardCommandTextBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyboardCommandTextBoxBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(344, 164);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 3;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(428, 164);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 4;
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
            this.cbRemoteCommand.TabIndex = 1;
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
            // rbCommandInput
            // 
            this.rbCommandInput.AutoSize = true;
            this.rbCommandInput.Checked = true;
            this.rbCommandInput.Location = new System.Drawing.Point(6, 20);
            this.rbCommandInput.Name = "rbCommandInput";
            this.rbCommandInput.Size = new System.Drawing.Size(119, 20);
            this.rbCommandInput.TabIndex = 6;
            this.rbCommandInput.TabStop = true;
            this.rbCommandInput.Text = "Command Input";
            this.rbCommandInput.UseVisualStyleBackColor = true;
            this.rbCommandInput.CheckedChanged += new System.EventHandler(this.rbCommandInput_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbNormalInput);
            this.groupBox1.Controls.Add(this.rbCommandInput);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(156, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 47);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode:";
            // 
            // rbNormalInput
            // 
            this.rbNormalInput.AutoSize = true;
            this.rbNormalInput.Location = new System.Drawing.Point(142, 20);
            this.rbNormalInput.Name = "rbNormalInput";
            this.rbNormalInput.Size = new System.Drawing.Size(169, 20);
            this.rbNormalInput.TabIndex = 7;
            this.rbNormalInput.TabStop = true;
            this.rbNormalInput.Text = "Edit Command (Normal)";
            this.rbNormalInput.UseVisualStyleBackColor = true;
            // 
            // tbCommand
            // 
            this.tbCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCommand.IsCommandInput = true;
            this.tbCommand.Location = new System.Drawing.Point(12, 76);
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(491, 22);
            this.tbCommand.TabIndex = 2;
            // 
            // keyboardCommandTextBoxBindingSource
            // 
            this.keyboardCommandTextBoxBindingSource.DataSource = typeof(ArduinoWindowsRemoteControl.UI.KeyboardCommandTextBox);
            // 
            // EditCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 199);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbCommand);
            this.Controls.Add(this.lbRemoteCommand);
            this.Controls.Add(this.cbRemoteCommand);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditCommandForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Command";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyboardCommandTextBoxBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ComboBox cbRemoteCommand;
        private System.Windows.Forms.Label lbRemoteCommand;
        private KeyboardCommandTextBox tbCommand;
        private System.Windows.Forms.RadioButton rbCommandInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbNormalInput;
        private System.Windows.Forms.BindingSource keyboardCommandTextBoxBindingSource;
    }
}