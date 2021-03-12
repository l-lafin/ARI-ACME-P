namespace DemoAcmeApp.Data
{
    public static class EnderecoData
    {

        public static void Populate(ApiContext context)
        {
            context.Enderecos.Add(new Domain.Endereco
            {
                Id = 1,
                Logradouro = "Big hole street",
                Numero = 1234,
                Bairro = "Southest",
                Cidade = "Condado",
                Uf = "Middle earth"
            });
            context.Enderecos.Add(new Domain.Endereco
            {
                Id = 2,
                Logradouro = "Big tree street",
                Numero = 3334,
                Bairro = "Southest",
                Cidade = "Condado",
                Uf = "Middle earth"
            });
            context.Enderecos.Add(new Domain.Endereco
            {
                Id = 3,
                Logradouro = "The giant eye",
                Numero = 666,
                Bairro = "Southest",
                Cidade = "Mordor",
                Uf = "Middle earth"
            });
            context.SaveChanges();
        }
    }

}
