namespace CaptureEverything.Common
{
    public class CameraCaptureHelper
    {
        //public async Task<StorageFile> TakePhotoAsync()
        //{
        //    try
        //    {
        //        var c amera = new CameraCaptureUI();

        //        //var aspectRatio = new Size(16, 9);

        //       // camera.PhotoSettings.CroppedAspectRatio = aspectRatio;

        //        var photoFile = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);

        //        if (photoFile != null)
        //        {
        //            var bitmapImage = new BitmapImage();

        //            using (IRandomAccessStream fileStream = await photoFile.OpenAsync(FileAccessMode.Read))
        //            {
        //                bitmapImage.SetSource(fileStream);
        //            }

        //            this.CapturedPhoto.Source = bitmapImage;

        //            this.PhotoFilePath.Text = photoFile.Path;
        //        }
        //        else
        //        {
        //            await(new MessageDialog("No picture was taken...")).ShowAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = string.Format("Failed to capture picture: {0}", ex.Message);

        //        await(new MessageDialog(message)).ShowAsync();
        //    }
        //}
    }
}
