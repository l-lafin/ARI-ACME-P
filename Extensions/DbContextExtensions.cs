using DemoAcmeApp.Data;
using DemoAcmeApp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DemoAcmeApp.Extensions
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Adiciona o banco de dados em memória ao contexto atual.
        /// </summary>
        public static void AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("Acme-db"));
        }

        /// <summary>
        /// Injeta todos os repositories no contexto atual da aplicação.
        /// </summary>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFaturaRepository, FaturaRepository>();
            services.AddScoped<IInstalacaoRepository, InstalacaoRepository>();
        }

        /// <summary>
        /// Adiciona um grupo de dados de testes para o banco de dados em memória do contexto.
        /// </summary>
        public static void AddTestDataToContext(this IServiceProvider provider)
        {
            var context = provider.GetService<ApiContext>();
            EnderecoData.Populate(context);
            ClienteData.Populate(context);
            InstalacaoData.Populate(context);
            FaturaData.Populate(context);
        }
    }
}
