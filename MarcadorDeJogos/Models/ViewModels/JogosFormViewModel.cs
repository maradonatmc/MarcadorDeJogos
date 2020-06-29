using System.Collections.Generic;

namespace MarcadorDeJogos.Models.ViewModels {
    public class JogosFormViewModel {
        private Jogos _Jogos;
        public Jogos Jogos {
            get { return _Jogos; }
            set { _Jogos = value; }
        }

        private ICollection<TipoJogo> _TipoJogo;
        public ICollection<TipoJogo> TipoJogo {
            get { return _TipoJogo; }
            set { _TipoJogo = value; }
        }
    }
}
