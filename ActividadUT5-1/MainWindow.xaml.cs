using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        bool isCheckingConnection = false;
        bool isThinking = false;
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
            isThinking = true;
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
            isThinking = false;
        }

        private void SendMessage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if(!MensajeTextBox.Text.Equals(String.Empty) && !isThinking)
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

        private async void CheckConnection_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            isCheckingConnection = true;

            bool check = await botQnM.ComprobarConexion();

            string cadenaConexión;
            MessageBoxImage m;
            if (check)
            {
                cadenaConexión = "Conexión exitosa";
                m = MessageBoxImage.Asterisk;
            }
            else
            {
                cadenaConexión = "ERROR: Sin conexión";
                m = MessageBoxImage.Error;
            }
            MessageBox.Show(cadenaConexión, "Test de conexión", MessageBoxButton.OK, m, MessageBoxResult.OK);
            isCheckingConnection = false;
        }

        private void CheckConnection_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isCheckingConnection;
        }

        private void SaveChat_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialogo = new Microsoft.Win32.SaveFileDialog();
            dialogo.DefaultExt = ".txt";
            dialogo.Title = "Guardar como: ";
            dialogo.FileName = $"ChatBot_" + DateTime.Today.ToShortDateString();
            dialogo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dialogo.ShowDialog(); 

            StreamWriter sw = new StreamWriter(dialogo.FileName, true);
            foreach (Message message in listMessages)
            {
                sw.WriteLine(message.ToString());
            }
            
        }

        private void SaveChat_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = listMessages.Count > 0;
        }
    }
}
