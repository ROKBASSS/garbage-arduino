using System;
using System.Windows.Forms;

namespace PortArduino
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}