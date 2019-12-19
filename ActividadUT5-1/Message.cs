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
        
        public enum SenderMessage { Bot, Person }
        public SenderMessage SenderType { get; set; }

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
        
        public Message(SenderMessage senderType, string textoMensaje)
        {
            TextoMensaje = textoMensaje;
            SenderType = senderType;
        }

    }
}
