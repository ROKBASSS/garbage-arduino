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
            this.Hide();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
            this.Hide();
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
            this.Hide();
        }

        private void базаДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseMenu dbm = new DatabaseMenu();
            dbm.Show();
            this.Hide();
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = Properties.Settings.Default.Port;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Garbage_control.garbage_cntrl gc = new Garbage_control.garbage_cntrl();
            gc.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ROKBASSS/garbage-arduino");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://sf.misis.ru/");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://sf.misis.ru/sveden/structure/faculties-and-departments/automation-and-IT/kafedra-avtomatizirovannyh-i-informacionnyh-sistem-upravleniya");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

    }
}