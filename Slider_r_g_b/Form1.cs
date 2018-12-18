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
    public partial class MainForm : Form
    {
        SettingsForm settingsWindow = new SettingsForm();

        // fore color for circular bars text when disconnected
        Color circular_bars_default_forecolor = Color.FromArgb(194, 200, 209);

        // Colors for temperature circular progress bars
        Color color_minusInfinity_0 = Color.FromArgb(242, 252, 255);
        Color color_0_5_c = Color.FromArgb(113, 203, 221);
        Color color_5_10_c = Color.FromArgb(90, 114, 206);
        Color color_10_15_c = Color.FromArgb(224, 202, 78);
        Color color_15_20_c = Color.FromArgb(219, 144, 63);
        Color color_20_25_c = Color.FromArgb(219, 97, 63);
        Color color_25_30_c = Color.FromArgb(232, 70, 26);
        Color color_30_plusInfinity_c = Color.FromArgb(198,0,0);

        // Colors for humidity circular progress bars
        Color color_80_100_humidity = Color.FromArgb(242, 252, 255);
        Color color_60_80_humidity = Color.FromArgb(153, 212, 229);
        Color color_35_60_humidity = Color.FromArgb(107, 148, 198);
        Color color_15_35_humidity = Color.FromArgb(219, 184, 129);
        Color color_0_15_humidity = Color.FromArgb(214, 76, 49);

        // connection label color
        Color connection_label_connected_color = Color.FromArgb(169, 219, 98);
        Color connection_label_disconnected_color = Color.FromArgb(198, 129, 27);

        // connect to arduino variables
        bool isConnected = false;
        String[] ports;
        SerialPort port;
        string dataIn;
      
        // detect arduino variables
        bool portFound = false;
        string arduinoPortName; // will contain port name that responded to handshake

        // borderless window draggable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // for hotkeys
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(String sClassName, String sAppName);
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        private IntPtr thisWindow;

        public MainForm()
        {
            InitializeComponent();
            Init_form(); // set form defaults

            var maintainConnection = new Thread(DetectPort);
            maintainConnection.IsBackground = true; // set thread background to auto close on app exit
            maintainConnection.Start();
        }

        private void DetectPort()
        {
            while(true)
            {
                Thread.Sleep(10);
                
                if (portFound)
                {
                    if (port.IsOpen && isConnected)
                    {
                        continue;
                    }
                    else // port found but closed...
                    {
                        this.Invoke(new EventHandler(DisconnectFromArduino));
                    }
                }

                // if arduino not connected, try to connect
                Get_Available_COM_Ports();
                foreach (string p in ports)
                {
                    SerialPort temp_port = new SerialPort(p, 9600, Parity.None, 8, StopBits.One);
                    temp_port.Open();
                    temp_port.Write("h\n");
                    System.Threading.Thread.Sleep(1000);

                    int count = temp_port.BytesToRead;
                    string returnMessage = "";
                    while (count > 0)
                    {
                        int returnAscii = temp_port.ReadByte();
                        returnMessage = returnMessage + Convert.ToChar(returnAscii);
                        count--;
                    }
                    temp_port.Close();
                    if (returnMessage == "ARDUINO")
                    {
                        arduinoPortName = p;
                        portFound = true;
                        this.Invoke(new EventHandler(ConnectToArduino));
                    }
                }
            }
        }

        private void DisconnectFromArduino(object sender, EventArgs e)
        {
            portFound = false;
            isConnected = false;
            Init_form();
        }

        private void ConnectToArduino(object sender, EventArgs e)
        {
            if (!isConnected && portFound)
            {
                port = new SerialPort(arduinoPortName, 9600, Parity.None, 8, StopBits.One);
                port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                port.Open();
                EnableControls();
                connection_status_label.Text = "connected to port " + arduinoPortName;
                connection_status_label.ForeColor = connection_label_connected_color;
                connection_status_label.Location = new Point(540, 764);
            }
            isConnected = true;
        }

        private void Init_form()
        {
            DisableControls();

            heater_status_icon.Hide();

            temperature_target_trackbar.Value = Properties.Settings.Default.TemperatureStartTarget;
            temperature_target_value_label.Text = (Properties.Settings.Default.TemperatureStartTarget).ToString();

            connection_status_label.Text = "please plug in your arduino in any USB";
            connection_status_label.ForeColor = connection_label_disconnected_color;
            connection_status_label.Location = new Point(400, 764);

            temperature_celsius_circularProgressBar.Text = "0";
            temperature_celsius_circularProgressBar.SubscriptText = ".00";
            temperature_celsius_circularProgressBar.ForeColor = circular_bars_default_forecolor;
            temperature_celsius_circularProgressBar.ProgressColor = circular_bars_default_forecolor;
            temperature_celsius_circularProgressBar.Value = 0;

            temperature_fahrenheit_circularProgressBar.Text = "0";
            temperature_fahrenheit_circularProgressBar.SubscriptText = ".00";
            temperature_fahrenheit_circularProgressBar.ForeColor = circular_bars_default_forecolor;
            temperature_fahrenheit_circularProgressBar.ProgressColor = circular_bars_default_forecolor;
            temperature_fahrenheit_circularProgressBar.Value = 0;

            temperature_kelvin_circularProgressBar.Text = "0";
            temperature_kelvin_circularProgressBar.SubscriptText = ".00";
            temperature_kelvin_circularProgressBar.ForeColor = circular_bars_default_forecolor;
            temperature_kelvin_circularProgressBar.ProgressColor = circular_bars_default_forecolor;
            temperature_kelvin_circularProgressBar.Value = 0;

            humidity_circularProgressBar.Text = "0";
            humidity_circularProgressBar.SubscriptText = ".00";
            humidity_circularProgressBar.ForeColor = circular_bars_default_forecolor;
            humidity_circularProgressBar.ProgressColor = circular_bars_default_forecolor;
            humidity_circularProgressBar.Value = 0;

            // form settings
            this.Opacity = ((double)Properties.Settings.Default.MainFormOpacity / 100);
            //Application.OpenForms[0].StartPosition = FormStartPosition.Manual; // TODO
        }

        // When data is received from arduino...
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            dataIn = sp.ReadExisting();
            this.Invoke(new EventHandler(ProcessData)); // call to process data
        }
        // process data received from arduino
        private void ProcessData(object sender, EventArgs e)
        {
            float temperature_celsius;
            float temperature_fahrenheit;
            float temperature_kelvin;
            float humidity;

            // parse string with regular expressions
            Regex pattern = new Regex(@"\d+.\d+");
            MatchCollection matches = pattern.Matches(dataIn);
            List<float> readings = new List<float>();
            foreach (Match m in matches)
            {
                readings.Add((float)Convert.ToDouble(m.Value));
            }
            temperature_celsius = readings[0];
            humidity = readings[1];
            // prepare to parse new data
            readings.Clear();

            // calculate fahrenheit and kelvin
            temperature_fahrenheit = CelsiusToFahrenheit(temperature_celsius);
            temperature_kelvin = CelsiusToKelvin(temperature_celsius);

            // set circular bars values, text and subscripts
            // NOTE update subscript if using a higher precission sensor like DHT22, to take advantage of the precission
            temperature_celsius_circularProgressBar.Value = (int)temperature_celsius;
            temperature_celsius_circularProgressBar.Text = ((int)temperature_celsius).ToString();
            temperature_celsius_circularProgressBar.SubscriptText = (temperature_celsius - (int)temperature_celsius).ToString(".##");
            temperature_fahrenheit_circularProgressBar.Value = (int)temperature_celsius;
            temperature_fahrenheit_circularProgressBar.Text = ((int)temperature_fahrenheit).ToString();
            temperature_fahrenheit_circularProgressBar.SubscriptText = (temperature_fahrenheit - (int)temperature_fahrenheit).ToString(".##");
            temperature_kelvin_circularProgressBar.Value = (int)temperature_celsius;
            temperature_kelvin_circularProgressBar.Text = ((int)temperature_kelvin).ToString();
            temperature_kelvin_circularProgressBar.SubscriptText = (temperature_kelvin - (int)temperature_kelvin).ToString(".##");
            // color circular bars according to temperature
            if (temperature_celsius <= 0)
            {
                temperature_celsius_circularProgressBar.ForeColor = color_minusInfinity_0;
                temperature_celsius_circularProgressBar.ProgressColor = color_minusInfinity_0;
                temperature_fahrenheit_circularProgressBar.ForeColor = color_minusInfinity_0;
                temperature_fahrenheit_circularProgressBar.ProgressColor = color_minusInfinity_0;
                temperature_kelvin_circularProgressBar.ForeColor = color_minusInfinity_0;
                temperature_kelvin_circularProgressBar.ProgressColor = color_minusInfinity_0;
            }
            else if (temperature_celsius <= 5)
            {
                temperature_celsius_circularProgressBar.ForeColor = color_0_5_c;
                temperature_celsius_circularProgressBar.ProgressColor = color_0_5_c;
                temperature_fahrenheit_circularProgressBar.ForeColor = color_0_5_c;
                temperature_fahrenheit_circularProgressBar.ProgressColor = color_0_5_c;
                temperature_kelvin_circularProgressBar.ForeColor = color_0_5_c;
                temperature_kelvin_circularProgressBar.ProgressColor = color_0_5_c;
            }
            else if (temperature_celsius <= 10)
            {
                temperature_celsius_circularProgressBar.ForeColor = color_5_10_c;
                temperature_celsius_circularProgressBar.ProgressColor = color_5_10_c;
                temperature_fahrenheit_circularProgressBar.ForeColor = color_5_10_c;
                temperature_fahrenheit_circularProgressBar.ProgressColor = color_5_10_c;
                temperature_kelvin_circularProgressBar.ForeColor = color_5_10_c;
                temperature_kelvin_circularProgressBar.ProgressColor = color_5_10_c;
            }
            else if (temperature_celsius <= 15)
            {
                temperature_celsius_circularProgressBar.ForeColor = color_10_15_c;
                temperature_celsius_circularProgressBar.ProgressColor = color_10_15_c;
                temperature_fahrenheit_circularProgressBar.ForeColor = color_10_15_c;
                temperature_fahrenheit_circularProgressBar.ProgressColor = color_10_15_c;
                temperature_kelvin_circularProgressBar.ForeColor = color_10_15_c;
                temperature_kelvin_circularProgressBar.ProgressColor = color_10_15_c;
            }
            else if (temperature_celsius <= 20)
            {
                temperature_celsius_circularProgressBar.ForeColor = color_15_20_c;
                temperature_celsius_circularProgressBar.ProgressColor = color_15_20_c;
                temperature_fahrenheit_circularProgressBar.ForeColor = color_15_20_c;
                temperature_fahrenheit_circularProgressBar.ProgressColor = color_15_20_c;
                temperature_kelvin_circularProgressBar.ForeColor = color_15_20_c;
                temperature_kelvin_circularProgressBar.ProgressColor = color_15_20_c;
            }
            else if (temperature_celsius <= 25)
            {
                temperature_celsius_circularProgressBar.ForeColor = color_20_25_c;
                temperature_celsius_circularProgressBar.ProgressColor = color_20_25_c;
                temperature_fahrenheit_circularProgressBar.ForeColor = color_20_25_c;
                temperature_fahrenheit_circularProgressBar.ProgressColor = color_20_25_c;
                temperature_kelvin_circularProgressBar.ForeColor = color_20_25_c;
                temperature_kelvin_circularProgressBar.ProgressColor = color_20_25_c;
            }
            else if (temperature_celsius <= 30)
            {
                temperature_celsius_circularProgressBar.ForeColor = color_25_30_c;
                temperature_celsius_circularProgressBar.ProgressColor = color_25_30_c;
                temperature_fahrenheit_circularProgressBar.ForeColor = color_25_30_c;
                temperature_fahrenheit_circularProgressBar.ProgressColor = color_25_30_c;
                temperature_kelvin_circularProgressBar.ForeColor = color_25_30_c;
                temperature_kelvin_circularProgressBar.ProgressColor = color_25_30_c;
            }
            else if (temperature_celsius > 30)
            {
                temperature_celsius_circularProgressBar.ForeColor = color_30_plusInfinity_c;
                temperature_celsius_circularProgressBar.ProgressColor = color_30_plusInfinity_c;
                temperature_fahrenheit_circularProgressBar.ForeColor = color_30_plusInfinity_c;
                temperature_fahrenheit_circularProgressBar.ProgressColor = color_30_plusInfinity_c;
                temperature_kelvin_circularProgressBar.ForeColor = color_30_plusInfinity_c;
                temperature_kelvin_circularProgressBar.ProgressColor = color_30_plusInfinity_c;
            }

            // set humidity circular trackbar value and text and subscript
            humidity_circularProgressBar.Value = (int)humidity;
            humidity_circularProgressBar.Text = ((int)humidity).ToString();
            humidity_circularProgressBar.SubscriptText = (humidity - (int)humidity).ToString(".##");
            // TODO set humidity circular trackbar color based on humidity
            if (humidity <= 15)
            {
                humidity_circularProgressBar.ForeColor = color_0_15_humidity;
                humidity_circularProgressBar.ProgressColor = color_0_15_humidity;
            }
            else if (humidity <= 35)
            {
                humidity_circularProgressBar.ForeColor = color_15_35_humidity;
                humidity_circularProgressBar.ProgressColor = color_15_35_humidity;
            }
            else if (humidity <= 60)
            {
                humidity_circularProgressBar.ForeColor = color_35_60_humidity;
                humidity_circularProgressBar.ProgressColor = color_35_60_humidity;
            }
            else if (humidity <= 80)
            {
                humidity_circularProgressBar.ForeColor = color_60_80_humidity;
                humidity_circularProgressBar.ProgressColor = color_60_80_humidity;
            }
            else if (humidity <= 100)
            {
                humidity_circularProgressBar.ForeColor = color_80_100_humidity;
                humidity_circularProgressBar.ProgressColor = color_80_100_humidity;
            }

            // thermostat
            int target_temp = temperature_target_trackbar.Value;
            int min_temp = target_temp - 1;
            int max_temp = target_temp + 1;
            if (temperature_celsius <= min_temp)
            {
                Heat(true);
            }
            else if (temperature_celsius >= max_temp)
            {
                Heat(false);
            }
        }

        private void DisableControls()
        {
            temperature_target_trackbar.Enabled = false;
        }
        private void EnableControls()
        {
            temperature_target_trackbar.Enabled = true;
        }

        private float CelsiusToFahrenheit(float c)
        {
            float f = c * 9 / 5 + 32;
            return f;
        }

        private float CelsiusToKelvin(float c)
        {
            float k = c + 273.15f;
            return k;
        }

        // exit button
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            if (portFound && port.IsOpen)
            {
                Heat(false);
                Thread.Sleep(100);
            }
            Properties.Settings.Default.mainFormLocation = this.Location; // save current position
            Application.Exit();
        }

        // minimize button
        private void Minimize_Button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Heat(bool state)
        {
            if (!portFound || !port.IsOpen || !isConnected)
            {
                MessageBox.Show("An error has occured, arduino is disconnected");
                Application.Exit();
            }
            if (state)
            {
                port.Write("digitalJ1\n");
                heater_status_icon.Show();
            }
            else
            {
                port.Write("digitalJ0\n");
                heater_status_icon.Hide();
            }
        }

        private void Temperature_target_trackbar_scroll(object sender, EventArgs e)
        {
            string temp = temperature_target_trackbar.Value.ToString();
            temperature_target_value_label.Text = temp;
            if (isConnected)
            {
                port.Write("analogB" + temp + "\n");
            }
        }

        // HOTKEYS
        public enum FsModifiers
        {
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Window = 0x0008,
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            thisWindow = FindWindow(null, "Form1");

            //RegisterHotKey(thisWindow, 1, (uint)fsModifiers.Alt, (uint)Keys.G);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //UnregisterHotKey(thisWindow, 1);
        }

        protected override void WndProc(ref Message m)
        {
            if(m.Msg == 786) // https://wiki.winehq.org/List_Of_Windows_Messages
            {
                Console.WriteLine("hotkey fire");
                MessageBox.Show("hotkey fire");
            }

            base.WndProc(ref m);
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

        private void Get_Available_COM_Ports()
        {
            ports = SerialPort.GetPortNames();
        }

        private void Settings_Button_Click(object sender, EventArgs e)
        {
            settingsWindow.Show();
        }
    }
}
