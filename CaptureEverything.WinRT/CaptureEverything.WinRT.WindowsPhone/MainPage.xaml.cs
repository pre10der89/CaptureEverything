using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// CameraCaptureUI Not Available..

namespace CaptureEverything.WinRT
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void TakePicture_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var camera = new CameraCaptureUI();

            //    var aspectRatio = new Size(16, 9);

            //    camera.PhotoSettings.CroppedAspectRatio = aspectRatio;

            //    var photoFile = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);

            //    if (photoFile != null)
            //    {
            //        var bitmapImage = new BitmapImage();

            //        using (IRandomAccessStream fileStream = await photoFile.OpenAsync(FileAccessMode.Read))
            //        {
            //            bitmapImage.SetSource(fileStream);
            //        }

            //        this.CapturedPhoto.Source = bitmapImage;

            //        this.PhotoFilePath.Text = photoFile.Path;
            //    }
            //    else
            //    {
            //        await (new MessageDialog("No picture was taken...")).ShowAsync();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    string message = string.Format("Failed to capture picture: {0}", ex.Message);

            //    await (new MessageDialog(message)).ShowAsync();
            //}
        }

        private async void TakeVideo_Click(object sender, RoutedEventArgs e)
        {
        //    try
        //    {
        //        var camera = new CameraCaptureUI();

        //        camera.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;

        //        var videoFile = await camera.CaptureFileAsync(CameraCaptureUIMode.Video);

        //        if (videoFile != null)
        //        {
        //            var fileStream = await videoFile.OpenAsync(FileAccessMode.Read);

        //            this.CapturedVideo.Visibility = Visibility.Visible;
        //            this.CapturedVideo.SetSource(fileStream, "video/mp4");

        //            this.VideoFilePath.Text = videoFile.Path;
        //        }
        //        else
        //        {
        //            await (new MessageDialog("No Video was captured...")).ShowAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = string.Format("Failed to capture video: {0}", ex.Message);

        //        await (new MessageDialog(message)).ShowAsync();
        //    }
        //}
    }
}
