using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicstoVsMonsters.Common;

namespace MicstoVsMonsters.ViewModel
{
	public class ApplicationViewModel : Extansions
	{
		private IGameViewModel _currentPageViewModel;
		public IGameViewModel CurrentPageViewModel
		{
			get
			{
				return _currentPageViewModel;
			}
			set
			{
				_currentPageViewModel = value;
				OnPropertyChanged("CurrentPageViewModel");
			}
		}

		public ApplicationViewModel()
		{
			CurrentPageViewModel = new GameMainMenuViewModel { Navigate = Navigate };
		}

		public void Navigate(IGameViewModel viewModel)
		{

			CurrentPageViewModel = viewModel;
		}
	}
}
