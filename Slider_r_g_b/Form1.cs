using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ArduinoThermostat
{
    public partial class Form1 : Form
    {
        // Colors
        Color color_minusInfinity_5_c = Color.FromArgb(113, 203, 221);
        Color color_5_10_c = Color.FromArgb(90, 114, 206);
        Color color_10_15_c = Color.FromArgb(224, 202, 78);
        Color color_15_20_c = Color.FromArgb(219, 144, 63);
        Color color_20_25_c = Color.FromArgb(219, 97, 63);
        Color color_25_30_c = Color.FromArgb(232, 70, 26);
        Color color_30_plusInfinity_c = Color.FromArgb(198,0,0);

        // connect to arduino variables
        bool isConnected = false;
        String[] ports;
        SerialPort port;
        string dataIn;
        string portName;

        // Make borderless window draggable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        // TODO hotkeys
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(String sClassName, String sAppName);
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private IntPtr thisWindow;

        public Form1()
        {
            InitializeComponent();
            init_form(); // form defaults before reading data
            getAvailableComPorts();
            foreach (string port in ports)
            {
                COM_combobox.Items.Add(port);
                Console.WriteLine(port);   
            }
            if (ports[1] != null)
            {
                COM_combobox.SelectedItem = ports[1];
            }
        }

        private void init_form()
        {
            disableControls();
            connection_status_label.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }

        private void connectToArduino()
        {
            if (!isConnected)
            {
                string selectedPort = COM_combobox.GetItemText(COM_combobox.SelectedItem);
                port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
                port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                port.Open();
                enableControls();
                Connect_button.Hide();
                COM_combobox.Hide();
                connection_status_label.Text = "connected to port " + COM_combobox.Text;
                connection_status_label.Show();
            }
            isConnected = true;
        }

        // When data is received from arduino...
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            dataIn = sp.ReadExisting();
            portName = sp.PortName.ToString();
            this.Invoke(new EventHandler(ProcessData));
        }
        // process data received from arduino
        private void ProcessData(object sender, EventArgs e)
        {
            connectToArduino();
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
            temperature_fahrenheit = celsiusToFahrenheit(temperature_celsius);
            temperature_kelvin = celsiusToKelvin(temperature_celsius);
            
            // set circular bars values, text and subscripts
            // NOTE update subscript if using a higher precission sensor like DHT22, to take advantage of the precission
            temperature_celsius_circularProgressBar.Value = (int)temperature_celsius;
            temperature_celsius_circularProgressBar.Text = ((int)temperature_celsius).ToString();
            temperature_fahrenheit_circularProgressBar.Value = (int)temperature_celsius;
            temperature_fahrenheit_circularProgressBar.Text = ((int)temperature_fahrenheit).ToString();
            temperature_fahrenheit_circularProgressBar.SubscriptText = (temperature_fahrenheit - (int)temperature_fahrenheit).ToString(".##");
            temperature_kelvin_circularProgressBar.Value = (int)temperature_celsius;
            temperature_kelvin_circularProgressBar.Text = ((int)temperature_kelvin).ToString();
            temperature_kelvin_circularProgressBar.SubscriptText = (temperature_kelvin - (int)temperature_kelvin).ToString(".##");

            // color circular bars according to temperature
            if (temperature_celsius <= 5)
            {
                temperature_celsius_circularProgressBar.ForeColor = color_minusInfinity_5_c;
                temperature_celsius_circularProgressBar.ProgressColor = color_minusInfinity_5_c;
                temperature_fahrenheit_circularProgressBar.ForeColor = color_minusInfinity_5_c;
                temperature_fahrenheit_circularProgressBar.ProgressColor = color_minusInfinity_5_c;
                temperature_kelvin_circularProgressBar.ForeColor = color_minusInfinity_5_c;
                temperature_kelvin_circularProgressBar.ProgressColor = color_minusInfinity_5_c;

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

            // thermostat
            if (temperature_celsius <= 20)
            {
                pin11checkbox.Checked = true;
            }
            else if (temperature_celsius >= 21)
            {
                pin11checkbox.Checked = false;
            }
        }

        // deprecated
        private void disconnectFromArduino()
        {
            isConnected = false;
            port.Close();
            Connect_button.Text = "Connect";
            disableControls();
            resetDefaults();
        }

        private void disableControls()
        {
            temperature_target_trackbar.Enabled = false;

            pin11checkbox.Enabled = false;

            temperature_celsius_circularProgressBar.Enabled = false;
        }

        private void enableControls()
        {
            temperature_target_trackbar.Enabled = true;

            pin11checkbox.Enabled = true;
        }

        // deprecated
        private void resetDefaults()
        {
            temperature_target_trackbar.Value = 0;

            pin11checkbox.Checked = false;
        }

        private float celsiusToFahrenheit(float c)
        {
            float f = c * 9 / 5 + 32;
            return f;
        }

        private float celsiusToKelvin(float c)
        {
            float k = c + 273.15f;
            return k;
        }

        private void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        // exit button
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // minimize button
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (pin11checkbox.Checked)
            {
                port.Write("digitalJ1\n");
            }
            else
            {
                port.Write("digitalJ0\n");
            }
        }

        private void pin3trackbar_Scroll(object sender, EventArgs e)
        {
            string temp = temperature_target_trackbar.Value.ToString();
            temperature_target_value_label.Text = temp;
            if (isConnected)
            {
                port.Write("analogB" + temp + "\n");
            }
        }

        // HOTKEYS
        public enum fsModifiers
        {
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004,
            Window = 0x0008,
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            thisWindow = FindWindow(null, "Form1");

            //RegisterHotKey(thisWindow, 1, (uint)fsModifiers.Alt, (uint)Keys.G);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //UnregisterHotKey(thisWindow, 1);
        }

        protected override void WndProc(ref Message keyPressed)
        {
            if(keyPressed.Msg == 786)
            {
                Console.WriteLine("some");
                MessageBox.Show("key pressed");
            }

            base.WndProc(ref keyPressed);
        }

        private void Drag_Form(object sender, MouseEventArgs e)
        {
            // drag form by mousedown on element
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
