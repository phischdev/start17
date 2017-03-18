namespace CS_Holo_Screen
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.barCodeControl1 = new KeepAutomation.Barcode.Windows.BarCodeControl();
            this.SuspendLayout();
            // 
            // barCodeControl1
            // 
            this.barCodeControl1.ApplicationIndicator = 0;
            this.barCodeControl1.BarCodeHeight = 0F;
            this.barCodeControl1.BarcodeUnit = KeepAutomation.Barcode.BarcodeUnit.Pixel;
            this.barCodeControl1.BarCodeWidth = 0F;
            this.barCodeControl1.BearerBarLeft = 1F;
            this.barCodeControl1.BearerBarTop = 1F;
            this.barCodeControl1.BottomMargin = 0F;
            this.barCodeControl1.ChecksumEnabled = false;
            this.barCodeControl1.CodabarStartChar = KeepAutomation.Barcode.CodabarStartStopChar.A;
            this.barCodeControl1.CodabarStopChar = KeepAutomation.Barcode.CodabarStartStopChar.A;
            this.barCodeControl1.CodeToEncode = "128";
            this.barCodeControl1.DataMatrixDataMode = KeepAutomation.Barcode.DataMatrixDataMode.Auto;
            this.barCodeControl1.DataMatrixFormatMode = KeepAutomation.Barcode.DataMatrixFormatMode.FM_12X12;
            this.barCodeControl1.DisplayChecksum = true;
            this.barCodeControl1.DisplayStartStop = true;
            this.barCodeControl1.DisplayText = true;
            this.barCodeControl1.DPI = 72;
            this.barCodeControl1.FNC1 = KeepAutomation.Barcode.FNC1.None;
            this.barCodeControl1.GroupEnabled = false;
            this.barCodeControl1.GroupId = 0;
            this.barCodeControl1.GroupItemCount = 0;
            this.barCodeControl1.GroupItemId = 0;
            this.barCodeControl1.I = 1F;
            this.barCodeControl1.LeftMargin = 0F;
            this.barCodeControl1.Location = new System.Drawing.Point(4, 5);
            this.barCodeControl1.Name = "barCodeControl1";
            this.barCodeControl1.Orientation = KeepAutomation.Barcode.Orientation.Degree0;
            this.barCodeControl1.PDF417ColumnCount = 5;
            this.barCodeControl1.PDF417DataMode = KeepAutomation.Barcode.PDF417DataMode.Text;
            this.barCodeControl1.PDF417ECL = KeepAutomation.Barcode.PDF417ECL.ECL_2;
            this.barCodeControl1.PDF417RowCount = 3;
            this.barCodeControl1.PDF417Truncated = false;
            this.barCodeControl1.PDF417XtoYRatio = 0.33333F;
            this.barCodeControl1.QRCodeDataMode = KeepAutomation.Barcode.QRCodeDataMode.Auto;
            this.barCodeControl1.QRCodeECI = 3;
            this.barCodeControl1.QRCodeECL = KeepAutomation.Barcode.QRCodeECL.L;
            this.barCodeControl1.QRCodeVersion = KeepAutomation.Barcode.QRCodeVersion.V1;
            this.barCodeControl1.RightMargin = 0F;
            this.barCodeControl1.ShortTallRatio = 0.4F;
            this.barCodeControl1.Size = new System.Drawing.Size(474, 348);
            this.barCodeControl1.SupplementCode = "";
            this.barCodeControl1.SupplementHeight = 0.8F;
            this.barCodeControl1.SupplementSpace = 15F;
            this.barCodeControl1.Symbology = KeepAutomation.Barcode.Symbology.Code128Auto;
            this.barCodeControl1.TabIndex = 0;
            this.barCodeControl1.TextFont = new System.Drawing.Font("Arial", 9F);
            this.barCodeControl1.TextMargin = 6F;
            this.barCodeControl1.TildeEnabled = false;
            this.barCodeControl1.TopMargin = 0F;
            this.barCodeControl1.WideNarrowRatio = 2F;
            this.barCodeControl1.X = 1F;
            this.barCodeControl1.Y = 50F;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 435);
            this.Controls.Add(this.barCodeControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private KeepAutomation.Barcode.Windows.BarCodeControl barCodeControl1;
    }
}

