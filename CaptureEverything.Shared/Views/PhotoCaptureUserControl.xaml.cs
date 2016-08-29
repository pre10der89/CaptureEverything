namespace CaptureEverything.Shared
{
    using System;
    using Windows.Foundation;
    using Windows.Media.Capture;
    using Windows.Storage;
    using Windows.Storage.Streams;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;

    public sealed partial class PhotoCaptureUserControl : UserControl
    {
        public PhotoCaptureUserControl()
        {
            this.InitializeComponent();
        }

        private async void TakePicture_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var camera = new CameraCaptureUI();

                var aspectRatio = new Size(16, 9);

                camera.PhotoSettings.CroppedAspectRatio = aspectRatio;

                var photoFile = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);

                if (photoFile != null)
                {
                    var bitmapImage = new BitmapImage();

                    using (IRandomAccessStream fileStream = await photoFile.OpenAsync(FileAccessMode.Read))
                    {
                        bitmapImage.SetSource(fileStream);
                    }

                    this.CapturedPhoto.Source = bitmapImage;

                    this.PhotoFilePath.Text = photoFile.Path;
                }
                else
                {
                    await new MessageDialog("No picture was taken...").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Failed to capture picture: {0}", ex.Message);

                await new MessageDialog(message).ShowAsync();
            }
        }
    }
}
