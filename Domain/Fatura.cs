using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace DemoAcmeApp.Domain
{
    public class Fatura
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

        public int NumeroLeitura
        {
            get; set;
        }

        public double ValorConta
        {
            get; set;
        }

        public DateTime DataVencimento
        {
            get; set;
        }

        public DateTime DataLeitura
        {
            get; set;
        }

        public long IdInstalacao
        {
            get; set;
        }

        [ForeignKey("IdInstalacao")]
        public Instalacao Instalacao
        {
            get; set;
        }

        public override string ToString() => $"Fatura: {JsonSerializer.Serialize(this)}";
    }
}
