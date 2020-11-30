using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MSEntidades.Seguridad;
using MSRepositorioPlanillasQuinta.Modelo;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using static MSEntidades.Constantes.Constantes;
using static MSEntidades.Constantes.SeguridadConstantes;

namespace MSRepositorioPlanillasQuinta
{
    public class OperacionesRepositorio: BaseRepository, IOperacionesRepositorio
    {
        private readonly IConfiguration _configuration;

        public OperacionesRepositorio(DBPlanillasContext ctx,
                                      IConfiguration configuration): base(ctx) 
        {
            this._configuration = configuration;
        }
        private Token BuilToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Usuario1),
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Idusuario.ToString())
            };

            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TOKEN.KEY));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["KEY"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "planillas.com",
                audience: "planillas.com",
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new Token()
            {
                accessToken = new JwtSecurityTokenHandler().WriteToken(token),
                expiresIn = expiration.Ticks
            };
        }
        private JwtSecurityToken decodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            return jsonToken as JwtSecurityToken;
        }
        public List<SeguridadMenu> ListarMenus(long idusuario, long idrol)
        {
            try
            {
                List<Permiso> permisos = ctx.Permiso.FromSql("EXECUTE spGetPermisos @p0, @p1, @p2", 0, idusuario, idrol).ToList();
                return GenerarMenuPermisos(permisos, 0);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private List<SeguridadMenu> GenerarMenuPermisos(List<Permiso> permisos, long idPadre)
        {
            List<SeguridadMenu> Menu = permisos.Where(p => p.Idpadre == idPadre).
                                        Select(p => new SeguridadMenu()
                                        {
                                            idPermiso = p.Idpermiso,
                                            idParent = p.Idpadre,
                                            descripcion = p.Descripcion,
                                            icoMenu = p.Iconmenu,
                                            nivel = p.Nivel,
                                            ruta = p.Ruta,
                                            Submenu = p.Submenu,
                                            hijos = GenerarMenuPermisos(permisos, p.Idpermiso)
                                        }).ToList();
            return Menu;
        }

        public Token Login(string credentials)
        {
            try
            {
                byte[] data = Convert.FromBase64String(credentials);
                string credenciales = ASCIIEncoding.ASCII.GetString(data);
                string[] cred = { };
                cred = credenciales.Split(":");
                UsuarioDto userDto = new UsuarioDto
                {
                    Usuario1 = cred[0],
                    Clave = cred[1],
                };
                Usuario user = ctx.Usuario
                                    .Where(u => u.Usuario1 == userDto.Usuario1
                                                && u.Clave == userDto.Clave)
                                    .FirstOrDefault();
                if (user != null)
                {
                    return BuilToken(user);
                }
                return null;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<RolDTO> GetRolesbyToken(string token)
        {
            try
            {
                long id = Int64.Parse(decodeToken(token).Claims.First(c => c.Type == JwtRegisteredClaimNames.NameId).Value);

                List<RolDTO> roles = ctx.Usuariorol
                                        .Join(ctx.Rol,
                                              u => u.Idrol,
                                              r => r.Idrol,
                                              (u,r) => new { u, r})
                                        .Where(r => r.u.Idusuario == id
                                                    && r.u.LogEstado == ESTADOS.ACTIVO)
                                        .Select(r => new RolDTO()
                                        {
                                            Id = r.r.Idrol,
                                            Descripcion = r.r.Descripcion,
                                            LogUsuariocrea = r.r.LogUsuariocrea,
                                            LogUsuariomodifica = r.r.LogUsuariomodifica,
                                            LogFechacrea = r.r.LogFechacrea,
                                            LogFechamodifica = r.r.LogFechamodifica,
                                            LogEstado = r.r.LogEstado
                                        }).ToList();
                return roles;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
