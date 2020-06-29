using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarcadorDeJogos.Models
{
    public class TipoJogo
    {
        private int _Id;
        [Display(Name = "Código do Tipo de Jogo")]
        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _NomeTipoJogo;
        [Display(Name = "Nome do Tipo de Jogo")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        [StringLength(255, ErrorMessage = "{0} tamanho máximo de 255 caracteres")]
        public string NomeTipoJogo {
            get { return _NomeTipoJogo; }
            set { _NomeTipoJogo = value; }
        }

        public ICollection<Jogos> Jogos { get; set; } = new List<Jogos>();

        public TipoJogo()
        {

        }

        public TipoJogo(string nomeTipoJogo)
        {
            NomeTipoJogo = nomeTipoJogo;
        }            
    }
}