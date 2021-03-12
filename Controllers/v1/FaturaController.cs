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
    public class FaturaController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFaturaRepository _faturaRepository;
        private readonly IInstalacaoRepository _instalacaoRepository;

        public FaturaController(IFaturaRepository faturaRepository, IInstalacaoRepository instalacaoRepository, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _faturaRepository = faturaRepository;
            _instalacaoRepository = instalacaoRepository;
        }

        /// <summary>
        /// Busca toda a lista de faturas cadastrada.
        /// </summary>
        /// <returns>Lista de todas as faturas cadastradas.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllFaturas() => GenerateDefaultGetActionResult(await _faturaRepository.GetAll());

        /// <summary>
        /// Filtra a lista de faturas de acordo com CPF de cliente informado.
        /// </summary>
        /// <returns>Faturas referentes ao cpf provido.</returns>
        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetFaturasByClienteCpf(string cpf) =>
            GenerateDefaultGetActionResult(await _faturaRepository.GetByCpfCliente(cpf));

        private IActionResult GenerateDefaultGetActionResult(Fatura[] faturas)
        {
            if (faturas.Length == 0)
            {
                return NotFound("Fatura não encontrada.");
            }

            return Ok(faturas);
        }

        /// <summary>
        /// Filtra a lista de faturas de acordo com o código informado.
        /// </summary>
        /// <returns>Fatura referente ao código provido.</returns>
        [HttpGet("{codigo}")]
        public async Task<IActionResult> GetFaturaByCodigo(string codigo)
        {
            var faturas = await _faturaRepository.GetByCodigo(codigo);

            if (faturas.Length != 1)
            {
                return NotFound("Fatura não encontrada.");
            }

            return Ok(faturas.First());
        }

        /// <summary>
        /// Cadastra uma nova fatura para a instalação.
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns>Retorna a URL para acessar a fatura cadastrada.</returns>
        [HttpPost]
        public async Task<IActionResult> GerarFatura(Fatura fatura)
        {
            if (string.IsNullOrEmpty(fatura.Instalacao?.Codigo))
            {
                return BadRequest("Instalação não informada.");
            }

            var instalacao = await _instalacaoRepository.GetByCodigo(fatura.Instalacao.Codigo);

            if (instalacao.Length != 1)
            {
                return NotFound($"Instalação de código '{fatura.Instalacao.Codigo}' não encontrada.");
            }

            fatura.IdInstalacao = instalacao.First().Id;
            fatura.Instalacao = null;
            var entity = await _faturaRepository.Create(fatura);
            return Created($"{Utils.Url.BuildUrlFromRequest(_httpContextAccessor.HttpContext.Request)}{entity.Codigo}", entity);
        }
    }
}
