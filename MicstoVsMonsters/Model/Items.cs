using MicstoVsMonsters.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace MicstoVsMonsters.Model
{
    [Serializable]
    public class Items : Extansions
    {
        private int _id;
        private string _name;
        private int _health;
        private int _damage;
        private string _description;
        private string _itemImage;

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
        public int Damage
        {
            get { return _damage; }
            set
            {
                _damage = value;
                OnPropertyChanged(nameof(Damage));
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

        public string ItemImage
        {
            get { return _itemImage; }
            set
            {
                _itemImage = value;
                OnPropertyChanged(nameof(ItemImage));
            }
        }
    }
}
