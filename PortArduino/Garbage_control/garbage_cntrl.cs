using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO.Ports;

namespace PortArduino.Garbage_control
{
    public partial class garbage_cntrl : Form
    {
        public garbage_cntrl()
        {
            InitializeComponent();
            if (Properties.Settings.Default.CheckPort == true)
            {
                serialPort1.PortName = Properties.Settings.Default.Port;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                serialPort1.DataReceived += Port_DataRecieved;
            }
            Update_Status();
        }

        private void garbage_cntrl_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("1");
        }
        public void Port_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            string metal = serialPort1.ReadLine();
            if (metal[0] == '5')
                full_database();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.WriteLine("2");
        }
        

        private void full_database()
        {

            try
            {
                OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.DatabaseAdress);
                connection.Open();
                OleDbCommand cmd = new OleDbCommand("UPDATE Status SET Status.[Заполненность 1 мусора] = [Status]![Заполненность 1 мусора]+10 WHERE Status.[UID бака] = 1", connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                MessageBox.Show("Отсек переполнен!");
            }
                
        }

        private void Update_Status()
        {
            OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.DatabaseAdress);
            connection.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT Status.[Заполненность 1 мусора] FROM Status", connection);
            OleDbDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int count_of_garbage = Convert.ToInt32(reader[0].ToString());
            reader.Close();
            connection.Close();
            progressBar5.Value = count_of_garbage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update_Status();
        }
    }
}
