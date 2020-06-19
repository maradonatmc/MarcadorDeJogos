using System.ComponentModel.DataAnnotations;

namespace NorusProject.Models {
    public class Contratos {
        private int _Id;
        [Display(Name = "Código do Contrato")]
        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _NumeroContrato;
        [Display(Name = "Número do Contrato")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        [StringLength(255, ErrorMessage = "{0} tamanho máximo de 255 caracteres")]
        public string NumeroContrato {
            get { return _NumeroContrato; }
            set { _NumeroContrato = value; }
        }

        private string _TipoContrato;
        [Display(Name = "Tipo de Contrato")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        [StringLength(255, ErrorMessage = "{0} tamanho máximo de 255 caracteres")]
        public string TipoContrato {
            get { return _TipoContrato; }
            set { _TipoContrato = value; }
        }

        private decimal? _QtdNegociada;
        [Display(Name = "Quantidade negociada")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
		public decimal? QtdNegociada {
			get { return _QtdNegociada; }
			set { _QtdNegociada = value; }
		}
		
		private decimal? _VlrNegociado;
		[Display(Name = "Valor negociado")]
        [DataType(DataType.Currency, ErrorMessage = "{0} formato inválido")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
		public decimal? VlrNegociado {
			get { return _VlrNegociado; }
			set { _VlrNegociado = value; }
		}
		
		private string _MesAnoInicioContrato;
        [Display(Name = "Mês/Ano do início do Contrato")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public string MesAnoInicioContrato {
            get { return _MesAnoInicioContrato; }
            set { _MesAnoInicioContrato = value; }
        }
		
		private string _DuracaoMesesContrato;
        [Display(Name = "Duração em meses do Contrato")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public string DuracaoMesesContrato {
            get { return _DuracaoMesesContrato; }
            set { _DuracaoMesesContrato = value; }
        }

        private byte[] _PathArquivo;
        [Display(Name = "Arquivo do Contrato")]
        public byte[] PathArquivo {
            get { return _PathArquivo; }
            set { _PathArquivo = value; }
        }

        public Clientes Clientes { get; set; }

        private int _ClientesId;
        [Display(Name = "Nome do cliente")]
        [Required(ErrorMessage = "{0} é campo obrigatório")]
        public int ClientesId {
            get { return _ClientesId; }
            set { _ClientesId = value; }
        }

        public Contratos() {

        }
    }
}
