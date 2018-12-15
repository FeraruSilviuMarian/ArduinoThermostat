﻿namespace ArduinoThermostat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Connect_button = new System.Windows.Forms.Button();
            this.COM_combobox = new System.Windows.Forms.ComboBox();
            this.exit_button = new System.Windows.Forms.Button();
            this.minimize_button = new System.Windows.Forms.Button();
            this.pin11checkbox = new System.Windows.Forms.CheckBox();
            this.temperature_target_label = new System.Windows.Forms.Label();
            this.temperature_target_value_label = new System.Windows.Forms.Label();
            this.temperature_target_trackbar = new System.Windows.Forms.TrackBar();
            this.connection_status_label = new System.Windows.Forms.Label();
            this.temp_target_celsius_label = new System.Windows.Forms.Label();
            this.temperature_celsius_circularProgressBar = new CircularProgressBar.CircularProgressBar();
            this.temperature_kelvin_circularProgressBar = new CircularProgressBar.CircularProgressBar();
            this.temperature_fahrenheit_circularProgressBar = new CircularProgressBar.CircularProgressBar();
            this.humidity_circularProgressBar = new CircularProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.temperature_target_trackbar)).BeginInit();
            this.SuspendLayout();
            // 
            // Connect_button
            // 
            this.Connect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect_button.Location = new System.Drawing.Point(609, 738);
            this.Connect_button.Name = "Connect_button";
            this.Connect_button.Size = new System.Drawing.Size(167, 51);
            this.Connect_button.TabIndex = 2;
            this.Connect_button.Text = "Connect";
            this.Connect_button.UseVisualStyleBackColor = true;
            this.Connect_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // COM_combobox
            // 
            this.COM_combobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COM_combobox.FormattingEnabled = true;
            this.COM_combobox.Location = new System.Drawing.Point(460, 748);
            this.COM_combobox.Name = "COM_combobox";
            this.COM_combobox.Size = new System.Drawing.Size(143, 32);
            this.COM_combobox.TabIndex = 3;
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
            this.exit_button.Click += new System.EventHandler(this.button4_Click);
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
            this.minimize_button.Click += new System.EventHandler(this.button2_Click);
            // 
            // pin11checkbox
            // 
            this.pin11checkbox.AutoSize = true;
            this.pin11checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pin11checkbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.pin11checkbox.Location = new System.Drawing.Point(180, 743);
            this.pin11checkbox.Name = "pin11checkbox";
            this.pin11checkbox.Size = new System.Drawing.Size(150, 46);
            this.pin11checkbox.TabIndex = 17;
            this.pin11checkbox.Text = "PIN 11";
            this.pin11checkbox.UseVisualStyleBackColor = true;
            this.pin11checkbox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // temperature_target_label
            // 
            this.temperature_target_label.AutoSize = true;
            this.temperature_target_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperature_target_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.temperature_target_label.Location = new System.Drawing.Point(25, 659);
            this.temperature_target_label.Name = "temperature_target_label";
            this.temperature_target_label.Size = new System.Drawing.Size(195, 25);
            this.temperature_target_label.TabIndex = 35;
            this.temperature_target_label.Text = "Temperature target";
            this.temperature_target_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // temperature_target_value_label
            // 
            this.temperature_target_value_label.AutoSize = true;
            this.temperature_target_value_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperature_target_value_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.temperature_target_value_label.Location = new System.Drawing.Point(318, 659);
            this.temperature_target_value_label.Name = "temperature_target_value_label";
            this.temperature_target_value_label.Size = new System.Drawing.Size(36, 25);
            this.temperature_target_value_label.TabIndex = 34;
            this.temperature_target_value_label.Text = "20";
            this.temperature_target_value_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // temperature_target_trackbar
            // 
            this.temperature_target_trackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.temperature_target_trackbar.Cursor = System.Windows.Forms.Cursors.Default;
            this.temperature_target_trackbar.Location = new System.Drawing.Point(12, 687);
            this.temperature_target_trackbar.Maximum = 50;
            this.temperature_target_trackbar.Name = "temperature_target_trackbar";
            this.temperature_target_trackbar.Size = new System.Drawing.Size(765, 45);
            this.temperature_target_trackbar.TabIndex = 33;
            this.temperature_target_trackbar.Value = 20;
            this.temperature_target_trackbar.Scroll += new System.EventHandler(this.pin3trackbar_Scroll);
            // 
            // connection_status_label
            // 
            this.connection_status_label.AutoSize = true;
            this.connection_status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connection_status_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(219)))), ((int)(((byte)(98)))));
            this.connection_status_label.Location = new System.Drawing.Point(531, 764);
            this.connection_status_label.Name = "connection_status_label";
            this.connection_status_label.Size = new System.Drawing.Size(246, 25);
            this.connection_status_label.TabIndex = 48;
            this.connection_status_label.Text = "connected to port COM3";
            this.connection_status_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connection_status_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // temp_target_celsius_label
            // 
            this.temp_target_celsius_label.AutoSize = true;
            this.temp_target_celsius_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temp_target_celsius_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.temp_target_celsius_label.Location = new System.Drawing.Point(348, 659);
            this.temp_target_celsius_label.Name = "temp_target_celsius_label";
            this.temp_target_celsius_label.Size = new System.Drawing.Size(35, 25);
            this.temp_target_celsius_label.TabIndex = 49;
            this.temp_target_celsius_label.Text = "°C";
            this.temp_target_celsius_label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // temperature_celsius_circularProgressBar
            // 
            this.temperature_celsius_circularProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.temperature_celsius_circularProgressBar.AnimationSpeed = 500;
            this.temperature_celsius_circularProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.temperature_celsius_circularProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperature_celsius_circularProgressBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.temperature_celsius_circularProgressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.temperature_celsius_circularProgressBar.InnerMargin = 2;
            this.temperature_celsius_circularProgressBar.InnerWidth = -1;
            this.temperature_celsius_circularProgressBar.Location = new System.Drawing.Point(65, 56);
            this.temperature_celsius_circularProgressBar.MarqueeAnimationSpeed = 2000;
            this.temperature_celsius_circularProgressBar.Maximum = 50;
            this.temperature_celsius_circularProgressBar.Name = "temperature_celsius_circularProgressBar";
            this.temperature_celsius_circularProgressBar.OuterColor = System.Drawing.Color.Gray;
            this.temperature_celsius_circularProgressBar.OuterMargin = -25;
            this.temperature_celsius_circularProgressBar.OuterWidth = 26;
            this.temperature_celsius_circularProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.temperature_celsius_circularProgressBar.ProgressWidth = 25;
            this.temperature_celsius_circularProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.temperature_celsius_circularProgressBar.Size = new System.Drawing.Size(320, 320);
            this.temperature_celsius_circularProgressBar.StartAngle = 270;
            this.temperature_celsius_circularProgressBar.Step = 1;
            this.temperature_celsius_circularProgressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.temperature_celsius_circularProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.temperature_celsius_circularProgressBar.SubscriptText = " ";
            this.temperature_celsius_circularProgressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.temperature_celsius_circularProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.temperature_celsius_circularProgressBar.SuperscriptText = "°C";
            this.temperature_celsius_circularProgressBar.TabIndex = 50;
            this.temperature_celsius_circularProgressBar.Text = "0";
            this.temperature_celsius_circularProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.temperature_celsius_circularProgressBar.Value = 50;
            this.temperature_celsius_circularProgressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // temperature_kelvin_circularProgressBar
            // 
            this.temperature_kelvin_circularProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.temperature_kelvin_circularProgressBar.AnimationSpeed = 500;
            this.temperature_kelvin_circularProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.temperature_kelvin_circularProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperature_kelvin_circularProgressBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.temperature_kelvin_circularProgressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.temperature_kelvin_circularProgressBar.InnerMargin = 2;
            this.temperature_kelvin_circularProgressBar.InnerWidth = -1;
            this.temperature_kelvin_circularProgressBar.Location = new System.Drawing.Point(125, 382);
            this.temperature_kelvin_circularProgressBar.MarqueeAnimationSpeed = 2000;
            this.temperature_kelvin_circularProgressBar.Maximum = 50;
            this.temperature_kelvin_circularProgressBar.Name = "temperature_kelvin_circularProgressBar";
            this.temperature_kelvin_circularProgressBar.OuterColor = System.Drawing.Color.Gray;
            this.temperature_kelvin_circularProgressBar.OuterMargin = -25;
            this.temperature_kelvin_circularProgressBar.OuterWidth = 26;
            this.temperature_kelvin_circularProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.temperature_kelvin_circularProgressBar.ProgressWidth = 25;
            this.temperature_kelvin_circularProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperature_kelvin_circularProgressBar.Size = new System.Drawing.Size(260, 260);
            this.temperature_kelvin_circularProgressBar.StartAngle = 270;
            this.temperature_kelvin_circularProgressBar.Step = 1;
            this.temperature_kelvin_circularProgressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.temperature_kelvin_circularProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.temperature_kelvin_circularProgressBar.SubscriptText = ".00";
            this.temperature_kelvin_circularProgressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.temperature_kelvin_circularProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.temperature_kelvin_circularProgressBar.SuperscriptText = "°K";
            this.temperature_kelvin_circularProgressBar.TabIndex = 51;
            this.temperature_kelvin_circularProgressBar.Text = "0";
            this.temperature_kelvin_circularProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.temperature_kelvin_circularProgressBar.Value = 50;
            this.temperature_kelvin_circularProgressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // temperature_fahrenheit_circularProgressBar
            // 
            this.temperature_fahrenheit_circularProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.temperature_fahrenheit_circularProgressBar.AnimationSpeed = 500;
            this.temperature_fahrenheit_circularProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.temperature_fahrenheit_circularProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperature_fahrenheit_circularProgressBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.temperature_fahrenheit_circularProgressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.temperature_fahrenheit_circularProgressBar.InnerMargin = 2;
            this.temperature_fahrenheit_circularProgressBar.InnerWidth = -1;
            this.temperature_fahrenheit_circularProgressBar.Location = new System.Drawing.Point(391, 382);
            this.temperature_fahrenheit_circularProgressBar.MarqueeAnimationSpeed = 2000;
            this.temperature_fahrenheit_circularProgressBar.Maximum = 50;
            this.temperature_fahrenheit_circularProgressBar.Name = "temperature_fahrenheit_circularProgressBar";
            this.temperature_fahrenheit_circularProgressBar.OuterColor = System.Drawing.Color.Gray;
            this.temperature_fahrenheit_circularProgressBar.OuterMargin = -25;
            this.temperature_fahrenheit_circularProgressBar.OuterWidth = 26;
            this.temperature_fahrenheit_circularProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.temperature_fahrenheit_circularProgressBar.ProgressWidth = 25;
            this.temperature_fahrenheit_circularProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperature_fahrenheit_circularProgressBar.Size = new System.Drawing.Size(260, 260);
            this.temperature_fahrenheit_circularProgressBar.StartAngle = 270;
            this.temperature_fahrenheit_circularProgressBar.Step = 1;
            this.temperature_fahrenheit_circularProgressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.temperature_fahrenheit_circularProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.temperature_fahrenheit_circularProgressBar.SubscriptText = " .00";
            this.temperature_fahrenheit_circularProgressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.temperature_fahrenheit_circularProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.temperature_fahrenheit_circularProgressBar.SuperscriptText = "°F";
            this.temperature_fahrenheit_circularProgressBar.TabIndex = 52;
            this.temperature_fahrenheit_circularProgressBar.Text = "0";
            this.temperature_fahrenheit_circularProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.temperature_fahrenheit_circularProgressBar.Value = 50;
            this.temperature_fahrenheit_circularProgressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // humidity_circularProgressBar
            // 
            this.humidity_circularProgressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.humidity_circularProgressBar.AnimationSpeed = 500;
            this.humidity_circularProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.humidity_circularProgressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humidity_circularProgressBar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.humidity_circularProgressBar.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.humidity_circularProgressBar.InnerMargin = 2;
            this.humidity_circularProgressBar.InnerWidth = -1;
            this.humidity_circularProgressBar.Location = new System.Drawing.Point(391, 56);
            this.humidity_circularProgressBar.MarqueeAnimationSpeed = 2000;
            this.humidity_circularProgressBar.Name = "humidity_circularProgressBar";
            this.humidity_circularProgressBar.OuterColor = System.Drawing.Color.Gray;
            this.humidity_circularProgressBar.OuterMargin = -25;
            this.humidity_circularProgressBar.OuterWidth = 26;
            this.humidity_circularProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.humidity_circularProgressBar.ProgressWidth = 25;
            this.humidity_circularProgressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.humidity_circularProgressBar.Size = new System.Drawing.Size(320, 320);
            this.humidity_circularProgressBar.StartAngle = 270;
            this.humidity_circularProgressBar.Step = 1;
            this.humidity_circularProgressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.humidity_circularProgressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.humidity_circularProgressBar.SubscriptText = " ";
            this.humidity_circularProgressBar.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.humidity_circularProgressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.humidity_circularProgressBar.SuperscriptText = "%";
            this.humidity_circularProgressBar.TabIndex = 53;
            this.humidity_circularProgressBar.Text = "0";
            this.humidity_circularProgressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.humidity_circularProgressBar.Value = 68;
            this.humidity_circularProgressBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(789, 798);
            this.Controls.Add(this.connection_status_label);
            this.Controls.Add(this.humidity_circularProgressBar);
            this.Controls.Add(this.temperature_fahrenheit_circularProgressBar);
            this.Controls.Add(this.temperature_kelvin_circularProgressBar);
            this.Controls.Add(this.temperature_celsius_circularProgressBar);
            this.Controls.Add(this.temp_target_celsius_label);
            this.Controls.Add(this.temperature_target_label);
            this.Controls.Add(this.temperature_target_value_label);
            this.Controls.Add(this.temperature_target_trackbar);
            this.Controls.Add(this.pin11checkbox);
            this.Controls.Add(this.minimize_button);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.COM_combobox);
            this.Controls.Add(this.Connect_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Arduino Thermostat";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_Form);
            ((System.ComponentModel.ISupportInitialize)(this.temperature_target_trackbar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Connect_button;
        private System.Windows.Forms.ComboBox COM_combobox;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button minimize_button;
        private System.Windows.Forms.CheckBox pin11checkbox;
        private System.Windows.Forms.Label temperature_target_label;
        private System.Windows.Forms.Label temperature_target_value_label;
        private System.Windows.Forms.TrackBar temperature_target_trackbar;
        private System.Windows.Forms.Label connection_status_label;
        private System.Windows.Forms.Label temp_target_celsius_label;
        private CircularProgressBar.CircularProgressBar temperature_celsius_circularProgressBar;
        private CircularProgressBar.CircularProgressBar temperature_kelvin_circularProgressBar;
        private CircularProgressBar.CircularProgressBar temperature_fahrenheit_circularProgressBar;
        private CircularProgressBar.CircularProgressBar humidity_circularProgressBar;
    }
}
