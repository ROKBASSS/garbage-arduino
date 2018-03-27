using System;
using System.Windows.Forms;

namespace PortArduino
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void выбратьПортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            com_chose f2 = new com_chose();
            f2.Show();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
        }

        private void обАвтореToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Авторство закреплено за (с)\nФомин Антон Александрович\nСтудент группы ИТ-16-Д"
                , "Об авторе");
        }

        private void прослушатьСПортаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            com_debug debg = new com_debug();
            debg.Show();
        }

        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseMenu dbm = new DatabaseMenu();
            dbm.Show();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = Properties.Settings.Default.Port;
        }
    }
}