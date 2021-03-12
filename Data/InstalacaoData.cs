using System;

namespace DemoAcmeApp.Data
{
    public static class InstalacaoData
    {
        public static void Populate(ApiContext context)
        {
            context.Instalacoes.Add(new Domain.Instalacao
            {
                Id = 1,
                Codigo = "123ab",
                DataInstalacao = new DateTime(2000, 5, 4),
                IdCliente = 1,
                IdEndereco = 1
            });
            context.Instalacoes.Add(new Domain.Instalacao
            {
                Id = 2,
                Codigo = "333cc",
                DataInstalacao = new DateTime(2000, 8, 12),
                IdCliente = 2,
                IdEndereco = 2
            });
            context.Instalacoes.Add(new Domain.Instalacao
            {
                Id = 3,
                Codigo = "4565gh",
                DataInstalacao = new DateTime(2000, 10, 20),
                IdCliente = 2,
                IdEndereco = 3
            });
            context.SaveChanges();
        }
    }
}
