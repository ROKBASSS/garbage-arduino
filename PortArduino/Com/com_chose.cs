using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace PortArduino
{

    public partial class com_chose : Form
    {
        DB DATABASE = new DB();
        public com_chose()
        {
            InitializeComponent();
            DATABASE.OnPortChange += new EventHandler(DATABASE_OnPortChange);
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
                DATABASE.Port = Convert.ToString(dataGridView1.CurrentCell.Value);
                Properties.Settings.Default.Port = DATABASE.Port;
                Properties.Settings.Default.CheckPort = true;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не выбрали порт!\n"+ex);
                DATABASE.chprt = false;

            }
            if (DATABASE.chprt != false)
            {
                this.Close();
            }
        }

        void DATABASE_OnPortChange(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DATABASE.Port = Convert.ToString(dataGridView1.CurrentCell.Value);
            label2.Text = DATABASE.Port;
        }


    }
    
}
