using Connection.DataBase;
using Connection.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Vpn;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SidibanUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        DataBaseContext dataBaseContext;

        public ObservableCollection<Card> cards;
        public MainPage()
        {
            dataBaseContext = new DataBaseContext(Path.Combine(ApplicationData.Current.LocalFolder.Path, "users.db"));
            cards = new ObservableCollection<Card>(dataBaseContext.GetCard());

            this.InitializeComponent();

            //Cards_list.ItemsSource = cards;
        }


        //public void initalizeCard()
        //{
        //    CardListView.ItemsSource = cards;
        //}
        private async void back_uwp_Click(object sender, RoutedEventArgs e)
        {
            bool retLauncher = await Launcher.LaunchUriAsync(new Uri("com.sidibanwpf://"));
            if (retLauncher)
                Application.Current.Exit();
        }


        private void Go_to_done_Click(object sender, RoutedEventArgs e)
        {

        }

        private void go_to_doing_Click_1(object sender, RoutedEventArgs e)
        {
            //if(Card.group.Equals(0))
            //{

            //}
        }

        private void DeleteCard_Click(object sender, RoutedEventArgs e)
        {
            //Cards_list.ItemsSource = delete;
            //try
            //{
            //    if (dataBaseContext != null)
            //    {
            //        await dataBaseContext.DeleteCard(DeleteCard);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //}
        }

        private void EditCard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PassCard_For_doing_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
