using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WinAppTest
{
    /// <summary>
    /// Classe de base pour les ViewModels
    /// Permet d'heriter de INotifyPropertychanged : Interface 
    /// qui permet d'interagir avec les composants graphiques
    /// </summary>
	public class BaseViewModel: INotifyPropertyChanged
	{
		public BaseViewModel()
		{
		}

		public bool IsBusy
		{
			get
			{
				return isBusy;
			}
			set
			{
				isBusy = value;
				RaisePropertyChanged();
			}
		}

		protected void RaisePropertyChanged([CallerMemberName]  string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		public virtual Task OnNavigated(object parameter) { return Task.Run(() => { }); }
		bool isBusy;

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

	}
}