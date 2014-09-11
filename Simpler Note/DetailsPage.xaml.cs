using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Simpler_Note
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructor
        int index;
        public DetailsPage()
        {
            InitializeComponent();
            index = 0;
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                 index = int.Parse(selectedIndex);
                DataContext = App.ViewModel.Items[index];
            }
            
        }



        private void Edit_Click_1(object sender, EventArgs e)
        {
            ListTitle.Visibility = Visibility.Collapsed;
            ContentText.Visibility = Visibility.Collapsed;
            ListTitleEditable.Text = ContentText.Text;
            ContentTextEditable.Text = ListTitle.Text;
            ContentTextEditable.Visibility = Visibility.Visible;
            ListTitleEditable.Visibility = Visibility.Visible;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (ListTitle.Visibility == Visibility.Visible)
            {
                if (this.NavigationService.CanGoBack)
                    this.NavigationService.GoBack();
            }
            else
            {
                ListTitle.Visibility = Visibility.Visible;
                ContentText.Visibility = Visibility.Visible;
                ListTitleEditable.Visibility = Visibility.Collapsed;
                ContentTextEditable.Visibility = Visibility.Collapsed;

            }

        }

        private void ContentTextEditable_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ContentText.Text = ListTitleEditable.Text;
                ListTitle.Text = ContentTextEditable.Text;
                ListTitle.Visibility = Visibility.Visible;
                ContentText.Visibility = Visibility.Visible;
                ContentTextEditable.Visibility = Visibility.Collapsed;
                ListTitleEditable.Visibility = Visibility.Collapsed;
                
            }
        }

        private void ListTitleEditable_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ContentText.Text = ListTitleEditable.Text;
                ListTitle.Text = ContentTextEditable.Text;
                ListTitle.Visibility = Visibility.Visible;
                ContentText.Visibility = Visibility.Visible;
                ContentTextEditable.Visibility = Visibility.Collapsed;
                ListTitleEditable.Visibility = Visibility.Collapsed;
                
            }
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            App.ViewModel.removeItem(index);
            if (this.NavigationService.CanGoBack)
                this.NavigationService.GoBack();
            else
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}