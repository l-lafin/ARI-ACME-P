using System;

namespace DemoAcmeApp.Data
{
    public static class ClienteData
    {
        public static void Populate(ApiContext context)
        {
            context.Clientes.Add(new Domain.Cliente
            {
                Id = 1,
                Nome = "Gandalf",
                Cpf = "555.759.55-02",
                DataNascimento = new DateTime(1994, 9, 6),
                IdEndereco = 1
            });
            context.Clientes.Add(new Domain.Cliente
            {
                Id = 2,
                Nome = "Aragorn",
                Cpf = "232.759.55-02",
                DataNascimento = new DateTime(1993, 9, 6),
                IdEndereco = 2
            });
            context.SaveChanges();
        }
    }
}
