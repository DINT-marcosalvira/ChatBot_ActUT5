using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ActividadUT5_1
{
    /// <summary>
    /// Lógica de interacción para Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();

            ColorFondoComboBox.ItemsSource = typeof(Colors).GetProperties();
            ColorUsuarioComboBox.ItemsSource = typeof(Colors).GetProperties();
            ColorRobotComboBox.ItemsSource = typeof(Colors).GetProperties();
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            string s;

            s = ColorFondoComboBox.SelectedItem.ToString().Split(' ').Last();
            Properties.Settings.Default.BackgroundColor = s;

            s = ColorUsuarioComboBox.SelectedItem.ToString().Split(' ').Last();
            Properties.Settings.Default.MessageUserColor = s;

            s = ColorRobotComboBox.SelectedItem.ToString().Split(' ').Last();
            Properties.Settings.Default.MessageBotColor = s;

            Close();
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
