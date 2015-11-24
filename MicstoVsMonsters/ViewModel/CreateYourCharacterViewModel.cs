using MicstoVsMonsters.Common;
using MicstoVsMonsters.Model;
using System;
using System.Windows;
using System.Windows.Input;

namespace MicstoVsMonsters.ViewModel
{
    public class CreateYourCharacterViewModel : Extansions, IGameViewModel
    {
        public Action<IGameViewModel> Navigate { get; set; }
        private Player _newPlayer;
        private ICommand _goBackToClassView;
        private ICommand _goToGameView;
        private string _classImage;
        private PlayerClass _selectedPlayerClass;


        public CreateYourCharacterViewModel()
        {
            NewPlayer = new Player();
        }

        public Player NewPlayer
        {
            get { return _newPlayer; }
            set
            {
                _newPlayer = value;
                OnPropertyChanged(nameof(NewPlayer));
            }
        }

        public string ClassImage
        {
            get { return _classImage; }
            set
            {
                _classImage = value;
                OnPropertyChanged(nameof(ClassImage));
            }
        }

        public PlayerClass SelectedPlayerClass
        {
            get { return _selectedPlayerClass; }
            set
            {
                _selectedPlayerClass = value;
                OnPropertyChanged(nameof(SelectedPlayerClass));
                // Write the exact path here for your images. Havent figured out how to make this generic
                ClassImage = @"C:\MyCode\MicstoVsMonsters\MicstoVsMonsters\Common\Assets\Images\PlayerClass\" + SelectedPlayerClass.Name + ".png";
                NewPlayer.PlayersClass = SelectedPlayerClass;

            }
        }


        public ICommand GoBackToClassView
        {
            get
            {
                return _goBackToClassView ?? (_goBackToClassView = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Navigate(new ChooseNewClassViewModel { Navigate = Navigate });
                    }

                });
            }
        }

        public ICommand GoToGameView
        {
            get
            {
                return _goToGameView ?? (_goToGameView = new DelegateCommand
                {
                    Execute = () =>
                    {
                        if (NewPlayer.Name != null)
                        {
                            Navigate(new GameViewViewModel { Navigate = Navigate, NewPlayer = NewPlayer, SelectedPlayerClass = SelectedPlayerClass });
                        }
                        else
                        {
                            MessageBox.Show("Please write your characters name!");
                        }
                    }

                });
            }
        }
    }
}
