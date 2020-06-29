using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarcadorDeJogos.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcadorDeJogos.Services
{
    public class TipoJogoService
    {
        private readonly MarcadorDeJogosContext _context;

        public TipoJogoService(MarcadorDeJogosContext context)
        {
            _context = context;
        }

        public async Task<IList<TipoJogo>> FindAllAsync ()
        {
            return await _context.TipoJogo.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<IList<TipoJogo>> FindByIdAsync(int id)
        {
            return await _context.TipoJogo.Where(t => t.Id == id).ToListAsync();
        }
    }
}
