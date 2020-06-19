using System.Collections.Generic;

namespace NorusProject.Models {
    public class Clientes {
        private int _Id;
        public int Id {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Nome;
        public string Nome {
            get { return _Nome; }
            set { _Nome = value; }
        }

        public ICollection<Contratos> Contratos { get; set; } = new List<Contratos>();

        public Clientes() {

        }

        public Clientes(string nome) {
            Nome = nome;
        }
    }
}
