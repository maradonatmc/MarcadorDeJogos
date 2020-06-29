using System.ComponentModel.DataAnnotations;

namespace MarcadorDeJogos.Models
{
    public class ConfigGeneral
    {
        private int _Id;
        [Display(Name = "Código da Configuração do General")]
        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _FlgUtilizaTotal;
        [Display(Name = "Utiliza Total")]
        public int FlgUtilizaTotal {
            get { return _FlgUtilizaTotal; }
            set { _FlgUtilizaTotal = value; }
        }

        private int _FlgJogoSequencial;
        [Display(Name = "Jogo Sequencial")]
        public int FlgJogoSequencial {
            get { return _FlgJogoSequencial; }
            set { _FlgJogoSequencial = value; }
        }

        private int _VlrFula;
        [Display(Name = "Valor da Fula")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int VlrFula {
            get { return _VlrFula; }
            set { _VlrFula = value; }
        }

        private int _VlrFulaMao;
        [Display(Name = "Valor da Fula de mão")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int VlrFulaMao {
            get { return _VlrFulaMao; }
            set { _VlrFulaMao = value; }
        }

        private int _VlrSequencia;
        [Display(Name = "Valor da Sequência")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int VlrSequencia {
            get { return _VlrSequencia; }
            set { _VlrSequencia = value; }
        }

        private int _VlrSequenciaMao;
        [Display(Name = "Valor da Sequência de mão")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int VlrSequenciaMao {
            get { return _VlrSequenciaMao; }
            set { _VlrSequenciaMao = value; }
        }

        private int _VlrQuadra;
        [Display(Name = "Valor da Quadra")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int VlrQuadra {
            get { return _VlrQuadra; }
            set { _VlrQuadra = value; }
        }

        private int _VlrQuadraMao;
        [Display(Name = "Valor da Quadra de mão")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int VlrQuadraMao {
            get { return _VlrQuadraMao; }
            set { _VlrQuadraMao = value; }
        }

        private int _VlrGeneral;
        [Display(Name = "Valor do General")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int VlrGeneral {
            get { return _VlrGeneral; }
            set { _VlrGeneral = value; }
        }

        private int _VlrGeneralMao;
        [Display(Name = "Valor do General de mão")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int VlrGeneralMao {
            get { return _VlrGeneralMao; }
            set { _VlrGeneralMao = value; }
        }

        public ConfigGeneral()
        {

        }
    }
}
