using System;
using System.Data;
using System.Data.OleDb;
using System.IO.Ports;
using System.Windows.Forms;

namespace PortArduino.Garbage_control
{
    public partial class garbage_cntrl : Form
    {
        OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.DatabaseAdress);
        public garbage_cntrl()
        {
            InitializeComponent();
            try
            {
                if (Properties.Settings.Default.CheckPort == true)
                {
                    serialPort1.PortName = Properties.Settings.Default.Port;
                    serialPort1.BaudRate = 9600;
                    serialPort1.Open();
                    serialPort1.DataReceived += Port_DataRecieved;
                }
            }
            catch
            {
                MessageBox.Show("Порт " + serialPort1.PortName.ToString() + " недоступен");
            }
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

        private void Port_DataRecieved(object sender, SerialDataReceivedEventArgs e)
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
                connection.Open();
                OleDbCommand cmd = new OleDbCommand("UPDATE Status SET Status.[Заполненность 1 мусора] = [Status]![Заполненность 1 мусора]+10", connection);
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
            if (connection.State == ConnectionState.Open)
            {
                MessageBox.Show("Соединение занято!");
            }
            else
            {
                connection.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Status.[Заполненность 1 мусора] FROM Status WHERE Status.[UID бака] = 1", connection);
                OleDbDataReader reader = cmd.ExecuteReader();
                reader.Read();
                int count_of_garbage = Convert.ToInt32(reader[0].ToString());
                reader.Close();
                string NameOfPage = "Collect";
                string sql = "SELECT Status.[UID бака], Status.[Заполненность 1 мусора], Adresses.[Номер квартиры], Adresses.[UID ключ] FROM Status INNER JOIN Adresses ON Status.[UID бака] = Adresses.[UID бака] WHERE Status.[UID бака] = 1";
                DataSet dataSetNew = new DataSet();
                OleDbDataAdapter oleDbDataAdapterNew = new OleDbDataAdapter(sql, connection);
                oleDbDataAdapterNew.Fill(dataSetNew, NameOfPage);
                dataGridView1.DataSource = dataSetNew;
                dataGridView1.DataMember = NameOfPage;
                connection.Close();
                progressBar5.Value = count_of_garbage;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update_Status();
        }
    }
}
