using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Api.ObjectModel;
using Livraria.Api.ObjectModel.Swagger.Examples;
using Livraria.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;

namespace Livraria.Api.Controllers.v1.prv
{
    [Route("v1/private/[controller]")]
    public class AuditoriaController : Controller
    {
        private readonly IAuditoriaRepository _auditoriaRepository;

        public AuditoriaController(IAuditoriaRepository auditoriaRepository)
        {
            _auditoriaRepository = auditoriaRepository;
        }


        [HttpPost]
        [SwaggerRequestExample(typeof(RegistroAuditoria), typeof(RegistroAuditoriaExample))]
        public async Task<IActionResult> Post([FromBody]RegistroAuditoria registroAuditoria)
        {
            if (registroAuditoria != null)
            {
                var retorno = await _auditoriaRepository.InserirRegistroAuditoriaAsync(registroAuditoria);

                return Ok(retorno);
            }
            else
            {
                return BadRequest("Json de entrada não definido no corpo da requisição");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var registrosRepositorio = await _auditoriaRepository.GetRegistrosAuditoriaAsync();

            if (registrosRepositorio != null)
                return Ok(registrosRepositorio);

            return BadRequest("Registros não encontrados");
        }
    }
}