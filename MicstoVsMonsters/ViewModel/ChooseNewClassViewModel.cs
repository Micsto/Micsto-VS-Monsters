using System;
using MicstoVsMonsters.Common;
using MicstoVsMonsters.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using System.Text;

namespace MicstoVsMonsters.ViewModel
{
    public class ChooseNewClassViewModel : Extansions, IGameViewModel
    {

        public Action<IGameViewModel> Navigate { get; set; }
        private ObservableCollection<PlayerClass> _listOfPlayerClasses;
        private string _classDescription;
        private ICommand _goToCreatePlayerCommand;
        private ICommand _backToMainMenu;
        private ObservableCollection<Ability> _playerClassAbilitys;
        private PlayerClass _SelectedPlayerClass;
        private string _classImage;

        public ChooseNewClassViewModel()
        {
            ClassDescription = "...";
            ListOfPlayerClasses = new ObservableCollection<PlayerClass>(ReadXML(@"Common\Assets\XML\PlayerClass\PlayerClasses.xml", ListOfPlayerClasses));
            foreach (var PlayerClass in ListOfPlayerClasses)
            {
                // TODO: Make this string more generic. not hard coded where the path is.
                // Write the exact path here for your images. Havent figured out how to make this generic
                // ClassImage = @"C:\MyCode\MicstoVsMonsters\MicstoVsMonsters\Common\Assets\Images\PlayerClass\" + PlayerClass.Name + ".png";
                PlayerClass.ClassImage = ClassImage;
            }
            PlayerClassAbilitys = new ObservableCollection<Ability>();
            FillPlayerAbilitysList();
        }

        public string ClassDescription
        {
            get { return _classDescription; }
            set
            {
                _classDescription = value;
                OnPropertyChanged(nameof(ClassDescription));

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

        public ObservableCollection<PlayerClass> ListOfPlayerClasses
        {
            get { return _listOfPlayerClasses; }
            set
            {
                _listOfPlayerClasses = value;
                OnPropertyChanged(nameof(ListOfPlayerClasses));
            }
        }

        public ObservableCollection<Ability> PlayerClassAbilitys
        {
            get { return _playerClassAbilitys; }
            set
            {
                _playerClassAbilitys = value;
                OnPropertyChanged(nameof(PlayerClassAbilitys));
            }
        }



        public PlayerClass SelectedPlayerClass
        {
            get { return _SelectedPlayerClass; }
            set
            {
                _SelectedPlayerClass = value;
                OnPropertyChanged(nameof(SelectedPlayerClass));
                SelectedPlayerClass.Abilitys = new ObservableCollection<Ability>(PlayerClassAbilitys.Where(x => x.PlayerClassID == SelectedPlayerClass.ID));
                StringBuilder builder = SelectedPlayerClass.Abilitys.Select(x => x.Name).Aggregate(new StringBuilder(), (sb, s) => sb.Append(s + ", "));
                ClassDescription = SelectedPlayerClass.Name + ": " + SelectedPlayerClass.Description + System.Environment.NewLine + "Abilitys: " +
                    builder;
            }
        }


        public ICommand GoToCreatePlayerCommand
        {
            get
            {
                return _goToCreatePlayerCommand ?? (_goToCreatePlayerCommand = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Navigate(new CreateYourCharacterViewModel
                        {
                            Navigate = Navigate,
                            SelectedPlayerClass = SelectedPlayerClass
                        });
                    }

                });
            }
        }

        public ICommand BackToMainMenu
        {
            get
            {
                return _backToMainMenu ?? (_backToMainMenu = new DelegateCommand
                {
                    Execute = () =>
                    {
                        Navigate(new GameMainMenuViewModel { Navigate = Navigate });
                    }

                });
            }
        }

        public void FillPlayerAbilitysList()
        {
            var temp = new ObservableCollection<Ability>();
            temp = ReadXML(@"Common\Assets\XML\PlayerClass\WarriorAbilitys.xml", temp);
            AddRange(PlayerClassAbilitys, temp);

            var temp2 = new ObservableCollection<Ability>();
            temp2 = ReadXML(@"Common\Assets\XML\PlayerClass\WizzardAbilitys.xml", temp2);
            AddRange(PlayerClassAbilitys, temp2);

            var temp3 = new ObservableCollection<Ability>();
            temp3 = ReadXML(@"Common\Assets\XML\PlayerClass\ProgrammerAbilitys.xml", PlayerClassAbilitys);
            AddRange(PlayerClassAbilitys, temp3);
        }


    }
}
