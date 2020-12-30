using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSEntidades.Commons;
using MSEntidades.PlanillaQuinta;
using MSRepositorioPlanillasQuinta;

namespace MSPlanillasQuinta.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/personal")]
    [ApiController]
    public class PersonalController : ControllerBase
    {
        private readonly IOperacionesRepositorio OperacionesRepository;

        public PersonalController(IOperacionesRepositorio operacionesRepository)
        {
            this.OperacionesRepository = operacionesRepository;
        }

        [HttpGet("trabajadores"), MapToApiVersion("1.0")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<CollectionsResponse<TrabajadorDTO>> Listar(string filtro = "", short estado = 1, short pagina = 0, short regxpag = 10)
        {
            try
            {
                return OperacionesRepository.GetTrabajadores(filtro,estado, pagina,regxpag);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("{idTrabajador}"), MapToApiVersion("1.0")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<TrabajadorDTO> obtenerTrabajador(long idTrabajador)
        {
            try
            {
                return OperacionesRepository.GetTrabajador(idTrabajador);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
