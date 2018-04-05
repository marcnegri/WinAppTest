using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using WinAppTest.Models;
using Xamarin.Forms;

namespace WinAppTest.ViewModels
{
	public class BatiDiagMenuFormViewModel : BaseViewModel
	{

        // Accesseurs
        private ObservableCollection<Models.MenuItem> lstMenuItems;
        private Models.MenuItem selectedMenuItem;

        public Models.MenuItem SelectedMenuItem
        {
            get
            {
                return selectedMenuItem;
            }

            set
            {
                if (selectedMenuItem == value)
                    return;

                selectedMenuItem = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<Models.MenuItem> LstMenuItems
        {
            get
            {
                return lstMenuItems;
            }

            set
            {
                if (lstMenuItems == value)
                    return;

                lstMenuItems = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Init du View Model
        /// Recuperation des items Menus stockes en base
        /// </summary>
        public BatiDiagMenuFormViewModel()
		{
            lstMenuItems = new ObservableCollection<Models.MenuItem>();
            selectedMenuItem = new Models.MenuItem();
            LstMenuItems = new ObservableCollection<Models.MenuItem>(App.Database.GetItems());
            CmdGetInfo = new Command(async () => await GetInfo());
		}

        public ICommand CmdGetInfo { protected set; get; }

        /// <summary>
        /// Le messaging Center envoie l'item selectionne lors 
        /// de son clic
        /// </summary>
        /// <returns></returns>
        public async Task GetInfo()
        {
            MessagingCenter.Send<BatiDiagMenuFormViewModel, Models.MenuItem>(this, "GetInfoItem", SelectedMenuItem);
        }

        public async Task AddItem(Models.MenuItem currentItem)
		{
			IsBusy = true;
			try
			{
                lstMenuItems.Add(currentItem);
                App.Database.Insert(currentItem);
			}
			catch (Exception ex)
			{
                Debug.WriteLine(ex.Message);
				//Ici on imagine un Log d erreur
			}
			finally
			{
				IsBusy = false;
			}
		}

	}
}
