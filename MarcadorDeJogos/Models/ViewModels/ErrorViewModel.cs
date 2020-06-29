using System;

namespace MarcadorDeJogos.Models {
    public class ErrorViewModel {
        public string RequestId { get; set; }

        private string _Message;
        public string Message {
            get { return _Message; }
            set { _Message = value; }
        }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}