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
    [Route("api/v{version:apiVersion}/archivos")]
    [ApiController]
    public class ArchivosController : ControllerBase
    {
        private readonly IOperacionesRepositorio OperacionesRepository;

        public ArchivosController(IOperacionesRepositorio operacionesRepository)
        {
            this.OperacionesRepository = operacionesRepository;
        }

        [HttpPost("personal")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Archivo> CargarBasePersonal(Archivo archivo, string usuario)
        {
            try
            {
                return OperacionesRepository.CargarBasePersonal(archivo, usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost("dependencias")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Archivo> CargarDependencias(Archivo archivo, string usuario)
        {
            try
            {
                return OperacionesRepository.CargarDependencias(archivo, usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost("imps")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<Archivo> CargarIMP(Archivo archivo, string usuario)
        {
            try
            {
                return OperacionesRepository.CargarIMP(archivo, usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
