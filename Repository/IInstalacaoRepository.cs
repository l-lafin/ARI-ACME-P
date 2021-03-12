using DemoAcmeApp.Domain;
using System.Threading.Tasks;

namespace DemoAcmeApp.Repository
{
    public interface IInstalacaoRepository
    {
        Task<Instalacao[]> GetAll();

        Task<Instalacao[]> GetByCodigo(string codigo);

        Task<Instalacao[]> GetByCpfCliente(string cpf);

        Task<Instalacao> Create(Instalacao instalacao);
    }
}
