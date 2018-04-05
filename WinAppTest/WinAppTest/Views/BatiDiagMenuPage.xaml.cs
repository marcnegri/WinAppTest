using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinAppTest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WinAppTest.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BatiDiagMenuPage : ContentPage
	{
		public BatiDiagMenuPage ()
		{
			InitializeComponent ();

            // 1 - Sur Xamarin les pages communiquent via Messaging Center

            // C'est un systeme de message avec des envois et des abonnements (send and subscribe)

            MessagingCenter.Subscribe<AddMenuItemPage, Models.MenuItem>(this, "AddMenuItem", (page, currentMenuItem) =>

            {

                vModel.AddItem(currentMenuItem);

            });



            MessagingCenter.Subscribe<BatiDiagMenuFormViewModel, Models.MenuItem>(this, "GetInfoItem", (page, SelectedMenuItem) =>

            {

                DisplayAlert(SelectedMenuItem.Title, string.Format("Vous avez appuyé sur : {0}", SelectedMenuItem.Title), "OK");

            });

        }





        //Mock to test 

        private void populateLstMenuItems()

        {

            /*

            for (int i = 0; i < 11; i++)

            {

                MenuItem itm = new MenuItem();

                itm.Image = "icon.png";

                itm.Title = i.ToString();

                LstMenuItems.Add(itm);

            }*/

        }



        /// <summary>

        /// Appel de la methode GetInfo lors d'un appuie sur un element

        /// </summary>

        /// <param name="sender">Sender.</param>

        /// <param name="e">E.</param>

        async void Handle_FlowItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)

        {

            await vModel.GetInfo();

        }



        public async void btnAddItem_Clicked(object sender, System.EventArgs e)

        {

            await Navigation.PushAsync(new AddMenuItemPage());

        }

    }
}