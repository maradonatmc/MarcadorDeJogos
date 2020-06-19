using NorusProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorusProject.Data {
    public class SeedingService {
        private NorusProjectContext _context;

        public SeedingService(NorusProjectContext context) {
            _context = context;
        }

        public void Seed() {
            if (_context.Clientes.Any()) {
                return;
            }

            Clientes c1 = new Clientes("Ana Paula Sagaz da Luz");
            Clientes c2 = new Clientes("Renato Ramos e Ramos");
            Clientes c3 = new Clientes("Victor Alexandre da Luz Cordeiro");
            Clientes c4 = new Clientes("Esteban Miguel da Luz Ramos");
            Clientes c5 = new Clientes("Lucas Renan da Luz Ramos");

            _context.Clientes.AddRange(c1, c2, c3, c4, c5);

            _context.SaveChanges();
        }
    }
}
