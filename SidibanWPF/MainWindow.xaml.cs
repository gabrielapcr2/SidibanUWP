using Connection.DataBase;
using Connection.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Connection.Enumerates;
using System.ComponentModel;
using Connection.Commons;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Connection.Validation;

namespace SidibanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataBaseContext dataBaseContext;

        public ObservableCollection<Card> Cards_moviment;
        public MainWindow()
        {
            InitializeComponent();
            dataBaseContext = new DataBaseContext(@"C:\Users\Public\Downloads\user.db");
            Cards_moviment = new ObservableCollection<Card>();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Card newCard = new Card
            {
                Title = TitleCard.Text,
                Description = DescriptionCard.Text,
                group = EnumCardGroups.TODO

            };

            bool cardAlreadyExist = dataBaseContext.GetCard().Where(card => card.Title == newCard.Title).Count() > 0;

            if (newCard.Title.Trim() == String.Empty || newCard.Description.Trim() == String.Empty || cardAlreadyExist)
            {
                string messageBoxText = "You need to put a valid title and description!";
                string caption = "Could not save";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                return;
            }
            Cards_moviment.Add(newCard);
            try
            {
                if (dataBaseContext != null)
                {
                    await dataBaseContext.AddCard(newCard);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            Process gotoUWP = Process.Start("com.sidibanuwp://");
            this.Hide();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process gotoUWP = Process.Start("com.sidibanuwp://");
            this.Hide();
        }
    }
}
