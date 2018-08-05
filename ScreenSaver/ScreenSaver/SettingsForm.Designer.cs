namespace ScreenSaver
{
    partial class SettingsForm
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
            this.multiMonitorChxBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.trSettingsOpacity = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSettingsOpacity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trSettingsOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // multiMonitorChxBox
            // 
            this.multiMonitorChxBox.AutoSize = true;
            this.multiMonitorChxBox.Location = new System.Drawing.Point(13, 13);
            this.multiMonitorChxBox.Name = "multiMonitorChxBox";
            this.multiMonitorChxBox.Size = new System.Drawing.Size(85, 17);
            this.multiMonitorChxBox.TabIndex = 1;
            this.multiMonitorChxBox.Text = "Multi monitor";
            this.multiMonitorChxBox.UseVisualStyleBackColor = true;
            this.multiMonitorChxBox.CheckedChanged += new System.EventHandler(this.multiMonitorChxBox_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(701, 269);
            this.tabControl1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 311);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 35;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Location = new System.Drawing.Point(93, 311);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(75, 23);
            this.btnUndo.TabIndex = 52;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnDefaults
            // 
            this.btnDefaults.Location = new System.Drawing.Point(557, 311);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(75, 23);
            this.btnDefaults.TabIndex = 51;
            this.btnDefaults.Text = "Defaults";
            this.btnDefaults.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(638, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // trSettingsOpacity
            // 
            this.trSettingsOpacity.LargeChange = 10;
            this.trSettingsOpacity.Location = new System.Drawing.Point(314, 316);
            this.trSettingsOpacity.Maximum = 100;
            this.trSettingsOpacity.Minimum = 10;
            this.trSettingsOpacity.Name = "trSettingsOpacity";
            this.trSettingsOpacity.Size = new System.Drawing.Size(237, 45);
            this.trSettingsOpacity.SmallChange = 10;
            this.trSettingsOpacity.TabIndex = 54;
            this.trSettingsOpacity.TickFrequency = 5;
            this.trSettingsOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trSettingsOpacity.Value = 50;
            this.trSettingsOpacity.Scroll += new System.EventHandler(this.trSettingsOpacity_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 316);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "Settings opacity";
            // 
            // tbSettingsOpacity
            // 
            this.tbSettingsOpacity.Location = new System.Drawing.Point(275, 316);
            this.tbSettingsOpacity.Name = "tbSettingsOpacity";
            this.tbSettingsOpacity.Size = new System.Drawing.Size(33, 20);
            this.tbSettingsOpacity.TabIndex = 56;
            this.tbSettingsOpacity.Validated += new System.EventHandler(this.tbSettingsOpacity_Validated);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 340);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnDefaults);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.trSettingsOpacity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbSettingsOpacity);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.multiMonitorChxBox);
            this.Controls.Add(this.tabControl1);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trSettingsOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox multiMonitorChxBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnDefaults;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TrackBar trSettingsOpacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSettingsOpacity;
    }
}