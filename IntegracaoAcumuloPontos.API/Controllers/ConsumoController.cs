using IntegracaoAcumuloPontos.API.Responses;
using IntegracaoAcumuloPontos.Application.DTOs;
using IntegracaoAcumuloPontos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IntegracaoAcumuloPontos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumoController : ControllerBase
    {
        private readonly IConsumoService _consumoService;
        public ConsumoController(IConsumoService consumoService)
        {
            _consumoService = consumoService;
        }

        [HttpPost("computarPontosTempoReal")]
        public async Task<IActionResult> ComputarPontosTempoReal([FromBody] ConsumoDto consumo)
        {
            if (consumo == null)
            {
                return BadRequest(Response<string>.ErrorResponse("parâmentro inválido"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(Response<ModelStateDictionary>.ErrorResponse(ModelState));
            }

            await _consumoService.ComputarPontosTempoReal(consumo);

            return Ok(Response<string>.SuccessResponse("Consumo computado com sucesso"));
        }

        [HttpPost("")]
        public async Task<IActionResult> CriarConsumo([FromBody] ConsumoDto consumo)
        {
            if (consumo == null)
            {
                return BadRequest(Response<string>.ErrorResponse("Parâmentro inválido"));
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(Response<ModelStateDictionary>.ErrorResponse(ModelState));
            }

            await _consumoService.Criar(consumo);

            return Ok(Response<string>.SuccessResponse("Consumo criado com sucesso"));
        }

        [HttpPost("transformacaoPosIngestao")]
        public async Task<IActionResult> transformacaoPosIngestao([FromBody] ICollection<ConsumoDto> consumos)
        {
            if (consumos.Count() == 0)
            {
                return BadRequest(Response<string>.ErrorResponse("Parâmentro inválido"));
            }

            await _consumoService.TransformacaoPosIngestao(consumos);

            return Ok(Response<string>.SuccessResponse("Transformação realizada com sucesso"));
        }
    }
}
