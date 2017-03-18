//using rtaNetworking.Streaming;
using rtaNetworking.Streaming;
using System;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace CS_Holo_Screen
{
    public partial class Form1 : Form
    {
        private ImageStreamingServer _Server;

         string Ip()
        {
            return System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())[0].MapToIPv4().ToString();
        }
        const string port = "8080";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _Server = new ImageStreamingServer();
            _Server.Start(8080);

            barCodeControl1.Symbology = KeepAutomation.Barcode.Symbology.QRCode;
            barCodeControl1.CodeToEncode = Ip() + ";" + port;
            barCodeControl1.X = 8;
            barCodeControl1.Y = 8;
            barCodeControl1.BottomMargin = 10;
            barCodeControl1.LeftMargin = 10;
            barCodeControl1.RightMargin = 10;
            barCodeControl1.TopMargin = 10;
            barCodeControl1.DisplayText = true;
            barCodeControl1.ChecksumEnabled = true;
            barCodeControl1.DisplayChecksum = true;
            barCodeControl1.Orientation = KeepAutomation.Barcode.Orientation.Degree0;
            barCodeControl1.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
            barCodeControl1.DPI = 72;


            _Server = new ImageStreamingServer();
            _Server.Start(8080);
        }
    }
}
