using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ArduinoThermostat
{
    public partial class SettingsForm : Form
    {
        // borderless window draggable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public SettingsForm()
        {
            InitializeComponent();
            Init_Form();
        }

        private void Init_Form()
        {
            start_temperature_setting_trackbar.Value = Properties.Settings.Default.TemperatureStartTarget;
            start_temperature_target_value_setting_label.Text = (Properties.Settings.Default.TemperatureStartTarget).ToString();

            opacitySetting_trackbar.Value = Properties.Settings.Default.MainFormOpacity;
            opacitySettingValue_label.Text = (Properties.Settings.Default.MainFormOpacity).ToString();

            this.StartPosition = FormStartPosition.Manual;
            this.Left = Properties.Settings.Default.settingsFormLocation.X;
            this.Top = Properties.Settings.Default.settingsFormLocation.Y;

            useTrayIcon_checkbox.Checked = Properties.Settings.Default.showInTray;
        }

        // exit button
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.settingsFormLocation = new Point(this.Left, this.Top);
            Properties.Settings.Default.Save();
            this.Hide();
        }

        // minimize button
        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Drag_Form(object sender, MouseEventArgs e)
        {
            // drag element by mouse
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Start_temperature_setting_trackbar_Scroll(object sender, EventArgs e)
        {
            start_temperature_target_value_setting_label.Text = (start_temperature_setting_trackbar.Value).ToString();
            Properties.Settings.Default.TemperatureStartTarget = start_temperature_setting_trackbar.Value;
            Properties.Settings.Default.Save();
        }

        private void OpacitySetting_trackbar_Scroll(object sender, EventArgs e)
        {
            Application.OpenForms[0].Opacity = ((double)opacitySetting_trackbar.Value / 100);
            opacitySettingValue_label.Text = (opacitySetting_trackbar.Value).ToString();
            Properties.Settings.Default.MainFormOpacity = opacitySetting_trackbar.Value;
            Properties.Settings.Default.Save();
        }

        public void UseTrayIcon_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.showInTray = useTrayIcon_checkbox.Checked;

            //mainFormRef.notifyIcon.Visible = useTrayIcon_checkbox.Checked; // TODO make action happen right away

            Properties.Settings.Default.Save();
        }
    }
}
