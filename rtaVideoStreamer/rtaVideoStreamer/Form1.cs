using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rtaNetworking.Streaming;
using System.Net;

namespace rtaVideoStreamer
{
    public partial class Form1 : Form
    {

        private ImageStreamingServer _Server;
        private Timer qrtimer;

        public Form1()
        {
            InitializeComponent();
            this.linkLabel1.Text = string.Format("http://{0}:8080", Environment.MachineName);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _Server = new ImageStreamingServer();
        }

        private DateTime time = DateTime.MinValue;

        private void timer1_Tick(object sender, EventArgs e)
        {
            int count = (_Server.Clients != null) ? _Server.Clients.Count() : 0;

            this.sts.Text = "Clients: " + count.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("chrome", this.linkLabel1.Text);

        }

       

        private void btnStart_Click(object sender, EventArgs e)
        {
            _Server.Start(8080);

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;


            //show QR-Code
            int timerstate = 0;
            qrtimer = new Timer();
            qrtimer.Interval = 2000;
            qrtimer.Tick += (object o, EventArgs args) => 
            {
                if (timerstate == 0)
                {
                    // show qr code
                }
                else if (timerstate == 1)
                {
                    // show tracker feature
                    Image tracker =  Properties.Resources.snacki;
                    imgQR.Image = tracker;
                }
                else
                {
                    // darken screen

                    qrtimer.Stop();
                }
                timerstate++;
            };
            qrtimer.Start();
        }

       


        private void btnClose_Click(object sender, EventArgs e)
        {
            if (qrtimer != null)
            {
                qrtimer.Stop();
                qrtimer.Dispose();
            }
            //if (_Server.IsRunning)
            //{
            //    _Server.Dispose();
            //}
            //_Server.Stop();
            Application.Exit();
        }
    }


}
