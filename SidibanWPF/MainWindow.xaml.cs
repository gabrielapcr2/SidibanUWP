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
            Card cards = new Card
            {
                Title = TitleCard.Text,
                Description = DescriptionCard.Text,
                group = EnumCardGroups.TODO

            };
            Cards_moviment.Add(cards);
            try
            {
                if (dataBaseContext != null)
                {
                    await dataBaseContext.AddCard(cards);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            Process gotoUWP = Process.Start("com.sidibanuwp://");

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process gotoUWP = Process.Start("com.sidibanuwp://");
        }
    }
}
