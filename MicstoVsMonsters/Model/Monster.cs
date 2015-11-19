using MicstoVsMonsters.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace MicstoVsMonsters.Model
{
    [Serializable]
    public class Monster : Extansions
    {
        private int _id;
        private string _name;
        private int _health;
        private ObservableCollection<Ability> _monsterAbilitys;
        private string _monsterImage;

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

        public ObservableCollection<Ability> MonsterAbilitys
        {
            get { return _monsterAbilitys; }
            set
            {
                _monsterAbilitys = value;
                OnPropertyChanged(nameof(MonsterAbilitys));
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

    }
}
