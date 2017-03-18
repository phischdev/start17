using UnityEngine;
using System;
using System.Collections;

using Vuforia;

using System.Threading;

using ZXing;
using ZXing.QrCode;
using ZXing.Common;


[AddComponentMenu("System/VuforiaScanner")]
public class VuforiaScanner : MonoBehaviour
{
	private bool shouldSearch = true;
	private bool cameraInitialized;
    private QRCodeReader barCodeReader;

    void Start()
    {
        barCodeReader = new QRCodeReader();

        StartCoroutine(InitializeCamera());
    }

    private IEnumerator InitializeCamera()
    {
        // Waiting a little seem to avoid the Vuforia's crashes.
        yield return new WaitForSeconds(1.25f);

        var isFrameFormatSet = CameraDevice.Instance.SetFrameFormat(Image.PIXEL_FORMAT.GRAYSCALE, true);
        Debug.Log(String.Format("FormatSet : {0}", isFrameFormatSet));

        // Force autofocus.
        var isAutoFocus = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        if (!isAutoFocus)
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
        }
        Debug.Log(String.Format("AutoFocus : {0}", isAutoFocus));
        cameraInitialized = true;
    }

    private void Update()
    {
		if (cameraInitialized && shouldSearch)
        {
            try
            {
                var cameraFeed = CameraDevice.Instance.GetCameraImage(Image.PIXEL_FORMAT.GRAYSCALE);
                if (cameraFeed == null)
                {
                    return;
                }

                var binary = new BinaryBitmap(
                new GlobalHistogramBinarizer(
                    new RGBLuminanceSource(
                        cameraFeed.Pixels, cameraFeed.BufferWidth,
                        cameraFeed.BufferHeight, true)));

                var data = barCodeReader.decode(binary);

                


                if (data != null)
                {
                    // QRCode detected.
                    Debug.Log(data.Text);
					shouldSearch = !WebStream.instance.initWebStream(data.Text);
                }
                else
                {
                    //Debug.Log("No QR code detected !");
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}