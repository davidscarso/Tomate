using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomodoroX
{
    public partial class Pomodoro : Form
    {
        int min, seg, estado;        

        public Pomodoro()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCronometro.Text = "25:00";
            min = 25;
            seg = 00;
            estado = 0;
        }

        private void btnPomodoro_Click(object sender, EventArgs e)
        {            
            lblCronometro.Text = "25:00";
            min = 25;
            seg = 00;
            estado = 0;
        }

        private void btnShortBreak_Click(object sender, EventArgs e)
        {
            lblCronometro.Text = "05:00";
            min = 05;
            seg = 00;
            estado = 1;
        }

        private void btnLongBreak_Click(object sender, EventArgs e)
        {
            lblCronometro.Text = "10:00";
            min = 10;
            seg = 00;
            estado = 2;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void lblCronometro_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            switch (estado)
            {
                case 0:
                    min = 25;
                    seg = 00;
                    lblCronometro.Text = "25:00";
                    break;
                case 1:
                    min = 05;
                    seg = 00;
                    lblCronometro.Text = "05:00";
                    break;
                case 2:
                    min = 10;
                    seg = 00;
                    lblCronometro.Text = "10:00";
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {            
            if (seg == 0 && min == 0)
            {
                //fin alarma
                timer1.Enabled = false;                
                notifyIcon1.ShowBalloonTip(10);

            }
            else if (seg == 0 && min > 0)
            {
                seg = 59;
                min--;
                lblCronometro.Text = min.ToString().PadLeft(2, '0') + ':' + seg.ToString().PadLeft(2, '0');
            }
            else if (seg > 0)
            {
                seg--;
                lblCronometro.Text = min.ToString().PadLeft(2, '0') + ':' + seg.ToString().PadLeft(2, '0');
            }
            
        }
    }
}
