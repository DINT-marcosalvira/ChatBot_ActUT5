using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadUT5_1
{
    class Message : INotifyPropertyChanged
    {
        public static string User;
        public static string Bot;
        public static string SenderMessage = User;


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string _textoMensaje;
        public string TextoMensaje
        {
            get
            {
                return _textoMensaje;
            }
            set
            {
                if (this._textoMensaje != value)
                {
                    this._textoMensaje = value;
                    this.NotifyPropertyChanged("TextoMensaje");
                }
            }
        }
        


    }
}
