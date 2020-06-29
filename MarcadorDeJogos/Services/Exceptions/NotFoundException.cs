using System;

namespace MarcadorDeJogos.Services.Exceptions {
    public class NotFoundException : ApplicationException {
        public NotFoundException(string message) : base(message) {
        }
    }
}
