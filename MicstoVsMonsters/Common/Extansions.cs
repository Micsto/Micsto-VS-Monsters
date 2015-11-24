using MicstoVsMonsters.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MicstoVsMonsters.Common
{
    public abstract class Extansions : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }



        public ObservableCollection<T> ToXml<T>(ObservableCollection<T> obj, string path)
        {

            var saveToXmlPath = AppDomain.CurrentDomain.BaseDirectory + path;
            using (StreamWriter stringWriter = new StreamWriter((saveToXmlPath)))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<T>));
                xmlSerializer.Serialize(stringWriter, obj);
                return obj;
            }
        }

        public static void Shuffle<T>(ObservableCollection<T> observableCollection)
        {
            int n = observableCollection.Count;
            Random rnd = new Random();
            while (n > 1)
            {
                int k = (rnd.Next(0, n) % n);
                n--;
                T value = observableCollection[k];
                observableCollection[k] = observableCollection[n];
                observableCollection[n] = value;
            }
        }

        public ObservableCollection<T> ReadXML<T>(string path, ObservableCollection<T> observableCollection)
        {

            var Xmlpath = AppDomain.CurrentDomain.BaseDirectory + path;
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<T>));
            ObservableCollection<T> deserialized;
            using (StreamReader reader = new StreamReader(Xmlpath))
            {
                deserialized = (ObservableCollection<T>)serializer.Deserialize(reader);
            }
            observableCollection = new ObservableCollection<T>(deserialized);
            return observableCollection;
        }

        public static void AddRange<T>(ObservableCollection<T> oc, IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            foreach (var i in collection) oc.Add(i);
        }


        public void DelayedOnPropertyChanged(string name)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync(name);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);

            e.Result = e.Argument;
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnPropertyChanged((string)e.Result);
        }
    }
}
