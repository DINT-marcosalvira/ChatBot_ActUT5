using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActividadUT5_1
{
    class Bot : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private readonly QnAMakerRuntimeClient server;
        public async Task<bool> ComprobarConexion()
        {
            string id = "68c6efd8-5210-45dd-b60c-722c64c4f9fc";
            try
            {
                QnASearchResultList response = await server.Runtime.GenerateAnswerAsync(id, new QueryDTO { Question = "Comprobación" });
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
