using MicstoVsMonsters.Common;
using System;
using System.Windows;
using System.Windows.Input;

namespace MicstoVsMonsters.ViewModel
{
    public class GameMainMenuViewModel : Extansions, IGameViewModel
    {
        public Action<IGameViewModel> Navigate { get; set; }
        private ICommand _startNewGameCommand;
        private ICommand _exitGameCommand;

        public ICommand StartNewGameCommand
        {
            get
            {
                return _startNewGameCommand ?? (_startNewGameCommand = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Navigate(new ChooseNewClassViewModel { Navigate = Navigate });
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
