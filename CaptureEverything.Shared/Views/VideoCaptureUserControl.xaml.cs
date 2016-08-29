namespace CaptureEverything.Shared
{
    using System;
    using Windows.Media.Capture;
    using Windows.Storage;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class VideoCaptureUserControl : UserControl
    {
        public VideoCaptureUserControl()
        {
            this.InitializeComponent();
        }

        private async void TakeVideo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var camera = new CameraCaptureUI();

                camera.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;

                var videoFile = await camera.CaptureFileAsync(CameraCaptureUIMode.Video);

                if (videoFile != null)
                {
                    var fileStream = await videoFile.OpenAsync(FileAccessMode.Read);

                    this.CapturedVideo.Visibility = Visibility.Visible;
                    this.CapturedVideo.SetSource(fileStream, "video/mp4");

                    this.VideoFilePath.Text = videoFile.Path;
                }
                else
                {
                    await new MessageDialog("No Video was captured...").ShowAsync();
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Failed to capture video: {0}", ex.Message);

                await new MessageDialog(message).ShowAsync();
            }
        }
    }
}
