using System.Collections.Generic;

namespace NorusProject.Models.ViewModels {
    public class ContratosFormViewModel {
        private Contratos _Contratos;
        public Contratos Contratos {
            get { return _Contratos; }
            set { _Contratos = value; }
        }

        private ICollection<Clientes> _Clientes;
        public ICollection<Clientes> Clientes {
            get { return _Clientes; }
            set { _Clientes = value; }
        }

    }
}
