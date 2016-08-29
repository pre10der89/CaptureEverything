// <copyright file="VideoCaptureViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using CaptureEverything.Shared.ViewModels;

namespace CaptureEverything.Shared.ViewModels
{
    using System;
    using Microsoft.Practices.Prism.Mvvm;
    using Windows.UI.Core;

    public class MainPageViewModel : BindableBase
    {
        #region Private Fields

        private readonly CoreDispatcher dispatcher;

        #endregion

        #region Constructor(s)

        public MainPageViewModel(CoreDispatcher dispatcher)
        {
            if (dispatcher == null)
            {
                throw new ArgumentNullException("dispatcher");
            }

            this.dispatcher = dispatcher;

            this.photoCaptureViewModel = new PhotoCaptureViewModel(dispatcher);
            this.videoCaptureViewModel = new VideoCaptureViewModel(dispatcher);
        }

        #endregion

        #region IMainPageViewModel Members

        #region Properties

        private PhotoCaptureViewModel photoCaptureViewModel;

        public PhotoCaptureViewModel PhotoCapture
        {
            get { return this.photoCaptureViewModel; }
            set { this.SetProperty(ref this.photoCaptureViewModel, value); }
        }

        private VideoCaptureViewModel videoCaptureViewModel;

        public VideoCaptureViewModel VideoCapture
        {
            get { return this.videoCaptureViewModel; }
            set { this.SetProperty(ref this.videoCaptureViewModel, value); }
        }

        #endregion

        #region Commands
        #endregion

        #endregion

        #region Private Methods
        #endregion
    }
}
