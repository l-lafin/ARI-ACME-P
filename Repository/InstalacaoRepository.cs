using DemoAcmeApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAcmeApp.Repository
{
    public class InstalacaoRepository : IInstalacaoRepository
    {
        private readonly ApiContext _context;

        public InstalacaoRepository(ApiContext context)
        {
            _context = context;
        }

        public Task<Instalacao> Create(Instalacao instalacao) =>
            Task.Run(async () =>
            {
                var entry = await _context.Instalacoes.AddAsync(instalacao);
                await _context.SaveChangesAsync();
                return entry.Entity;
            });

        public Task<Instalacao[]> GetAll()
        {
            var queryable = GetQueryableWithAllIncludes();
            return queryable.ToArrayAsync();
        }

        public Task<Instalacao[]> GetByCodigo(string codigo)
        {
            var queryable = GetQueryableWithAllIncludes();
            return queryable.Where(i => codigo.Equals(i.Codigo)).ToArrayAsync();
        }

        public Task<Instalacao[]> GetByCpfCliente(string cpf)
        {
            var queryable = GetQueryableWithAllIncludes();
            return queryable.Where(i => cpf.Equals(i.Cliente.Cpf)).ToArrayAsync();
        }

        private IQueryable<Instalacao> GetQueryableWithAllIncludes() =>
            _context.Instalacoes.Include(i => i.Endereco)
                .Include(i => i.Faturas)
                .Include(i => i.Cliente)
                .ThenInclude(c => c.Endereco)
                .Include(i => i.Cliente)
                .ThenInclude(c => c.Instalacoes)
                .ThenInclude(i => i.Faturas);
    }
}
