using System.Collections.Generic;
using System.Threading.Tasks;
using MarcadorDeJogos.Models;
using Microsoft.EntityFrameworkCore;
using MarcadorDeJogos.Services.Exceptions;
using System.Linq;

namespace MarcadorDeJogos.Services {
    public class ConfigGeneralService {
        private readonly MarcadorDeJogosContext _context;

        public ConfigGeneralService(MarcadorDeJogosContext context) {
            _context = context;
        }

        public async Task InsertAsync(ConfigGeneral obj) {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(ConfigGeneral obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<ConfigGeneral> DeleteByIdAsync(int? id)
        {
            ConfigGeneral configGeneral = await _context.ConfigGeneral.FirstOrDefaultAsync(obj => obj.Id == id);

            _context.ConfigGeneral.Remove(configGeneral);

            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<IList<ConfigGeneral>> FindAllAsync()
        {
            return await _context.ConfigGeneral.ToListAsync();
        }

        public async Task<ConfigGeneral> FindByIdAsync(int? id)
        {
            return await _context.ConfigGeneral.FirstOrDefaultAsync(obj => obj.Id == id);
        }
    }
}
