using DemoAcmeApp.Domain;
using System.Threading.Tasks;

namespace DemoAcmeApp.Repository
{
    public interface IClienteRepository
    {

        Task<Cliente[]> GetAll();

        Task<Cliente[]> GetByCpf(string cpf);

        Task<Cliente> Create(Cliente cliente);

    }
}
