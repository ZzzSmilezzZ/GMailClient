using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GmailClient.Layouts;
using GmailClientLibrary;
using System.Windows.Media;

namespace GmailClient.Views
{
    public partial class TestPage : Window
    {
        private TestListOfMessages listOfMessages;
        public MainClient Session { get; private set; }
        private TestPage CurrentPage;
        public TestPage()
        {
            InitializeComponent();
            CurrentPage = this;
        }



        public void ContentChangerToMain()
        {
            listOfMessages.CreateNewMessageButton.Opacity = 100;
            listOfMessages.CreateNewMessageButton.IsEnabled = true;
            listOfMessages.LogOutButton.Opacity = 100;
            listOfMessages.LogOutButton.IsEnabled = true;
            Content = listOfMessages;            
        }

        public void OpenMessage(GmailMessageDTO message)
        {
            Content = new WriteMessagesWindow(message, this);
        }

        public void Logout()
        {
            Session.LogOut();
            Content = new TestLoginWindow(CurrentPage);
        }


        public void GetNewSession()
        {
            Session = new MainClient();
            listOfMessages = new TestListOfMessages(Session, CurrentPage);
            ContentChangerToMain();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (!MainClient.isAuthorized)
                Content = new TestLoginWindow(CurrentPage);
            else
            {
                Content = new WaitingForMessages();
                GetNewSession();
            }

        }
    }
}
