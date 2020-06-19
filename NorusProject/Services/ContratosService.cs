using System.Collections.Generic;
using System.Threading.Tasks;
using NorusProject.Models;
using Microsoft.EntityFrameworkCore;
using NorusProject.Services.Exceptions;

namespace NorusProject.Services {
    public class ContratosService {
        private readonly NorusProjectContext _context;

        public ContratosService(NorusProjectContext context) {
            _context = context;
        }

        public async Task<IList<Contratos>> FindAllAsync() {
            return await _context.Contratos.ToListAsync();
        }

        public async Task InsertAsync(Contratos obj) {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Contratos obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Contratos> FindByIdAsync(int? id) {
            return await _context.Contratos.Include(obj => obj.Clientes).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task<Contratos> EditByIdAsync(int? id)
        {
            Contratos contrato = await _context.Contratos.Include(obj => obj.Clientes).FirstOrDefaultAsync(obj => obj.Id == id);

            _context.Update(contrato);

            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Contratos> DeleteByIdAsync(int? id)
        {
            Contratos contrato = await _context.Contratos.FirstOrDefaultAsync(obj => obj.Id == id);

            _context.Contratos.Remove(contrato);

            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<IList<Contratos>> FindByAll(string valor) {
            IList<Contratos> listaContratos = new List<Contratos>();

            Contratos contrato = await FindByNumeroContratoAsync(valor);

            if (contrato == null) {
                contrato = await FindByClienteAsync(valor);
            }

            if (contrato == null) {
                return null;
            }
            
            listaContratos.Add(contrato);

            return listaContratos;
        }
		
        public async Task<Contratos> FindByNumeroContratoAsync(string numeroContrato) {
            return await _context.Contratos.FirstOrDefaultAsync(n => n.NumeroContrato.Contains(numeroContrato));
        }
		
        public async Task <Contratos> FindByClienteAsync(string cliente) {
            return await _context.Contratos.Include(a => a.Clientes).FirstOrDefaultAsync(n => n.Clientes.Nome.Contains(cliente));
        }

        public Contratos UpdateRegistroAtual(Contratos contrato, Contratos contratoAlterado)
        {
            contratoAlterado.NumeroContrato = contrato.NumeroContrato;
            contratoAlterado.TipoContrato = contrato.TipoContrato;
            contratoAlterado.QtdNegociada = contrato.QtdNegociada;
            contratoAlterado.VlrNegociado = contrato.VlrNegociado;
            contratoAlterado.MesAnoInicioContrato = contrato.MesAnoInicioContrato;
            contratoAlterado.DuracaoMesesContrato = contrato.DuracaoMesesContrato;
            contratoAlterado.ClientesId = contrato.ClientesId;

            return contratoAlterado;
        }
    }
}
