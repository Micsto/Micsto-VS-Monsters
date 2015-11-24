using MicstoVsMonsters.Common;
using MicstoVsMonsters.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace MicstoVsMonsters.ViewModel
{
    public class GameViewViewModel : Extansions, IGameViewModel
    {

        #region Private fields

        public Action<IGameViewModel> Navigate { get; set; }
        private Player _newPlayer;
        private PlayerClass _selectedPlayerClass;
        private DelegateCommand _fightActionInitiatedCommand;
        private DelegateCommand _showPlayerItems;
        private DelegateCommand<Ability> _attackWithAbilityCommand;
        private DelegateCommand<Items> _useItemCommand;
        private ObservableCollection<Ability> _playerAbilitys;
        private ObservableCollection<Monster> _monsters;
        private ObservableCollection<Ability> _monsterAbility;
        private List<string> _monsterImages;
        private Ability _playerAbility;
        private string _classImage;
        private string _itemImage;
        private string _monsterImage;
        private string _playerHealth;
        private string _monsterHealth;
        private string _actionText;
        private bool _fightActionInitiated = false;
        private bool _itemsShowing = false;
        private bool _itemsInBag = true;
        private Monster _monsterCurrentlyFighting;

        #endregion

        public GameViewViewModel()
        {
            MonsterImages = new List<string>();
            PlayerAbilitys = new ObservableCollection<Ability>();
            MonsterAbilitys = new ObservableCollection<Ability>();
            Monsters = new ObservableCollection<Monster>(ReadXML(@"Common\Assets\XML\Monster\Monsters.xml", Monsters));
            foreach (var monster in Monsters)
            {
                //  Write the exact path here for your images. Havent figured out how to make this generic
                MonsterImage = @"C:\MyCode\MicstoVsMonsters\MicstoVsMonsters\Common\Assets\Images\Monster\" + Regex.Replace(monster.Name, @"\s+", "") + ".png";
                monster.MonsterImage = MonsterImage;
                MonsterImages.Add(MonsterImage);
            }
            FillMonsterAbilitysList();
            GenerateMonster();

        }

        #region Bools

        public bool FightActionInitiated
        {
            get { return _fightActionInitiated; }
            set
            {
                _fightActionInitiated = value;
                OnPropertyChanged(nameof(FightActionInitiated));
            }
        }

        public bool ItemsShowing
        {
            get { return _itemsShowing; }
            set
            {
                _itemsShowing = value;
                OnPropertyChanged(nameof(ItemsShowing));
            }
        }

        public bool ItemsInBag
        {
            get { return _itemsInBag; }
            set
            {
                _itemsInBag = value;
                OnPropertyChanged(nameof(ItemsInBag));
            }
        }

        #endregion

        #region Strings

        public string ClassImage
        {
            get { return _classImage; }
            set
            {
                _classImage = value;
                OnPropertyChanged(nameof(ClassImage));
            }
        }

        public string ItemImage
        {
            get { return _itemImage; }
            set
            {
                _itemImage = value;
                OnPropertyChanged(nameof(ItemImage));
            }
        }

        public string MonsterImage
        {
            get { return _monsterImage; }
            set
            {
                _monsterImage = value;
                OnPropertyChanged(nameof(MonsterImage));
            }
        }


        public string MonsterHealth
        {
            get { return _monsterHealth; }
            set
            {
                _monsterHealth = value;
                OnPropertyChanged(nameof(MonsterHealth));
            }
        }

        public string ActionText
        {
            get { return _actionText; }
            set
            {
                _actionText = value;
                OnPropertyChanged(nameof(ActionText));
            }
        }

        public string PlayerHealth
        {
            get { return _playerHealth; }
            set
            {
                _playerHealth = value;
                OnPropertyChanged(nameof(PlayerHealth));
            }
        }

        #endregion

        #region Model Properties

        public Player NewPlayer
        {
            get { return _newPlayer; }
            set
            {
                _newPlayer = value;
                OnPropertyChanged(nameof(NewPlayer));
                NewPlayer.Health = 100;
                PlayerHealth = "Health: " + NewPlayer.Health.ToString();
                ActionText = "Hello " + NewPlayer.Name + " and welcome to Micsto Vs Monsters. " + System.Environment.NewLine +
                    "Your first opponent is: " + Monsters.Select(x => x.Name).First();
                NewPlayer.ListOfItems = new ObservableCollection<Items>(ReadXML(@"Common\Assets\XML\Item\Items.xml", NewPlayer.ListOfItems));
                foreach (var items in NewPlayer.ListOfItems)
                {
                    //  Write the exact path here for your images. Havent figured out how to make this generic
                    ItemImage = @"C:\MyCode\MicstoVsMonsters\MicstoVsMonsters\Common\Assets\Images\Items\" + Regex.Replace(items.Name, @"\s+", "") + ".png";
                    items.ItemImage = ItemImage;
                }
            }
        }

        public Ability PlayerAbility
        {
            get { return _playerAbility; }
            set
            {
                _playerAbility = value;
                OnPropertyChanged(nameof(PlayerAbility));
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
                PlayerAbilitys = SelectedPlayerClass.Abilitys;
            }
        }

        public Monster MonsterCurrentlyFighting
        {
            get { return _monsterCurrentlyFighting; }
            set
            {
                _monsterCurrentlyFighting = value;
                OnPropertyChanged(nameof(MonsterCurrentlyFighting));
            }
        }



        #endregion

        #region List's

        public ObservableCollection<Ability> PlayerAbilitys
        {
            get { return _playerAbilitys; }
            set
            {
                _playerAbilitys = value;
                OnPropertyChanged(nameof(PlayerAbilitys));
            }
        }
        public ObservableCollection<Monster> Monsters
        {
            get { return _monsters; }
            set
            {
                _monsters = value;
                OnPropertyChanged(nameof(Monsters));

            }
        }

        public ObservableCollection<Ability> MonsterAbilitys
        {
            get { return _monsterAbility; }
            set
            {
                _monsterAbility = value;
                OnPropertyChanged(nameof(MonsterAbilitys));

            }
        }
        public List<string> MonsterImages
        {
            get { return _monsterImages; }
            set
            {
                _monsterImages = value;
                OnPropertyChanged(nameof(MonsterImages));
            }
        }


        #endregion

        #region Commands

        public DelegateCommand<Ability> AttackWithAbilityCommand
        {
            get
            {
                return _attackWithAbilityCommand ?? (_attackWithAbilityCommand = new DelegateCommand<Ability>
                {
                    Execute = ability =>
                    {
                        FightActionInitiated = false;
                        MonsterCurrentlyFighting.Health -= ability.Damage;
                        ActionText = "You attacked with " + ability.Name + " doing " + ability.Damage + " damage to the enemy";

                        if (MonsterCurrentlyFighting.Health <= 0)
                        {

                            ActionText = MonsterCurrentlyFighting.Name + " is dead!";
                            GenerateMonster();

                        }
                        else
                        {
                            MonsterAttacksBack();
                        }
                    }

                });
            }
        }

        public DelegateCommand<Items> UseItemCommand
        {
            get
            {
                return _useItemCommand ?? (_useItemCommand = new DelegateCommand<Items>
                {
                    Execute = item =>
                    {
                        ItemsShowing = false;
                        if (item.Damage == 0)
                        {
                            NewPlayer.Health += item.Health;
                            ActionText = item.Name + " just healed you for " + item.Health + " health.";
                            NewPlayer.ListOfItems.Remove(item);

                            if (NewPlayer.ListOfItems.Count == 0)
                            {
                                ItemsInBag = false;
                                ActionText += " And your bag is empty.";
                            }
                        }
                        else
                        {
                            throw new Exception("Implement to add damage to the player");
                        }
                    }

                });
            }
        }

        public DelegateCommand FightActionInitiatedCommand
        {
            get
            {
                return _fightActionInitiatedCommand ?? (_fightActionInitiatedCommand = new DelegateCommand
                {
                    Execute = () =>
                    {
                        FightActionInitiated = true;
                    }

                });
            }
        }

        public DelegateCommand ShowPlayerItems
        {
            get
            {
                return _showPlayerItems ?? (_showPlayerItems = new DelegateCommand
                {
                    Execute = () =>
                    {
                        ItemsShowing = true;
                    }

                });
            }
        }

        #endregion

        #region Methods

        public void FillMonsterAbilitysList()
        {
            var temp = new ObservableCollection<Ability>();
            temp = ReadXML(@"Common\Assets\XML\Monster\DementedMonkAbilitys.xml", temp);
            AddRange(MonsterAbilitys, temp);

            var temp2 = new ObservableCollection<Ability>();
            temp2 = ReadXML(@"Common\Assets\XML\Monster\MadTechnicianAbilitys.xml", temp2);
            AddRange(MonsterAbilitys, temp2);

            var temp3 = new ObservableCollection<Ability>();
            temp3 = ReadXML(@"Common\Assets\XML\Monster\OverprotectiveFatherEarthAbilitys.xml", temp3);
            AddRange(MonsterAbilitys, temp3);

            var temp4 = new ObservableCollection<Ability>();
            temp4 = ReadXML(@"Common\Assets\XML\Monster\SchizofrenicWizzardAbilitys.xml", temp4);
            AddRange(MonsterAbilitys, temp4);

            var temp5 = new ObservableCollection<Ability>();
            temp5 = ReadXML(@"Common\Assets\XML\Monster\SuccubusAbilitys.xml", temp5);
            AddRange(MonsterAbilitys, temp5);
        }

        public void GenerateMonster()
        {

            if (MonsterCurrentlyFighting == null)
            {
                MonsterCurrentlyFighting = new Monster();
                MonsterCurrentlyFighting = Monsters.First();
                MonsterImage = MonsterCurrentlyFighting.MonsterImage;
                MonsterCurrentlyFighting.MonsterAbilitys =
                    new ObservableCollection<Ability>(
                        MonsterAbilitys.Where(x => x.MonsterID == MonsterCurrentlyFighting.ID));
            }

            else
            {
                if (MonsterCurrentlyFighting.ID == 5)
                {
                    Navigate(new FinishedGameViewModel { Navigate = Navigate });
                }
                else
                {
                    int index;
                    if (MonsterCurrentlyFighting.ID == 4)
                    {
                        index = 4;
                        Monsters.Add(new Monster());
                    }
                    else
                        index = MonsterCurrentlyFighting.ID;

                    MonsterCurrentlyFighting = new Monster();
                    MonsterCurrentlyFighting = Monsters[index == -1 ? 0 : index % (Monsters.Count - 1)];
                    MonsterImage = MonsterCurrentlyFighting.MonsterImage;
                    MonsterCurrentlyFighting.MonsterAbilitys = new ObservableCollection<Ability>(MonsterAbilitys.Where(x => x.MonsterID == MonsterCurrentlyFighting.ID));
                    ActionText += " New monster is " + MonsterCurrentlyFighting.Name;

                    if (Monsters.Count > 5)
                        Monsters.RemoveAt(5);
                }

            }


        }

        public void MonsterAttacksBack()
        {
            Shuffle(MonsterCurrentlyFighting.MonsterAbilitys);
            var monsterAttack = MonsterCurrentlyFighting.MonsterAbilitys.First();
            NewPlayer.Health -= monsterAttack.Damage;
            ActionText = MonsterCurrentlyFighting.Name + " attacked you with " + monsterAttack.Name + " doing " +
                         monsterAttack.Damage + " damage.";
            if (NewPlayer.Health <= 0)
            {
                ActionText = "You died, pleb.";
                Navigate(new GameOverViewModel { Navigate = Navigate });
            }
        }


    }

    #endregion
}
