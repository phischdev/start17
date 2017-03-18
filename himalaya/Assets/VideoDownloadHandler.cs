using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;



public class VideoDownloadHandler : DownloadHandlerScript
{
	public byte[] mybuffer;
	public int readLength;

    // Standard scripted download handler - will allocate memory on each ReceiveData callback
    public VideoDownloadHandler() : base()
    {
    }


    // Pre-allocated scripted download handler
    // Will reuse the supplied byte array to deliver data.
    // Eliminates memory allocation.
    public VideoDownloadHandler(byte[] buffer) : base(buffer)
    {
    }

    // Required by DownloadHandler base class. Called when you address the 'bytes' property.
    protected override byte[] GetData() { return null; }

    // Called once per frame when data has been received from the network.
    protected override bool ReceiveData(byte[] data, int dataLength)
    {
        if (data == null || data.Length < 1)
        {
            Debug.Log("LoggingDownloadHandler :: ReceiveData - received a null/empty buffer");
            return false;
			
        }

        Debug.Log(string.Format("LoggingDownloadHandler :: ReceiveData - received {0} bytes", dataLength));
		readLength = dataLength;
		mybuffer = data;
        return true;
    }



    // Called when all data has been received from the server and delivered via ReceiveData
    protected override void CompleteContent()
    {
        Debug.Log("LoggingDownloadHandler :: CompleteContent - DOWNLOAD COMPLETE!");
    }

    // Called when a Content-Length header is received from the server.
    protected override void ReceiveContentLength(int contentLength)
    {
        Debug.Log(string.Format("LoggingDownloadHandler :: ReceiveContentLength - length {0}", contentLength));
    }
}
