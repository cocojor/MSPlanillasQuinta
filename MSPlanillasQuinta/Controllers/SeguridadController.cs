using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MSEntidades.Seguridad;
using MSRepositorioPlanillasQuinta;

namespace MSPlanillasQuinta.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/seguridad")]
    [ApiController]
    public class SeguridadController : ControllerBase
    {
        private readonly IOperacionesRepositorio OperacionesRepository;

        public SeguridadController(IOperacionesRepositorio operacionesRepository)
        {
            OperacionesRepository = operacionesRepository;
        }

        [HttpPost("login"), MapToApiVersion("1.0")]
        public ActionResult<Token> Login(string credentials)
        {
            try
            {
                Token resultado = OperacionesRepository.Login(credentials);
                if (resultado == null)
                    return Unauthorized();
                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet("usuarios/roles"), MapToApiVersion("1.0")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<RolDTO>> ListarRolesUsuario()
        {
            Request.Headers.TryGetValue("Authorization", out var headervalue);
            string token = headervalue.ToString().Split(" ")[1];
            
            return OperacionesRepository.GetRolesbyToken(token);
        }

        [HttpGet("usuarios/{idusuario}/permisos"), MapToApiVersion("1.0")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<SeguridadMenu>> ListarPermisos (long idusuario, long idrol)
        {
            try
            {
                return OperacionesRepository.ListarMenus(idusuario,idrol);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
