using System;
using SQLite;
using Xamarin.Forms;

namespace WinAppTest.Models
{
    public class MenuItem
    {
        private string title;
        private string image;
        private ImageSource picture;

        public MenuItem()
        {
        }

        [Ignore]
        public ImageSource Picture
        {
            get
            {
                if (!String.IsNullOrEmpty(this.image))
                {
                    return Tools.ImageTool.Base64ToImage(this.image);
                }
                else
                {
                    //TODO : Return image par defaut
                    return null;
                }
            }

            set
            {
                picture = value;
            }
        }

        #region Accesseurs
        public string Title { get => title; set => title = value; }
        public string Image { get => image; set => image = value; }
        #endregion
    }
}
