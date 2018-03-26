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
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            DataTable schemaTable = connection.GetSchema("Tables", restrictions);
            int Tablescount = schemaTable.Columns.Count;
            int i = 0; 
            foreach (DataRow row in schemaTable.Rows)
            {
                string NameOfPage = row[2].ToString();

                TabPage tabPageNew = new TabPage(NameOfPage);
                DataGridView dataGridViewNew = new DataGridView();
                tabControl1.Controls.Add(tabPageNew);
                string sql = "SELECT * FROM " + NameOfPage;
                DataSet dataSetNew = new DataSet();
                OleDbDataAdapter oleDbDataAdapterNew = new OleDbDataAdapter(sql, connection);
                oleDbDataAdapterNew.Fill(dataSetNew, NameOfPage);
                dataGridViewNew.DataSource = dataSetNew;
                dataGridViewNew.DataMember = NameOfPage;
                tabControl1.TabPages[i].Controls.Add(dataGridViewNew);

                i++;

            }


            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
