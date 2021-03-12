using DemoAcmeApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoAcmeApp
{
    public class ApiContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Instalacao> Instalacoes { get; set; }

        public DbSet<Fatura> Faturas { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
    }
}
