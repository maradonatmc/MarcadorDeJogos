using System.Collections.Generic;
using System.Threading.Tasks;
using MarcadorDeJogos.Models;
using Microsoft.EntityFrameworkCore;
using MarcadorDeJogos.Services.Exceptions;
using System.Linq;

namespace MarcadorDeJogos.Services {
    public class JogosService {
        private readonly MarcadorDeJogosContext _context;

        public JogosService(MarcadorDeJogosContext context) {
            _context = context;
        }

        public async Task InsertAsync(Jogos obj) {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Jogos obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Jogos> DeleteByIdAsync(int? id)
        {
            Jogos jogo = await _context.Jogos.FirstOrDefaultAsync(obj => obj.Id == id);

            _context.Jogos.Remove(jogo);

            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<IList<Jogos>> FindAllAsync()
        {
            return await _context.Jogos.Include(obj => obj.TipoJogo).ToListAsync();
        }

        public async Task<Jogos> FindByIdAsync(int? id)
        {
            return await _context.Jogos.Include(obj => obj.TipoJogo).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<IList<Jogos>> FindByNomeJogoAsync(string texto)
        {
            return await _context.Jogos.Include(obj => obj.TipoJogo).Where(c => c.NomeJogo.Contains(texto)).ToListAsync();
        }
    }
}
