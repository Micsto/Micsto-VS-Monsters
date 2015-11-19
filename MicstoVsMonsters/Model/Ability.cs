using MicstoVsMonsters.Common;
using System;
using System.Windows.Media;
using System.Xml.Serialization;

namespace MicstoVsMonsters.Model
{
    [Serializable]
    public class Ability : Extansions
    {

        private int _id;
        private string _name;
        private string _description;
        private int _damage;
        private ImageSource _abilityImage;
        private int _abilityLvL;
        private PlayerClass _playerClass;
        private Monster _monster;
        private int _monsterID;
        private int _playerClassID;

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
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        [XmlAttribute()]
        public int Damage
        {
            get { return _damage; }
            set
            {
                _damage = value;
                OnPropertyChanged(nameof(Damage));
            }
        }

        public ImageSource AbilityImage
        {
            get { return _abilityImage; }
            set
            {
                _abilityImage = value;
                OnPropertyChanged(nameof(AbilityImage));
            }
        }

        [XmlAttribute()]
        public int AbilityLvL
        {
            get { return _abilityLvL; }
            set
            {
                _abilityLvL = value;
                OnPropertyChanged(nameof(AbilityLvL));
            }
        }

        public PlayerClass PlayerClass
        {
            get { return _playerClass; }
            set
            {
                _playerClass = value;
                OnPropertyChanged(nameof(PlayerClass));
            }
        }

        [XmlAttribute()]
        public int PlayerClassID
        {
            get { return _playerClassID; }
            set
            {
                _playerClassID = value;
                OnPropertyChanged(nameof(PlayerClassID));
            }
        }

        public Monster MonsterClass
        {
            get { return _monster; }
            set
            {
                _monster = value;
                OnPropertyChanged(nameof(MonsterClass));
            }
        }

        [XmlAttribute()]
        public int MonsterID
        {
            get { return _monsterID; }
            set
            {
                _monsterID = value;
                OnPropertyChanged(nameof(MonsterID));
            }
        }
    }
}