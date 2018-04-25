using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Configuration;

namespace PortArduino
{
    public partial class DatabaseMenu : Form
    {
        public DatabaseMenu()
        {
            InitializeComponent();
            
        }

        private void DatabaseMenu_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(Properties.Settings.Default.DatabaseAdress);
            connection.Open();
            string NameOfPage = "Adreses";
            TabPage tabPageNew = new TabPage(NameOfPage);
            DataGridView dataGridViewNew = new DataGridView();
            tabControl1.Controls.Add(tabPageNew);
            string sql = "SELECT Adreses.* FROM [Adreses]";
            DataSet dataSetNew = new DataSet();
            OleDbDataAdapter oleDbDataAdapterNew = new OleDbDataAdapter(sql, connection);
            oleDbDataAdapterNew.Fill(dataSetNew, NameOfPage);
            dataGridViewNew.DataSource = dataSetNew;
            dataGridViewNew.DataMember = NameOfPage;
            tabControl1.TabPages[0].Controls.Add(dataGridViewNew);
            NameOfPage = "Status";
            tabPageNew = new TabPage(NameOfPage);
            tabControl1.Controls.Add(tabPageNew);
            sql = "SELECT Status.* FROM [Status]";
            dataSetNew = new DataSet();
            oleDbDataAdapterNew = new OleDbDataAdapter(sql, connection);
            oleDbDataAdapterNew.Fill(dataSetNew, NameOfPage);
            dataGridViewNew.DataSource = dataSetNew;
            dataGridViewNew.DataMember = NameOfPage;
            tabControl1.TabPages[1].Controls.Add(dataGridViewNew);
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DatabaseMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}