using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_management
{
    public partial class WelcomeForm : Form
    {
        private Random random = new Random();
        public WelcomeForm()
        {
          
            InitializeComponent();
            this.Hide();

            SetRandomTimerInterval();

            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;


            
            timerLoad.Tick += timerLoad_Tick; 
            timerLoad.Start();


        
        }
        
        private void SetRandomTimerInterval()
        {
            
            int minInterval = 1000; 
            int maxInterval = 8001;

            timerLoad.Interval = random.Next(minInterval, maxInterval);
        }
        
        private void timerLoad_Tick(object sender, EventArgs e)
        {
            
            timerLoad.Stop();
            this.Close();


        }

    }
}
