using DemoAcmeApp.Domain;
using DemoAcmeApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAcmeApp.Controllers.v1
{
    [Route("/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        /// <summary>
        /// Busca toda a lista de clientes cadastrados.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clientes = await _repository.GetAll();

            if (clientes.Length == 0)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(clientes);
        }

        /// <summary>
        /// Filtra a lista de clientes pelo CPF informado.
        /// </summary>
        /// <returns>Cadastro do cliente para o respectivo respectivo CPF.</returns>
        [HttpGet("{cpf}")]
        public async Task<IActionResult> GetClienteByCpf(string cpf)
        {
            var clientes = await _repository.GetByCpf(cpf);

            if (clientes.Length != 1)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(clientes.First());
        }

        /// <summary>
        /// Cadastra um novo cliente na base de dados.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Retorna a URL para acessar o cliente cadastrado.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCliente(Cliente cliente)
        {
            var entity = await _repository.Create(cliente);
            return Created($"{Utils.Url.BuildUrlFromRequest(_httpContextAccessor.HttpContext.Request)}{entity.Cpf}", entity);
        }
    }
}
