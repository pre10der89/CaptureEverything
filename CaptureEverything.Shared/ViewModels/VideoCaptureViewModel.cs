// <copyright file="VideoCaptureViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CaptureEverything.Shared.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Mvvm;
    using Windows.Foundation;
    using Windows.Media.Capture;
    using Windows.Storage;
    using Windows.Storage.Streams;
    using Windows.UI.Core;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Media.Imaging;

    public class VideoCaptureViewModel : BindableBase
    {
        #region Private Fields

        private readonly CoreDispatcher dispatcher;

        #endregion

        #region Constructor(s)

        public VideoCaptureViewModel(CoreDispatcher dispatcher)
        {
            if (dispatcher == null)
            {
                throw new ArgumentNullException("dispatcher");
            }

            this.dispatcher = dispatcher;
        }

        #endregion

        #region IVideoCaptureViewModel Members

        #region Properties

        private string savedLocationPath;

        public string SavedLocationPath
        {
            get { return this.savedLocationPath; }
            set { this.SetProperty(ref this.savedLocationPath, value); }
        }

        private IRandomAccessStream capturedVideoSource;

        public IRandomAccessStream CapturedVideo
        {
            get { return this.capturedVideoSource; }
            set { this.SetProperty(ref this.capturedVideoSource, value); }
        }

        #endregion

        #region Commands

        #region Capture Command

        private ICommand captureCommand;

        public ICommand CaptureCommand
        {
            get
            {
                return this.captureCommand ?? (this.captureCommand = new DelegateCommand(this.OnExecuteCaptureCommand));
            }
        }

        private async void OnExecuteCaptureCommand()
        {
            await ExecuteCapture();
        }

        #endregion

        #endregion

        #endregion

        #region Private Methods

        private async Task ExecuteCapture()
        {
            await this.dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                try
                {
                    var camera = new CameraCaptureUI();

                    camera.VideoSettings.Format = CameraCaptureUIVideoFormat.Mp4;

                    var videoFile = await camera.CaptureFileAsync(CameraCaptureUIMode.Video);

                    if (videoFile != null)
                    {
                        var fileStream = await videoFile.OpenAsync(FileAccessMode.Read);

                        //this.CapturedVideo.Visibility = Visibility.Visible;
                        //this.CapturedVideo.SetSource(fileStream, "video/mp4");

                        this.CapturedVideo = fileStream;

                        this.SavedLocationPath = videoFile.Path;
                    }
                    else
                    {
                        //TODO: Send interaction request to the view
                        //await new MessageDialog("No Video was captured...").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    string message = string.Format("Failed to capture video: {0}", ex.Message);

                    //TODO: Send interaction request to the view
                    //await new MessageDialog(message).ShowAsync();
                }
            });
        }

        #endregion
    }
}
