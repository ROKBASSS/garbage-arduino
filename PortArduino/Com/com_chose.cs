using System;
using System.IO.Ports;
using System.Configuration;
using System.Windows.Forms;

namespace PortArduino
{

    public partial class com_chose : Form
    {
        public com_chose()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Порты";
                column1.CellTemplate = new DataGridViewTextBoxCell();
            column1.Name = "Ports";
            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Доступность";
            column2.Name = "Avialable";
            column2.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.AllowUserToAddRows = false;
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                
                dataGridView1.Rows.Add();
                dataGridView1["Ports",dataGridView1.Rows.Count -1].Value = port;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                Properties.Settings.Default.Port = Convert.ToString(dataGridView1.CurrentCell.Value);
                Properties.Settings.Default.CheckPort = true;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не выбрали порт!\n"+ex);
                Properties.Settings.Default.CheckPort = false;

            }
            if (Properties.Settings.Default.CheckPort != false)
            {
                this.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Port = Convert.ToString(dataGridView1.CurrentCell.Value);
            label2.Text = Properties.Settings.Default.Port;
            MainWindow main = new MainWindow();
            main.UpdateCom();
        }


    }
    
}
