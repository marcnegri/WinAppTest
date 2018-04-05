using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace WinAppTest.Tools
{
	public static class ImageTool
	{
        /// <summary>
        /// Base64s to image.
        /// </summary>
        /// <returns>The to image.</returns>
        /// <param name="base64String">Base64 string.</param>
		public static  ImageSource Base64ToImage(string base64String)
		{
			ImageSource imgsrc = null;
			try
			{
				byte[] imageBytes = Convert.FromBase64String(base64String);
				imgsrc = ImageSource.FromStream(() => new MemoryStream(imageBytes));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return imgsrc;
		}

        /// <summary>
        /// Picks the and upload picture.
        /// </summary>
        /// <returns>The and upload picture.</returns>
        /// <param name="_quality">Quality.</param>
		public static async Task<MediaFile> PickAndUploadPicture(PhotoSize _quality)
		{
			if (!CrossMedia.Current.IsPickPhotoSupported)
			{
				Debug.WriteLine("NO upload");
			}

			var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
			{
				PhotoSize = _quality,
				CompressionQuality = 60
			});

			return file;
		}

        /// <summary>
        /// Converts the stream to base64.
        /// </summary>
        /// <returns>The stream to base64.</returns>
        /// <param name="photoStream">Photo stream.</param>
		public static async Task<string> ConvertStreamToBase64(Stream photoStream)
		{
            if (photoStream != null)
            {
                System.IO.BinaryReader br = new System.IO.BinaryReader(photoStream);
                Byte[] bytes = br.ReadBytes((Int32)photoStream.Length);
                //return "data:image/jpg;base64," + Convert.ToBase64String(bytes, 0, bytes.Length);	
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }else{
                return "";
            }
		}


	}
}
