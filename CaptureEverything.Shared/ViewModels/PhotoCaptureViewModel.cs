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

    public class PhotoCaptureViewModel : BindableBase
    {
        #region Private Fields

        private readonly CoreDispatcher dispatcher;

        #endregion

        #region Constructor(s)

        public PhotoCaptureViewModel(CoreDispatcher dispatcher)
        {
            if (dispatcher == null)
            {
                throw new ArgumentNullException("dispatcher");
            }

            this.dispatcher = dispatcher;
        }

        #endregion

        #region IPhotoCaptureViewModel Members

        #region Properties

        private string savedLocationPath;

        public string SavedLocationPath
        {
            get { return this.savedLocationPath; }
            set { this.SetProperty(ref this.savedLocationPath, value); }
        }

        private ImageSource capturedPhotoSource;

        public ImageSource CapturedPhoto
        {
            get { return this.capturedPhotoSource; }
            set { this.SetProperty(ref this.capturedPhotoSource, value); }
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

                        this.CapturedPhoto = bitmapImage;

                        this.SavedLocationPath = photoFile.Path;
                    }
                    else
                    {
                        //TODO: Raise an interaction request to the view to display error
                        //await new MessageDialog("No picture was taken...").ShowAsync();
                    }
                }
                catch (Exception ex)
                {
                    string message = string.Format("Failed to capture picture: {0}", ex.Message);

                    //TODO: Raise an interaction request to the view to display error
                    //await new MessageDialog(message).ShowAsync();
                }
            });
        }

        #endregion
    }
}
