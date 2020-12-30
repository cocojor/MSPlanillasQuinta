using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSEntidades.Commons;
using MSRepositorioPlanillasQuinta;

namespace MSPlanillasQuinta.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/complementos")]
    [ApiController]
    public class ComplementosController : ControllerBase
    {
        private readonly IOperacionesRepositorio OperacionesRepository;

        public ComplementosController(IOperacionesRepositorio operacionesRepository)
        {
            this.OperacionesRepository = operacionesRepository;
        }

        [HttpGet("planillas"), MapToApiVersion("1.0")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<PlanillaDTO>> ListarPlanillas()
        {
            try
            {
                Request.Headers.TryGetValue("Authorization", out var headervalue);
                string token = headervalue.ToString().Split(" ")[1];

                return OperacionesRepository.GetPlanillasbyToken(token);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("dependencias"), MapToApiVersion("1.0")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<DependenciaDTO>> ListarDependencias()
        {
            try
            {
                return OperacionesRepository.GetDependencias();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("estados"), MapToApiVersion("1.0")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<EstadoDTO>> ListarEstados()
        {
            try
            {
                return OperacionesRepository.GetEstados();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
