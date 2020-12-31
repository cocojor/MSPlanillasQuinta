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
    [Route("api/v{version:apiVersion}/planillas")]
    [ApiController]
    public class PlanillasController : ControllerBase
    {
        private readonly IOperacionesRepositorio OperacionesRepository;

        public PlanillasController(IOperacionesRepositorio operacionesRepository)
        {
            this.OperacionesRepository = operacionesRepository;
        }

        [HttpPost("masivos")]
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

        [HttpPut("planillasquintas")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public ActionResult<PlanillaCabeceraDTO> GuardarTopes(PlanillaCabeceraDTO planilla, string usuario)
        {
            try
            {
                return OperacionesRepository.GuardarPlanillaQuinta(planilla, usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("topes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<TopeTrabajadorDTO>> ObtenerTopes(long idTrabajador, int anho)
        {
            try
            {
                return OperacionesRepository.ObtenerTopes(idTrabajador, anho);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("expedientes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<ExpedienteDTO>> ObtenerExepedientes(long idTrabajador, int anho, int mes)
        {
            try
            {
                return OperacionesRepository.ObtenerExpedientes(idTrabajador, anho, mes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
