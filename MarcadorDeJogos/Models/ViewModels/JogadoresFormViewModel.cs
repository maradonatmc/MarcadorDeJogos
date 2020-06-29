using System.Collections.Generic;

namespace MarcadorDeJogos.Models.ViewModels {
    public class JogadoresFormViewModel {
        private Jogadores _Jogadores;
        public Jogadores Jogadores {
            get { return _Jogadores; }
            set { _Jogadores = value; }
        }
    }
}
