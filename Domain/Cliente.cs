using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace DemoAcmeApp.Domain
{
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        {
            get; set;
        }

        public string Nome
        {
            get; set;
        }

        public string Cpf
        {
            get; set;
        }

        public DateTime DataNascimento
        {
            get; set;
        }

        public long IdEndereco
        {
            get; set;
        }

        [ForeignKey("IdEndereco")]
        public Endereco Endereco
        {
            get; set;
        }

        public List<Instalacao> Instalacoes
        {
            get; set;
        }

        public override string ToString() => $"Cliente: {JsonSerializer.Serialize(this)}";
    }
}
