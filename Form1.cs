using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; // Librería de comunicación SERIAL

namespace _3NLIDTS_GabrielaCasanova_07csharp
{
    public partial class Form1 : Form
    {
        public SerialPort ArduinoPort { get; }
        public Form1()
        {
            InitializeComponent();

            // Configuración de comunicación SERIAL
            ArduinoPort = new SerialPort();
            ArduinoPort.PortName = "COM7"; // Verificar con la configuración de tu equipo
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();

            // Manejadores de eventos
            this.FormClosing += CerrandoForm1;
            this.btnEncender.Click += btnEncender_Click;
            this.btnApagar.Click += btnApagar_Click;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CerrandoForm1(object sender, FormClosingEventArgs e)
        {
            if (ArduinoPort.IsOpen)
            {
                ArduinoPort.Close();
            }
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("b");
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("a");
        }
    }
}
