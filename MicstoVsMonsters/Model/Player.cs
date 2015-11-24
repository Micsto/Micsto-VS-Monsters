using MicstoVsMonsters.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MicstoVsMonsters.Model
{
    [Serializable]
    public class Player : Extansions
    {
        private int _id;
        private string _name;
        private int _playerLvL;
        private int _health;
        private PlayerClass _playerClass;
        private ObservableCollection<Items> _listOfItems;

        public Player()
        {
            ListOfItems = new ObservableCollection<Items>();
        }

        [XmlAttribute()]
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        [XmlAttribute()]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        [XmlAttribute()]
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged(nameof(Health));
            }
        }

        [XmlAttribute()]
        public int PlayerLvL
        {
            get { return _playerLvL; }
            set
            {
                _playerLvL = value;
                OnPropertyChanged(nameof(PlayerLvL));
            }
        }

        [XmlAttribute()]
        public PlayerClass PlayersClass
        {
            get { return _playerClass; }
            set
            {
                _playerClass = value;
                OnPropertyChanged(nameof(PlayersClass));
            }
        }

        public ObservableCollection<Items> ListOfItems
        {
            get { return _listOfItems; }
            set
            {
                _listOfItems = value;
                OnPropertyChanged(nameof(ListOfItems));
            }
        }
    }
}
