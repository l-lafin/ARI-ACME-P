using DemoAcmeApp.Domain;
using System.Threading.Tasks;

namespace DemoAcmeApp.Repository
{
    public interface IFaturaRepository
    {
        Task<Fatura[]> GetAll();

        Task<Fatura[]> GetByCodigo(string codigo);

        Task<Fatura[]> GetByCpfCliente(string cpf);

        Task<Fatura> Create(Fatura fatura);
    }
}
