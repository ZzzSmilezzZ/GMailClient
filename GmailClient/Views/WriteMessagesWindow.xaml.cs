using System.Windows;
using System.Windows.Controls;
namespace GmailClient.Views
{

    public partial class WriteMessagesWindow : UserControl
    {
        private TestPage CurrentWorkSpace;
        public WriteMessagesWindow(GmailClientLibrary.GmailMessageDTO message, TestPage WorkPage)
        {
            InitializeComponent();
            CurrentWorkSpace = WorkPage;
            BackButton.IsEnabled = true;
            BackButton.Opacity = 100;
            From.Text = message.From;
            Date.Text = message.Date;
            HTMLMessageSpace.NavigateToString("<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>" + message.Message);
        }

        private void BackButtonClick_Click(object sender, RoutedEventArgs e)
        {
            BackButton.IsEnabled = false;
            BackButton.Opacity = 0;
            CurrentWorkSpace.ContentChangerToMain();
        }

        private void WriteNewMessageButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
