using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GmailClient.Layouts;
using GmailClientLibrary;

namespace GmailClient.Views
{
    public partial class TestListOfMessages : UserControl
    {
        private TestPage CurrentWorkSpace;
        private MessageLayout ChosenMessage;
        private List<GmailMessageDTO> listOfCachedMessages;
        private MainClient Session;
        public TestListOfMessages(MainClient session, TestPage currentWorkSpace)
        {
            InitializeComponent();
            CurrentWorkSpace = currentWorkSpace;
            Session = session;
            listOfCachedMessages = session.GetCachedMessages();
            var listOfMessages = session.GetMyMails(true);
            foreach (var message in listOfMessages)
            {
                if (listOfCachedMessages != null)
                {
                    if (message.Id == listOfCachedMessages[0].Id)
                        break;
                    else
                        MessagesPanel.Children.Add(new MessageLayout(message));
                }
                else
                    MessagesPanel.Children.Add(new MessageLayout(message));
            }
            if (listOfCachedMessages != null)
                foreach (var message in listOfCachedMessages)
                    MessagesPanel.Children.Add(new MessageLayout(message));
        }


        private void MessagesPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((e.OriginalSource as Image) != null)
            {
                if ((e.OriginalSource as Image).Name == "OnMessageDeleteButton")
                {
                    var message = e.Source as MessageLayout;
                    MessagesPanel.Children.Remove(message);
                    CurrentWorkSpace.Session.DeleteMessage(message.message.Id);
                    listOfCachedMessages.Remove(message.message);
                }
            }
            else
            {
                ChoseMessage((MessageLayout)e.Source);
                if (e.ClickCount == 2)
                {
                    CreateNewMessageButton.IsEnabled = false;
                    CreateNewMessageButton.Opacity = 0;
                    LogOutButton.IsEnabled = false;
                    LogOutButton.Opacity = 0;
                    CurrentWorkSpace.OpenMessage(ChosenMessage.message);
                }


            }
        }

        private void MessagesPanel_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var contextMenu = FindResource("cmButton") as ContextMenu;
            contextMenu.IsOpen = true;
            var deleteMessageLine = contextMenu.Items[0] as MenuItem;
            ChoseMessage(e.Source as MessageLayout);
        }

        private void DeleteMessageLine_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem; ;
            var contextMenu = menuItem.Parent as ContextMenu;
            MessagesPanel.Children.Remove(ChosenMessage);
            CurrentWorkSpace.Session.DeleteMessage(ChosenMessage.message.Id);
            listOfCachedMessages.Remove(ChosenMessage.message);
            ChosenMessage = null;
        }

        private void ChoseMessage(MessageLayout chosenMessage)
        {
            if (ChosenMessage != null)
                ChosenMessage.MessageBorder.Background = Brushes.White;
            ChosenMessage = chosenMessage;
            ChosenMessage.MessageBorder.Background = Brushes.Salmon;
        }

        private void LogoutButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateNewMessageButton.IsEnabled = false;
            CreateNewMessageButton.Opacity = 0;
            LogOutButton.IsEnabled = false;
            LogOutButton.Opacity = 0;
            Session.LogOut();
            CurrentWorkSpace.Content = new TestLoginWindow(CurrentWorkSpace);
        }

        private void WriteNewMessageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var newWriteWindow = new NewMessageWindow(Session);
            newWriteWindow.Show();
        }

        private void CreateNewMessageButton_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            OnMouseEnterLeaveButton(button, true);
        }

        private void OnMouseEnterLeaveButton(Button button, bool isEnter)
        {

            //if (isEnter)
            //{
            //    button.Margin.Right. = 6.0;
            //}
            //else
            //{

            //}
        }
    }
}
