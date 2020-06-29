using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcadorDeJogos.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcadorDeJogos.Services {
    public class JogadoresService {
        private readonly MarcadorDeJogosContext _context;

        public JogadoresService(MarcadorDeJogosContext context) {
            _context = context;
        }

        public async Task InsertAsync(Jogadores obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Jogadores obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Jogadores> DeleteByIdAsync(int id)
        {
            Jogadores jogador = await _context.Jogadores.FirstOrDefaultAsync(obj => obj.Id == id);

            _context.Jogadores.Remove(jogador);

            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<IList<Jogadores>> FindAllAsync()
        {
            return await _context.Jogadores.OrderBy(a => a.Nome).ToListAsync();
        }

        public async Task<Jogadores> FindByIdAsync(int id)
        {
            return await _context.Jogadores.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Jogadores>> FindByNomeAsync(string texto)
        {
            return await _context.Jogadores.Where(c => c.Nome.Contains(texto)).ToListAsync();
        }
    }
}
