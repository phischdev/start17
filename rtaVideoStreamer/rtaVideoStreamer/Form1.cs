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
using KeepAutomation.Barcode;
using KeepAutomation.Barcode.Windows;

namespace rtaVideoStreamer
{
    public partial class Form1 : Form
    {

        private ImageStreamingServer _Server;
        private Timer qrtimer;

        public Form1()
        {
            InitializeComponent();
            this.linkLabel1.Text = URL;
        }

        private String URL { get { return string.Format("http://{0}:8080", Environment.MachineName); } }

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
            if (!_Server.IsRunning)
                _Server.Start(8080);

            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;


            //show QR-Code
            int timerstate = 0;
            qrtimer = new Timer();
            qrtimer.Interval = 5000;

            Action<Object, EventArgs> timer_ticker = (object o, EventArgs args) => 
            {
                if (timerstate == 0)
                {
                    // show qr code
                    makeQRcode();
                }
                else if (timerstate == 1)
                {
                    // show tracker feature
                    Image tracker =  Properties.Resources.highresSnacki;
                    imgQR.Image = tracker;
                }
                else
                {
                    // darken screen
                    BrightnessControl.SetBrightness(0);
                    qrtimer.Stop();
                    qrtimer.Dispose();
                }
                timerstate++;
            };

            qrtimer.Tick += new EventHandler(timer_ticker);
            timer_ticker(null, null);
            qrtimer.Start();
        }

        private System.IO.MemoryStream qrImageStream = null;
        private void makeQRcode()
        {
            if (qrImageStream == null)
            {
                BarCodeControl bcc = new BarCodeControl();
                bcc.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
                bcc.CodeToEncode = URL;
                bcc.X = 15;
                bcc.Y = 15;
                bcc.BottomMargin = 10;
                bcc.LeftMargin = 10;
                bcc.RightMargin = 10;
                bcc.TopMargin = 10;
                //bcc.DisplayText = true;
                bcc.ChecksumEnabled = true;
                bcc.DisplayChecksum = true;
                bcc.Orientation = KeepAutomation.Barcode.Orientation.Degree0;
                bcc.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
                bcc.DPI = 72;

                qrImageStream = new System.IO.MemoryStream();
                bcc.SaveAsImage(qrImageStream);
            }
            imgQR.Image = Image.FromStream(qrImageStream);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (qrtimer != null)
            {
                qrtimer.Stop();
                qrtimer.Dispose();
            }
            BrightnessControl.SetBrightness(70);
            //if (_Server.IsRunning)
            //{
            //    _Server.Dispose();
            //}
            //_Server.Stop();
            Application.Exit();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            if (qrtimer != null)
            {
                qrtimer.Stop();
                qrtimer.Dispose();
            }
            BrightnessControl.SetBrightness(90);
            imgQR.Image = null;

            btnStart_Click(null, null);
        }
    }


}
