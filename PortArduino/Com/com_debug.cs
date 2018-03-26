using System;
using System.IO.Ports;
using System.Windows.Forms;


namespace PortArduino
{
    public partial class com_debug : Form
    {
        public DateTime datetime;
        DB DATABASE = new DB();

        public com_debug()
        {
            InitializeComponent();
            
            if (DATABASE.chprt == true)
            {
                serialPort1.PortName = DATABASE.Port;
                serialPort1.BaudRate = 9600;
                serialPort1.Open();
                serialPort1.DataReceived += Port_DataRecieved;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label2.Text = DATABASE.Port;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.Write(textBox1.Text);
        }
        
        private string writeread;

        public void Port_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            writeread = serialPort1.ReadLine();
            this.Invoke(new EventHandler(displaydata_event));
        }

        private string time;

        private void displaydata_event(object sender, EventArgs e)
        {
            datetime = DateTime.Now;
            time = datetime.Hour + ":" + datetime.Minute + ":" + datetime.Second;
            dataGridView1.Rows.Add(dataGridView1[0, dataGridView1.Rows.Count-1].Value = time + " " + writeread);
            
        }
    }
}