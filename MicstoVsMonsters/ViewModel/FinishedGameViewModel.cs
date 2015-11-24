using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MicstoVsMonsters.Common;

namespace MicstoVsMonsters.ViewModel
{
    public class FinishedGameViewModel : Extansions, IGameViewModel
    {
        public Action<IGameViewModel> Navigate { get; set; }
        private ICommand _goBackToMainMenuCommand;
        private DelegateCommand _exitGameCommand;


        public ICommand GoBackToMainMenuCommand
        {
            get
            {
                return _goBackToMainMenuCommand ?? (_goBackToMainMenuCommand = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Navigate(new GameMainMenuViewModel() { Navigate = Navigate });
                    }

                });
            }
        }



        public ICommand ExitGameCommand
        {
            get
            {
                return _exitGameCommand ?? (_exitGameCommand = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Application.Current.MainWindow.Close();
                    }

                });
            }
        }
    }
}
