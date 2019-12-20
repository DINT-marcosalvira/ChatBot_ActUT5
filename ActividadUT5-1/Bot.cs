using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public Bot()
        {
            string EndPoint = "https://botactividaddint.azurewebsites.net";
            string Key = "9c1c31bb-5ad4-44c4-b5f9-c36256871454";
            server = new QnAMakerRuntimeClient(new EndpointKeyServiceClientCredentials(Key)) { RuntimeEndpoint = EndPoint };
        }

        public async Task SendQuestion(string question, ObservableCollection<Message> messages)
        {
            string id = "68c6efd8-5210-45dd-b60c-722c64c4f9fc";
            QnASearchResultList response = await server.Runtime.GenerateAnswerAsync(id, new QueryDTO { Question = question });
            string responseString = response.Answers[0].Answer;
            messages.Add(new Message(Message.SenderMessage.Bot, response.Answers[0].Answer));
        }

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
