using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace PortArduino
{
   

    public class DB
    {
            public bool chprt = false;

            public event EventHandler OnPortChange;

            private string port = "COM0";

            public string Port
            {
                get 
                { 
                    return port;
                }
                set 
                {
                    port = value;
                    MessageBox.Show("EVENT TRIGGERED");
                    OnPortChange(this,new EventArgs());
                }
            }
            

    }
    
    

}