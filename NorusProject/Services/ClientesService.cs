using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorusProject.Models;
using Microsoft.EntityFrameworkCore;

namespace NorusProject.Services {
    public class ClientesService {
        private readonly NorusProjectContext _context;

        public ClientesService(NorusProjectContext context) {
            _context = context;
        }

        public async Task<List<Clientes>> FindAllAsync () {
            return await _context.Clientes.OrderBy(a => a.Nome).ToListAsync();
        }

        public async Task<IList<Clientes>> FindByIdAsync(int id)
        {
            return await _context.Clientes.Where(c => c.Id == id).ToListAsync();
        }
    }
}
