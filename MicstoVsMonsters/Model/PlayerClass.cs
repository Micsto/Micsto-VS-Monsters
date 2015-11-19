using MicstoVsMonsters.Common;
using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace MicstoVsMonsters.Model
{
    [Serializable]
    public class PlayerClass : Extansions
    {
        private int _id;
        private string _name;
        private string _descrition;
        private ObservableCollection<Ability> _abilitys;
        private string _classImage;

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

        public ObservableCollection<Ability> Abilitys
        {
            get { return _abilitys; }
            set
            {
                _abilitys = value;
                OnPropertyChanged(nameof(Abilitys));
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
            get { return _descrition; }
            set
            {
                _descrition = value;
                OnPropertyChanged(nameof(Description));
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
    }
}
