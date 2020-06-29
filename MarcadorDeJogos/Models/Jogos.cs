using System.ComponentModel.DataAnnotations;

namespace MarcadorDeJogos.Models {
    public class Jogos {
        private int _Id;
        [Display(Name = "Código do Jogo")]
        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _NomeJogo;
        [Display(Name = "Nome do Jogo")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        [StringLength(255, ErrorMessage = "{0} tamanho máximo de 255 caracteres")]
        public string NomeJogo {
            get { return _NomeJogo; }
            set { _NomeJogo = value; }
        }

        public TipoJogo TipoJogo { get; set; }

        private int _TipoJogoId;
        [Display(Name = "Tipo do jogo")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int TipoJogoId {
            get { return _TipoJogoId; }
            set { _TipoJogoId = value; }
        }

        public Jogos() {

        }
		
		public Jogos(string nomeJogo) {
			NomeJogo = nomeJogo;
		}
    }
}
