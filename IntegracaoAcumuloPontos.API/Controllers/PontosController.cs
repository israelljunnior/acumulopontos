using IntegracaoAcumuloPontos.API.Responses;
using IntegracaoAcumuloPontos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IntegracaoAcumuloPontos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PontosController : ControllerBase
    {
        private readonly IPontosService _pontosService;
        public PontosController(IPontosService pontosService)
        {
            _pontosService = pontosService;    
        }

        [HttpGet("obterPontuacaoAtual")]
        public async Task<IActionResult> obterPontuacaoAtual(int idPessoa)
        {
            if (idPessoa == 0)
            {
                return BadRequest(Response<string>.ErrorResponse("Parâmentro Inválido."));
            }
            var valor = await _pontosService.ObterPontuacaoAtual(idPessoa);

            return Ok(Response<int?>.SuccessResponse(valor));
        }
    }
}
