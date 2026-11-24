using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sensor_de_temperatura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Arduino.IsOpen)
            {
                Arduino.BaudRate = 9600;
                Arduino.PortName = "COM6";
                Arduino.Open();
                lbl_output.Text = Arduino.ReadLine();
            }
            else
            {
                lbl_output.Text = "Porta não está aberta";
                Arduino.Close();
            }

            

        }
      
       

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Tudo o que estiver aqui dentro repete-se a cada 2 segundos
            lbl_output.Text = Arduino.ReadLine();
        }
    }
}
