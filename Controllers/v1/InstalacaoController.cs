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
    public class InstalacaoController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInstalacaoRepository _instalacaoRepository;
        private readonly IClienteRepository _clienteRepository;

        public InstalacaoController(IInstalacaoRepository instalacaoRepository, IClienteRepository clienteRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _instalacaoRepository = instalacaoRepository;
            _clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Busca toda a lista de instalações cadastrada.
        /// </summary>
        /// <returns>Lista de instalações.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllInstalacoes() => GenerateDefaultGetActionResult(await _instalacaoRepository.GetAll());

        /// <summary>
        /// Filtra a list de instalações de acordo com CPF de cliente informado.
        /// </summary>
        /// <returns>Instalação referente ao cpf provido.</returns>
        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetInstalacaoByClienteCpf(string cpf) =>
            GenerateDefaultGetActionResult(await _instalacaoRepository.GetByCpfCliente(cpf));

        private IActionResult GenerateDefaultGetActionResult(Instalacao[] instalacoes)
        {
            if (instalacoes.Length == 0)
            {
                return NotFound("Instalação não encontrada.");
            }

            return Ok(instalacoes);
        }

        /// <summary>
        /// Filtra a list de instalações de acordo com o código informado.
        /// </summary>
        /// <returns>Instalação referente ao código provido.</returns>
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetInstalacaoByCodigo(string codigo)
        {
            var instalacoes = await _instalacaoRepository.GetByCodigo(codigo);

            if (instalacoes.Length != 1)
            {
                return NotFound("Instalação não encontrada.");
            }

            return Ok(instalacoes.First());
        }

        /// <summary>
        /// Cadastra uma nova instalação.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Retorna a URL para acessar a instalação cadastrado.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateInstalacao(Instalacao instalacao)
        {
            if (string.IsNullOrEmpty(instalacao.Cliente?.Cpf))
            {
                return BadRequest("Cliente e cpf não informados.");
            }

            var clientes = await _clienteRepository.GetByCpf(instalacao.Cliente.Cpf);

            if (clientes.Length != 1)
            {
                return NotFound($"Cliente com cpf '{instalacao.Cliente.Cpf}' não encontrado.");
            }

            instalacao.IdCliente = clientes.First().Id;
            instalacao.Cliente = null;
            var entity = await _instalacaoRepository.Create(instalacao);
            return Created($"{Utils.Url.BuildUrlFromRequest(_httpContextAccessor.HttpContext.Request)}{entity.Codigo}", entity);
        }
    }
}
