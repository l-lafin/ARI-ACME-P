using System;

namespace DemoAcmeApp.Data
{
    public static class FaturaData
    {
        public static void Populate(ApiContext context)
        {
            context.Faturas.Add(new Domain.Fatura
            {
                Id = 1,
                Codigo = "123abc",
                DataLeitura = new DateTime(2020, 1, 20),
                DataVencimento = new DateTime(2020, 2, 20),
                IdInstalacao = 1,
                NumeroLeitura = 1234446,
                ValorConta = 130
            });
            context.Faturas.Add(new Domain.Fatura
            {
                Id = 2,
                Codigo = "23543fsf",
                DataLeitura = new DateTime(2020, 2, 20),
                DataVencimento = new DateTime(2020, 3, 20),
                IdInstalacao = 1,
                NumeroLeitura = 123456,
                ValorConta = 150
            });
            context.Faturas.Add(new Domain.Fatura
            {
                Id = 3,
                Codigo = "sdfsd2343",
                DataLeitura = new DateTime(2020, 1, 20),
                DataVencimento = new DateTime(2020, 2, 20),
                IdInstalacao = 2,
                NumeroLeitura = 3215234,
                ValorConta = 90
            });
            context.Faturas.Add(new Domain.Fatura
            {
                Id = 4,
                Codigo = "asd5433h",
                DataLeitura = new DateTime(2020, 2, 20),
                DataVencimento = new DateTime(2020, 3, 20),
                IdInstalacao = 2,
                NumeroLeitura = 123456,
                ValorConta = 85
            });
            context.Faturas.Add(new Domain.Fatura
            {
                Id = 5,
                Codigo = "fsfs323432",
                DataLeitura = new DateTime(2020, 1, 20),
                DataVencimento = new DateTime(2020, 2, 20),
                IdInstalacao = 3,
                NumeroLeitura = 2323232,
                ValorConta = 180
            });
            context.Faturas.Add(new Domain.Fatura
            {
                Id = 6,
                Codigo = "fsfs323432",
                DataLeitura = new DateTime(2020, 2, 20),
                DataVencimento = new DateTime(2020, 3, 20),
                IdInstalacao = 3,
                NumeroLeitura = 332133,
                ValorConta = 130
            });
            context.SaveChanges();
        }
    }
}
