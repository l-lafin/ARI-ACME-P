using DemoAcmeApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAcmeApp.Repository
{
    public class FaturaRepository : IFaturaRepository
    {
        private readonly ApiContext _context;

        public FaturaRepository(ApiContext context)
        {
            _context = context;
        }

        public Task<Fatura> Create(Fatura fatura) =>
            Task.Run(async () =>
            {
                var entry = await _context.Faturas.AddAsync(fatura);
                await _context.SaveChangesAsync();
                return entry.Entity;
            });

        public Task<Fatura[]> GetAll()
        {
            var queryable = GetQueryableWithAllIncludes();
            return queryable.ToArrayAsync();
        }

        public Task<Fatura[]> GetByCodigo(string codigo)
        {
            var queryable = GetQueryableWithAllIncludes();
            return queryable.Where(f => codigo.Equals(f.Codigo)).ToArrayAsync();
        }

        public Task<Fatura[]> GetByCpfCliente(string cpf)
        {
            var queryable = GetQueryableWithAllIncludes();
            return queryable.Where(f => cpf.Equals(f.Instalacao.Cliente.Cpf)).ToArrayAsync();
        }

        private IQueryable<Fatura> GetQueryableWithAllIncludes() =>
            _context.Faturas.Include(f => f.Instalacao)
                .ThenInclude(i => i.Endereco)
                .Include(f => f.Instalacao)
                .ThenInclude(i => i.Cliente)
                .ThenInclude(c => c.Endereco)
                .Include(f => f.Instalacao)
                .ThenInclude(i => i.Faturas);
    }
}
