﻿using Connection.DataBase;
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CardStackPanel.Visibility == Visibility.Collapsed)
            {
                CardStackPanel.Visibility = Visibility.Visible;
            }
        }

        private async void add_card_Click(object sender, RoutedEventArgs e)
        {
            //string errors = CardValidation.ValidateCard(TitleCard.Text, DescriptionCard.Text);

            //if ( errors != "")
            //{
            //    ShowError(errors); return;
            //}


            //CardGroup cardGroup = new CardGroup("TODO");


            Card cards = new Card
            {
                Title = TitleCard.Text,
                Description = DescriptionCard.Text,
                group = 0

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

            this.Close();

        }


    }
}