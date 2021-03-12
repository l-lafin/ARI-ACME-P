using DemoAcmeApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAcmeApp.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApiContext _context;

        public ClienteRepository(ApiContext context)
        {
            _context = context;
        }

        public Task<Cliente[]> GetAll()
        {
            var queryable = GetQueryableWithAllIncludes();
            return queryable.ToArrayAsync();
        }

        public Task<Cliente[]> GetByCpf(string cpf)
        {
            var queryable = GetQueryableWithAllIncludes();
            return queryable.Where(c => cpf.Equals(c.Cpf)).ToArrayAsync();
        }

        public Task<Cliente> Create(Cliente cliente) =>
            Task.Run(async () =>
            {
                var entry = await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return entry.Entity;
            });

        private IQueryable<Cliente> GetQueryableWithAllIncludes() =>
            _context.Clientes.Include(c => c.Endereco)
                .Include(c => c.Instalacoes)
                .ThenInclude(i => i.Faturas)
                .Include(c => c.Instalacoes)
                .ThenInclude(i => i.Endereco);
    }
}
