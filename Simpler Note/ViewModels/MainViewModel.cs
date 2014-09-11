using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Linq;

namespace Simpler_Note
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            


            okdata();
            if (this.Items.Count == 0)
            {
                this.Items.Add(new ItemViewModel() { LineOne = "Sample Note1", LineTwo = "", LineThree = "Accumsan bibendum dictumst eleifend facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat" });
                this.Items.Add(new ItemViewModel() { LineOne = "Sample Note2", LineTwo = "", LineThree = "Pulvinar sagittis senectus sociosqu suscipit torquent ultrices vehicula volutpat maecenas praesent accumsan bibendum" });
            }

            this.IsDataLoaded = true;
        }
        public void addData()
        {
            this.Items.Add(new ItemViewModel() { LineOne = "Sample Note Name", LineTwo = "", LineThree = "Text" });
            
        }
        public void okdata()
        {
         ObservableCollection<ItemViewModel>   Itemsa = App.IoH.readdata();
            foreach(ItemViewModel b in  Itemsa){
                this.Items.Add(b);
            }
        }
        public int noItems()
        {
            return this.Items.Count;
        }
        public ObservableCollection<ItemViewModel> data()
        {
            return Items;
        }
        public void removeItem(int id)
        {
            this.Items.RemoveAt(id);
        }
        


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}