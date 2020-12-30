using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSEntidades.PlanillaQuinta;
using MSRepositorioPlanillasQuinta;

namespace MSPlanillasQuinta.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/planillas]")]
    [ApiController]
    public class PlanillasController : ControllerBase
    {
        private readonly IOperacionesRepositorio OperacionesRepository;

        public PlanillasController(IOperacionesRepositorio operacionesRepository)
        {
            this.OperacionesRepository = operacionesRepository;
        }

        [HttpPut("masivos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<RespuestaMasivo> ProcesarMasivo(Archivo archivo)
        {
            try
            {
                return OperacionesRepository.ProcesarMasivo(archivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
