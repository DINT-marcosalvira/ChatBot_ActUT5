using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

namespace ActividadUT5_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ObservableCollection<Message> listMessages;
        private Bot botQnM;
        public MainWindow()
        {
            botQnM = new Bot();
            listMessages = new ObservableCollection<Message>();
            listMessages.Clear();
            InitializeComponent();
            ChatItemsControl.DataContext = listMessages;
            MensajeTextBox.Focus();
        }

        private void OpenConfig_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Settings ventanaConf = new Settings();
            ventanaConf.Owner = this;
            ventanaConf.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ventanaConf.Show();
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private async void SendMessage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string pregunta = MensajeTextBox.Text.ToString();
            listMessages.Add(new Message(Message.SenderMessage.Person, pregunta));
            MensajeTextBox.Text = "";

            try
            {
                await botQnM.SendQuestion(pregunta, listMessages);
            }
            catch (Exception)
            {
                listMessages.Add(new Message(Message.SenderMessage.Bot, "Algo va mal..."));
            }
        }

        private void SendMessage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(!MensajeTextBox.Text.Equals(String.Empty))
            {
                e.CanExecute = true;
            }
        }

        private void NewChat_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            listMessages.Clear();
        }

        private void NewChat_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listMessages.Count > 0;
        }
    }
}
