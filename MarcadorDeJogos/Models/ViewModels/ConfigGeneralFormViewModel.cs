using System.Collections.Generic;

namespace MarcadorDeJogos.Models.ViewModels {
    public class ConfigGeneralFormViewModel {
        private ConfigGeneral _ConfigGeneral;
        public ConfigGeneral ConfigGeneral {
            get { return _ConfigGeneral; }
            set { _ConfigGeneral = value; }
        }
    }
}
