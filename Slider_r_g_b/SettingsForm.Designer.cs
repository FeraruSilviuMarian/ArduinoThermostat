namespace ArduinoThermostat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.exit_button = new System.Windows.Forms.Button();
            this.minimize_button = new System.Windows.Forms.Button();
            this.start_temperature_setting_trackbar = new System.Windows.Forms.TrackBar();
            this.start_temperature_target_setting_label = new System.Windows.Forms.Label();
            this.start_temperature_target_value_setting_label = new System.Windows.Forms.Label();
            this.temp_target_celsius_label = new System.Windows.Forms.Label();
            this.settingsForm_title = new System.Windows.Forms.Label();
            this.opacitySettingPercentage_label = new System.Windows.Forms.Label();
            this.opacitySettingValue_label = new System.Windows.Forms.Label();
            this.OpacitySetting_label = new System.Windows.Forms.Label();
            this.opacitySetting_trackbar = new System.Windows.Forms.TrackBar();
            this.useTrayIcon_checkbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.start_temperature_setting_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySetting_trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exit_button.Location = new System.Drawing.Point(742, 13);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(34, 23);
            this.exit_button.TabIndex = 13;
            this.exit_button.Text = "X";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // minimize_button
            // 
            this.minimize_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.minimize_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.minimize_button.Location = new System.Drawing.Point(702, 13);
            this.minimize_button.Name = "minimize_button";
            this.minimize_button.Size = new System.Drawing.Size(34, 23);
            this.minimize_button.TabIndex = 14;
            this.minimize_button.Text = "_";
            this.minimize_button.UseVisualStyleBackColor = true;
            this.minimize_button.Click += new System.EventHandler(this.Minimize_Button_Click);
            // 
            // start_temperature_setting_trackbar
            // 
            this.start_temperature_setting_trackbar.Location = new System.Drawing.Point(12, 112);
            this.start_temperature_setting_trackbar.Maximum = 50;
            this.start_temperature_setting_trackbar.Name = "start_temperature_setting_trackbar";
            this.start_temperature_setting_trackbar.Size = new System.Drawing.Size(765, 45);
            this.start_temperature_setting_trackbar.TabIndex = 15;
            this.start_temperature_setting_trackbar.Scroll += new System.EventHandler(this.Start_temperature_setting_trackbar_Scroll);
            // 
            // start_temperature_target_setting_label
            // 
            this.start_temperature_target_setting_label.AutoSize = true;
            this.start_temperature_target_setting_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_temperature_target_setting_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.start_temperature_target_setting_label.Location = new System.Drawing.Point(23, 84);
            this.start_temperature_target_setting_label.Name = "start_temperature_target_setting_label";
            this.start_temperature_target_setting_label.Size = new System.Drawing.Size(268, 25);
            this.start_temperature_target_setting_label.TabIndex = 36;
            this.start_temperature_target_setting_label.Text = "Starting temperature target";
            this.start_temperature_target_setting_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // start_temperature_target_value_setting_label
            // 
            this.start_temperature_target_value_setting_label.AutoSize = true;
            this.start_temperature_target_value_setting_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_temperature_target_value_setting_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.start_temperature_target_value_setting_label.Location = new System.Drawing.Point(297, 84);
            this.start_temperature_target_value_setting_label.Name = "start_temperature_target_value_setting_label";
            this.start_temperature_target_value_setting_label.Size = new System.Drawing.Size(36, 25);
            this.start_temperature_target_value_setting_label.TabIndex = 37;
            this.start_temperature_target_value_setting_label.Text = "21";
            this.start_temperature_target_value_setting_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // temp_target_celsius_label
            // 
            this.temp_target_celsius_label.AutoSize = true;
            this.temp_target_celsius_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temp_target_celsius_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.temp_target_celsius_label.Location = new System.Drawing.Point(326, 84);
            this.temp_target_celsius_label.Name = "temp_target_celsius_label";
            this.temp_target_celsius_label.Size = new System.Drawing.Size(35, 25);
            this.temp_target_celsius_label.TabIndex = 50;
            this.temp_target_celsius_label.Text = "°C";
            this.temp_target_celsius_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // settingsForm_title
            // 
            this.settingsForm_title.AutoSize = true;
            this.settingsForm_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsForm_title.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.settingsForm_title.Location = new System.Drawing.Point(12, 9);
            this.settingsForm_title.Name = "settingsForm_title";
            this.settingsForm_title.Size = new System.Drawing.Size(151, 39);
            this.settingsForm_title.TabIndex = 51;
            this.settingsForm_title.Text = "Settings";
            this.settingsForm_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // opacitySettingPercentage_label
            // 
            this.opacitySettingPercentage_label.AutoSize = true;
            this.opacitySettingPercentage_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opacitySettingPercentage_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.opacitySettingPercentage_label.Location = new System.Drawing.Point(340, 155);
            this.opacitySettingPercentage_label.Name = "opacitySettingPercentage_label";
            this.opacitySettingPercentage_label.Size = new System.Drawing.Size(31, 25);
            this.opacitySettingPercentage_label.TabIndex = 55;
            this.opacitySettingPercentage_label.Text = "%";
            this.opacitySettingPercentage_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // opacitySettingValue_label
            // 
            this.opacitySettingValue_label.AutoSize = true;
            this.opacitySettingValue_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opacitySettingValue_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.opacitySettingValue_label.Location = new System.Drawing.Point(297, 155);
            this.opacitySettingValue_label.Name = "opacitySettingValue_label";
            this.opacitySettingValue_label.Size = new System.Drawing.Size(48, 25);
            this.opacitySettingValue_label.TabIndex = 54;
            this.opacitySettingValue_label.Text = "100";
            this.opacitySettingValue_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // OpacitySetting_label
            // 
            this.OpacitySetting_label.AutoSize = true;
            this.OpacitySetting_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpacitySetting_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.OpacitySetting_label.Location = new System.Drawing.Point(23, 155);
            this.OpacitySetting_label.Name = "OpacitySetting_label";
            this.OpacitySetting_label.Size = new System.Drawing.Size(85, 25);
            this.OpacitySetting_label.TabIndex = 53;
            this.OpacitySetting_label.Text = "Opacity";
            this.OpacitySetting_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // opacitySetting_trackbar
            // 
            this.opacitySetting_trackbar.Location = new System.Drawing.Point(12, 183);
            this.opacitySetting_trackbar.Maximum = 100;
            this.opacitySetting_trackbar.Minimum = 10;
            this.opacitySetting_trackbar.Name = "opacitySetting_trackbar";
            this.opacitySetting_trackbar.Size = new System.Drawing.Size(765, 45);
            this.opacitySetting_trackbar.TabIndex = 52;
            this.opacitySetting_trackbar.Value = 10;
            this.opacitySetting_trackbar.Scroll += new System.EventHandler(this.OpacitySetting_trackbar_Scroll);
            // 
            // useTrayIcon_checkbox
            // 
            this.useTrayIcon_checkbox.AutoSize = true;
            this.useTrayIcon_checkbox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.useTrayIcon_checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useTrayIcon_checkbox.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.useTrayIcon_checkbox.Location = new System.Drawing.Point(28, 234);
            this.useTrayIcon_checkbox.Name = "useTrayIcon_checkbox";
            this.useTrayIcon_checkbox.Size = new System.Drawing.Size(246, 29);
            this.useTrayIcon_checkbox.TabIndex = 57;
            this.useTrayIcon_checkbox.Text = "Show system tray icon";
            this.useTrayIcon_checkbox.UseVisualStyleBackColor = true;
            this.useTrayIcon_checkbox.CheckedChanged += new System.EventHandler(this.UseTrayIcon_Checkbox_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(789, 417);
            this.Controls.Add(this.useTrayIcon_checkbox);
            this.Controls.Add(this.opacitySettingPercentage_label);
            this.Controls.Add(this.opacitySettingValue_label);
            this.Controls.Add(this.OpacitySetting_label);
            this.Controls.Add(this.opacitySetting_trackbar);
            this.Controls.Add(this.settingsForm_title);
            this.Controls.Add(this.temp_target_celsius_label);
            this.Controls.Add(this.start_temperature_target_value_setting_label);
            this.Controls.Add(this.start_temperature_target_setting_label);
            this.Controls.Add(this.start_temperature_setting_trackbar);
            this.Controls.Add(this.minimize_button);
            this.Controls.Add(this.exit_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            ((System.ComponentModel.ISupportInitialize)(this.start_temperature_setting_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySetting_trackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button minimize_button;
        private System.Windows.Forms.TrackBar start_temperature_setting_trackbar;
        private System.Windows.Forms.Label start_temperature_target_setting_label;
        private System.Windows.Forms.Label start_temperature_target_value_setting_label;
        private System.Windows.Forms.Label temp_target_celsius_label;
        private System.Windows.Forms.Label settingsForm_title;
        private System.Windows.Forms.Label opacitySettingPercentage_label;
        private System.Windows.Forms.Label opacitySettingValue_label;
        private System.Windows.Forms.Label OpacitySetting_label;
        private System.Windows.Forms.TrackBar opacitySetting_trackbar;
        public System.Windows.Forms.CheckBox useTrayIcon_checkbox;
    }
}

