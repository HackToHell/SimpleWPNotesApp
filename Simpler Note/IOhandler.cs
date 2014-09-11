using System;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace Simpler_Note
{
    public class IOHandler
    {
        XmlWriterSettings xmlWriterSettings;

        public IOHandler()
        {
            xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;






        }
        public void adddata()
        {








            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("data3.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Data1>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        List<Data1> a = new List<Data1>();
                        foreach (ItemViewModel b in App.ViewModel.data())
                        {
                            a.Add(new Data1() { LineOne = b.LineOne, LineTwo = b.LineTwo, LineThree = b.LineThree });
                        }
                        serializer.Serialize(xmlWriter, a);
                    }
                }
            }






        }
        public ObservableCollection<ItemViewModel> readdata()
        {

            ObservableCollection<ItemViewModel> j = new ObservableCollection<ItemViewModel>();

            /*  System.Diagnostics.Debug.WriteLine("4");
              while (!s.EndOfStream)
              {
                  System.Diagnostics.Debug.WriteLine(s.ReadLine());
              }
              */










            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("data3.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Data1>));
                        List<Data1> a = (List<Data1>)serializer.Deserialize(stream);
                        foreach (Data1 z in a)
                        {
                            j.Add(new ItemViewModel() { LineOne = z.LineOne, LineTwo = z.LineTwo, LineThree = z.LineThree });
                            System.Diagnostics.Debug.WriteLine(z.LineOne);
                        }

                    }
                }
            }
            catch
            {
                //add some code here
            }



            return j;

        }




    }
}
