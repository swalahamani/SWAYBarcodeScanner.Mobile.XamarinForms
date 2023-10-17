using SWAYBarcodeScanner.Mobile;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;

namespace SampleApp.Maui;

public partial class Page2 : ContentPage
{
    public Page2()
    {
        InitializeComponent();
        On<iOS>().SetUseSafeArea(true);
    }


    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void FlashlightButton_Clicked(object sender, EventArgs e)
    {
        Camera.TorchOn = !Camera.TorchOn;
    }

    private void SwitchCameraButton_Clicked(object sender, EventArgs e)
    {
        Camera.CameraFacing = Camera.CameraFacing == CameraFacing.Back
                                  ? CameraFacing.Front
                                  : CameraFacing.Back;
    }

    private void CameraView_OnDetected(object sender, OnDetectedEventArg e)
    {
        List<BarcodeResult> obj = e.BarcodeResults;

        string result = string.Empty;
        for (int i = 0; i < obj.Count; i++)
        {
            result += $"Type : {obj[i].BarcodeType}, Value : {obj[i].DisplayValue}{Environment.NewLine}";
        }
        
        this.Dispatcher.Dispatch(async () =>
        {
            await DisplayAlert("Result", result, "OK");
            //GoogleVisionBarCodeScanner.Methods.Reset();
            await Navigation.PopModalAsync();
        });

    }
}