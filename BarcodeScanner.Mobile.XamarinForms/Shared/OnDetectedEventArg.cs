using System;
using System.Collections.Generic;
using System.Text;

namespace SWAYBarcodeScanner.Mobile
{
    public class OnDetectedEventArg : EventArgs
    {
        public List<BarcodeResult> BarcodeResults { get; set; }
        public byte[] ImageData { get; set; }
        public OnDetectedEventArg()
        {
            ImageData = new byte[0];
            BarcodeResults = new List<BarcodeResult>();
        }
    }
}
