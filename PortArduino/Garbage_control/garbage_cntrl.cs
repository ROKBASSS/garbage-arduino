using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PortArduino.Garbage_control
{
    public partial class garbage_cntrl : Form
    {
        public garbage_cntrl()
        {
            InitializeComponent();
        }

        private void garbage_cntrl_Load(object sender, EventArgs e)
        {

        }

        private void garbage_cntrl_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}
