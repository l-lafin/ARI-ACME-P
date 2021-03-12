using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace DemoAcmeApp.Domain
{
    public class Endereco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        {
            get; set;
        }

        public string Logradouro
        {
            get; set;
        }

        public long Numero
        {
            get; set;
        }

        public string Bairro
        {
            get; set;
        }

        public string Cidade
        {
            get; set;
        }

        public string Uf
        {
            get; set;
        }

        public override string ToString() => $"Endereco: {JsonSerializer.Serialize(this)}";
    }
}
