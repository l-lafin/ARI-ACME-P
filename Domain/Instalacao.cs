using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace DemoAcmeApp.Domain
{
    public class Instalacao
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id
        {
            get; set;
        }

        public string Codigo
        {
            get; set;
        }

        public DateTime DataInstalacao
        {
            get; set;
        }

        public long IdCliente
        {
            get; set;
        }

        [ForeignKey("IdCliente")]
        public Cliente Cliente
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

        public List<Fatura> Faturas
        {
            get; set;
        }

        public override string ToString() => $"Instalacao: {JsonSerializer.Serialize(this)}";

    }
}
