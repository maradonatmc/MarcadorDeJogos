using System;
using System.ComponentModel.DataAnnotations;

namespace MarcadorDeJogos.Models {
    public class Jogadores {
        private int _Id;
        [Display(Name = "Código do Jogador")]
        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Nome;
        [Display(Name = "Nome do Jogador")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        [StringLength(255, ErrorMessage = "{0} tamanho máximo de 255 caracteres")]
        public string Nome {
            get { return _Nome; }
            set { _Nome = value; }
        }
		
		private DateTime? _DatCadastro;
        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public DateTime? DatCadastro {
			get { return _DatCadastro; }
			set { _DatCadastro = value; }
		}
		
        public Jogadores() {

        }

        public Jogadores(string nome) {
            Nome = nome;
        }
    }
}
