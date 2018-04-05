using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTest.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WinAppTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddMenuItemPage : ContentPage
	{

        private MediaFile menuItemThumbnail;
        public AddMenuItemPage ()
		{
			InitializeComponent ();
		}

        /// <summary>

        /// Methode d'upload de l'image depuis le Device

        /// </summary>

        /// <param name="sender">Sender.</param>

        /// <param name="e">E.</param>

        public async void imgAddImage_Clicked(object sender, System.EventArgs e)

        {



            try

            {

                // - Utilisation d'une classe static pour la recup de l'image dans le device

                menuItemThumbnail = await Tools.ImageTool.PickAndUploadPicture(PhotoSize.Medium);

                if (menuItemThumbnail != null)

                {

                    imgAddImage.Source = menuItemThumbnail.Path;

                }

                else

                {

                    await DisplayAlert("Oups...", "L'upload de l'image n'a pas fonctionné, merci d'essayer de nouveau", "OK");

                }

            }

            catch (Exception ex)

            {

                Debug.WriteLine(ex.Message + ex.StackTrace);

                await DisplayAlert("Oups...", "L'upload de l'image n'a pas fonctionné, merci d'essayer de nouveau", "OK");

            }

        }



        /// <summary>

        /// Methode de validation et ajout de l'item Menu

        /// A noter que l'objet est créé et envoyé via le MessagingCenter

        /// </summary>

        /// <param name="sender">Sender.</param>

        /// <param name="e">E.</param>

        async void btnAddItem_Clicked(object sender, System.EventArgs e)

        {

            try

            {

                if (menuItemThumbnail != null)

                {

                    Models.MenuItem itm = new Models.MenuItem();

                    // - image est transformé en base64 pour etre stockée en base en format chaine de caracteres

                    itm.Image = await ImageTool.ConvertStreamToBase64(menuItemThumbnail.GetStream());

                    itm.Title = etyTitre.Text;

                    if (!String.IsNullOrEmpty(etyTitre.Text))

                    {

                        MessagingCenter.Send<AddMenuItemPage, Models.MenuItem>(this, "AddMenuItem", itm);

                        await Navigation.PopToRootAsync();

                    }
                    else
                    {

                        await DisplayAlert("Pas de titre", "Merci de mettre un titre", "OK");

                    }

                }

                else

                    await DisplayAlert("Pas d'image uploadé", "Merci d'utiliser une image", "OK");

            }
            catch (Exception ex)

            {

                Debug.WriteLine(ex.Message + ex.StackTrace);

            }



        }
    }
}