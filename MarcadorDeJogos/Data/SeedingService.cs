using MarcadorDeJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarcadorDeJogos.Data {
    public class SeedingService {
        private readonly MarcadorDeJogosContext _context;

        public SeedingService(MarcadorDeJogosContext context) {
            _context = context;
        }

        public void Seed() {

            if (_context.TipoJogo.Any())
            {
                return;
            }

            TipoJogo tipo1 = new TipoJogo("Canastra");
            TipoJogo tipo2 = new TipoJogo("General");
            TipoJogo tipo3 = new TipoJogo("Truco");

            _context.TipoJogo.AddRange(tipo1, tipo2, tipo3);

            _context.SaveChanges();
        }
    }
}
