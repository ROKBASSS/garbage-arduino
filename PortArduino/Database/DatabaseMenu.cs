using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

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
            DataGridView dataGridViewNew1 = new DataGridView();
            string NameOfPage = "Adresses";
            TabPage tabPageNew = new TabPage(NameOfPage);
            tabControl1.Controls.Add(tabPageNew);
            string sql = "SELECT Adresses.* FROM [Adresses]";
            DataSet dataSetNew = new DataSet();
            OleDbDataAdapter oleDbDataAdapterNew = new OleDbDataAdapter(sql, connection);
            oleDbDataAdapterNew.Fill(dataSetNew, NameOfPage);
            dataGridViewNew1.DataSource = dataSetNew;
            dataGridViewNew1.DataMember = NameOfPage;
            dataGridViewNew1.Width = 510;
            dataGridViewNew1.Height = 190;
            dataGridViewNew1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewNew1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabControl1.TabPages[0].Controls.Add(dataGridViewNew1);
            DataGridView dataGridViewNew2 = new DataGridView();
            NameOfPage = "Status";
            tabPageNew = new TabPage(NameOfPage);
            tabControl1.Controls.Add(tabPageNew);
            sql = "SELECT Status.[UID бака],Status.[Заполненность 1 мусора] FROM [Status]";
            oleDbDataAdapterNew = new OleDbDataAdapter(sql, connection);
            oleDbDataAdapterNew.Fill(dataSetNew, NameOfPage);
            dataGridViewNew2.DataSource = dataSetNew;
            dataGridViewNew2.DataMember = NameOfPage;
            dataGridViewNew2.Width = 510;
            dataGridViewNew2.Height = 190;
            dataGridViewNew2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewNew2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabControl1.TabPages[1].Controls.Add(dataGridViewNew2);

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