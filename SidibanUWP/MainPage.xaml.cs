using Connection.DataBase;
using Connection.Entities;
using Connection.Enumerates;
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

        public ObservableCollection<Card> todoCardsGroup;
        public ObservableCollection<Card> doingCardsGroup;
        public ObservableCollection<Card> doneCardsGroup;
        public Card lastEditableCard;
        public MainPage()
        {
            dataBaseContext = new DataBaseContext(Path.Combine(ApplicationData.Current.LocalFolder.Path, "users.db"));
            UpdateLists();
            this.InitializeComponent();
            UpdateEmptyTextBlockVisibility();
        }

        private void UpdateEmptyTextBlockVisibility()
        {
            emptyTodoText.Visibility = todoCardsGroup.Count != 0 ? Visibility.Collapsed : Visibility.Visible;
            emptyDoingText.Visibility = doingCardsGroup.Count != 0 ? Visibility.Collapsed : Visibility.Visible;
            emptyDoneText.Visibility = doneCardsGroup.Count != 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void UpdateLists()
        {
            todoCardsGroup = new ObservableCollection<Card>(dataBaseContext.GetCard().Where(card => card.group == Connection.Enumerates.EnumCardGroups.TODO).ToList());
            doingCardsGroup = new ObservableCollection<Card>(dataBaseContext.GetCard().Where(card => card.group == Connection.Enumerates.EnumCardGroups.DOING).ToList());
            doneCardsGroup = new ObservableCollection<Card>(dataBaseContext.GetCard().Where(card => card.group == Connection.Enumerates.EnumCardGroups.DONE).ToList());
            doneCardsGroup = new ObservableCollection<Card>(doneCardsGroup.Reverse().ToList());
            doingCardsGroup = new ObservableCollection<Card>(doingCardsGroup.Reverse().ToList());
            todoCardsGroup = new ObservableCollection<Card>(todoCardsGroup.Reverse().ToList());
        }

        private async void back_uwp_Click(object sender, RoutedEventArgs e)
        {
            bool retLauncher = await Launcher.LaunchUriAsync(new Uri("com.sidibanwpf://"));
            if (retLauncher)
                Application.Current.Exit();
        }
        private void Cards_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            Card selectedCard = listView.SelectedItem as Card;
            selectedCard.Description = string.Empty;
            selectedCard.Title = string.Empty;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Card card = button.DataContext as Card;
            dataBaseContext.DeleteCard(card);
            Frame.Navigate(this.GetType());
        }

        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Card card = button.DataContext as Card;
            dataBaseContext.DeleteCard(card);
            if (card.group == EnumCardGroups.TODO)
            {
                card.group = EnumCardGroups.DOING;
            }
            else
            {
                card.group = EnumCardGroups.DONE;
            }
            dataBaseContext.AddCard(card);
            Frame.Navigate(this.GetType());
        }

        private void CardGroupListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lastEditableCard = (Card)((ListView)sender).SelectedItem;
            editableDescription.Text = lastEditableCard.Description;
            editableTitle.Text = lastEditableCard.Title;
            popupView.Visibility = Visibility.Visible;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            saveButton.IsEnabled = true;
            editableDescription.IsEnabled = true;
            editableTitle.IsEnabled = true;
            ((Button)sender).IsEnabled = false;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(this.GetType());
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Card card = new Card() { Title = editableTitle.Text, Description = editableDescription.Text, group = lastEditableCard.group };
            dataBaseContext.DeleteCard(lastEditableCard);
            dataBaseContext.AddCard(card);
            Frame.Navigate(this.GetType());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var gotoWPF = Launcher.LaunchUriAsync(new Uri("com.sidibanwpf://"));
        }
    }
}
