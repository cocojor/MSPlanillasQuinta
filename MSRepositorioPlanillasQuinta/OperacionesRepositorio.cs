using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MSEntidades.Commons;
using MSEntidades.PlanillaQuinta;
using MSEntidades.Seguridad;
using MSRepositorioPlanillasQuinta.Modelo;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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
        private Dictionary<string, int> cabeceraExcel = new Dictionary<string, int>()
        {
            {"CODPER", 0 },
            {"LIBELE", 0 },
            {"GR", 0 },
            {"APN", 0 },
            {"FAC", 0 },
            {"DEP", 0 },
            {"CUENTA", 0 },
            {"NCUENTA", 0 },
            {"PJUDI", 0 },
            {"IMPORTE", 0 },
            {"COD", 0 },
            {"COD_PART", 0 },
            {"DESCRIPCION", 0 }
        };
        private Dictionary<string, int> detalleExcel = new Dictionary<string, int>()
        {
            {"DNI", 0 },
            {"USUARIO EXCEL", 0 },
            {"GR", 0 },
            {"ANHOPAGO", 0 },
            {"MES", 0 },
            {"DIAS", 0 },
            {"HORARIOS", 0 },
            {"MontoTotal", 0 },
            {"DiasTotal", 0 },
            {"DiasExp", 0 }
        };

        public OperacionesRepositorio(DBPlanillasContext ctx,
                                      IConfiguration configuration): base(ctx) 
        {
            this._configuration = configuration;
        }

        #region Seguridad
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
                                            iconMenu = p.Iconmenu,
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
                    usuario1 = cred[0],
                    clave = cred[1],
                };
                Usuario user = ctx.Usuario
                                    .Where(u => u.Usuario1 == userDto.usuario1
                                                && u.Clave == userDto.clave)
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
                                            id = r.r.Idrol,
                                            descripcion = r.r.Descripcion,
                                            logUsuariocrea = r.r.LogUsuariocrea,
                                            logUsuariomodifica = r.r.LogUsuariomodifica,
                                            logFechacrea = r.r.LogFechacrea,
                                            logFechamodifica = r.r.LogFechamodifica,
                                            logEstado = r.r.LogEstado
                                        }).ToList();
                return roles;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Commons
       public List<PlanillaDTO> GetPlanillasbyToken(string token)
        {
            try
            {
                long id = Int64.Parse(decodeToken(token).Claims.First(c => c.Type == JwtRegisteredClaimNames.NameId).Value);

                List<PlanillaDTO> planillas = ctx.Planillas
                                                .Where(p => p.Idusuario == id
                                                            && p.LogEstado == ESTADOS.ACTIVO)
                                                .Select(p => new PlanillaDTO
                                                {
                                                    id = p.Idplanilla,
                                                    idUsuario = p.Idusuario,
                                                    descripcionPlanilla = p.Descripcionplanilla,
                                                    correlativo = p.Correlativo,
                                                    tipoPlanilla = p.Tipoplanilla,
                                                    logUsuariocrea = p.LogUsuariocrea,
                                                    logUsuariomodifica = p.LogUsuariomodifica,
                                                    logFechacrea = p.LogFechacrea,
                                                    logFechamodifica = p.LogFechacrea,
                                                    logEstado = p.LogEstado
                                                }).ToList();
                return planillas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DependenciaDTO> GetDependencias()
        {
            try
            {
                List<DependenciaDTO> dependencias = ctx.Dependencia
                                                        .Where(d => d.LogEstado == ESTADOS.ACTIVO)
                                                        .Select(d => new DependenciaDTO
                                                        {
                                                            id = d.Iddependencia,
                                                            idParent = d.Idparent,
                                                            codigoDependencia = d.Codigodependencia,
                                                            codigoFacultad = d.Codigofacultad,
                                                            descipcion = d.Descripcion,
                                                            logUsuariocrea = d.LogUsuariocrea,
                                                            logUsuariomodifica = d.LogUsuariomodifica,
                                                            logFechacrea = d.LogFechacrea,
                                                            logFechamodifica = d.LogFechamodifica,
                                                            logEstado = d.LogEstado
                                                        }).ToList();
                return dependencias;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EstadoDTO> GetEstados()
        {
            try
            {
                List<EstadoDTO> estados = ctx.Estado
                                            .Where(e => e.LogEstado == ESTADOS.ACTIVO)
                                            .Select(e => new EstadoDTO
                                            {
                                                id = e.Idestado,
                                                nombre = e.Nombre,
                                                descripcion = e.Descripcion,
                                                logUsuariocrea = e.LogUsuariocrea,
                                                logUsuariomodifica = e.LogUsuariomodifica,
                                                logFechacrea = e.LogFechacrea,
                                                logFechamodifica = e.LogFechamodifica,
                                                logEstado = e.LogEstado
                                            }).ToList();
                return estados;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Personal
        public CollectionsResponse<TrabajadorDTO> GetTrabajadores(string filtro, short estado, short pagina, short regxpag)
        {
            try
            {
                List<TrabajadorDTO> trabajadores = ctx.Trabajador
                                                    .Where(t => (t.Nombreapellido.ToUpper().Contains(filtro) || t.Documento.ToUpper().Contains(filtro))
                                                                && t.LogEstado == estado)
                                                    .Select(t => new TrabajadorDTO
                                                    {
                                                        id = t.Idtrabajador,
                                                        documento = t.Documento.Trim(),
                                                        nombre = t.Nombre,
                                                        apellido = t.Apellido,
                                                        nombreApellido = t.Nombreapellido,
                                                        idDependencia = t.Iddependencia,
                                                        idTipodocumento = t.Idtipodocumento,
                                                        grupo = ctx.Grupo
                                                                .Join(ctx.Trabajadorgrupo,
                                                                        g => g.Idgrupo,
                                                                        tg => tg.Idgrupo,
                                                                        (g, tg) => new { g, tg })
                                                                .Where(g => g.tg.Idtrabajador == t.Idtrabajador)
                                                                .Select(g => new GrupoDTO
                                                                {
                                                                    id = g.g.Idgrupo,
                                                                    codgrupo = g.g.Codgrupo.Trim(),
                                                                    descripcion = g.g.Descripcion,
                                                                    codigopersonal = g.tg.Codigopersonal.Trim()
                                                                }).ToList(),
                                                        tipodocumento = ctx.Tipodocumento.Where(td => td.Idtipodocumento == t.Idtipodocumento)
                                                                        .Select(td => new TipodocumentoDTO
                                                                        {
                                                                            id = td.Idtipodocumento,
                                                                            documento = td.Nombredocumento.Trim(),
                                                                            descripcion = td.Descripcion
                                                                        }).FirstOrDefault(),
                                                        dependencia = ctx.Dependencia.Where(d => d.Iddependencia == t.Iddependencia)
                                                                        .Select(d => new DependenciaDTO
                                                                        {
                                                                            id = d.Iddependencia,
                                                                            codigoFacultad = d.Codigofacultad.Trim(),
                                                                            codigoDependencia = d.Codigodependencia.Trim(),
                                                                            descipcion = d.Descripcion,
                                                                            idParent = d.Idparent
                                                                        }).FirstOrDefault()

                                                    }).ToList();
                return new CollectionsResponse<TrabajadorDTO>
                {
                    Count = trabajadores.Count(),
                    Data = trabajadores.Skip(pagina * regxpag).Take(regxpag).ToList(),
                    page = pagina
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TrabajadorDTO GetTrabajador(long idTrabajador)
        {
            try
            {
                TrabajadorDTO trabajador = ctx.Trabajador
                                                    .Where(t => (t.Idtrabajador == idTrabajador))
                                                    .Select(t => new TrabajadorDTO
                                                    {
                                                        id = t.Idtrabajador,
                                                        documento = t.Documento.Trim(),
                                                        nombre = t.Nombre,
                                                        apellido = t.Apellido,
                                                        nombreApellido = t.Nombreapellido,
                                                        idDependencia = t.Iddependencia,
                                                        idTipodocumento = t.Idtipodocumento,
                                                        grupo = ctx.Grupo
                                                                .Join(ctx.Trabajadorgrupo,
                                                                        g => g.Idgrupo,
                                                                        tg => tg.Idgrupo,
                                                                        (g, tg) => new { g, tg })
                                                                .Where(g => g.tg.Idtrabajador == t.Idtrabajador)
                                                                .Select(g => new GrupoDTO
                                                                {
                                                                    id = g.g.Idgrupo,
                                                                    codgrupo = g.g.Codgrupo.Trim(),
                                                                    descripcion = g.g.Descripcion,
                                                                    codigopersonal = g.tg.Codigopersonal.Trim()
                                                                }).ToList(),
                                                        tipodocumento = ctx.Tipodocumento.Where(td => td.Idtipodocumento == t.Idtipodocumento)
                                                                        .Select(td => new TipodocumentoDTO
                                                                        {
                                                                            id = td.Idtipodocumento,
                                                                            documento = td.Nombredocumento.Trim(),
                                                                            descripcion = td.Descripcion
                                                                        }).FirstOrDefault(),
                                                        dependencia = ctx.Dependencia.Where(d => d.Iddependencia == t.Iddependencia)
                                                                        .Select(d => new DependenciaDTO
                                                                        {
                                                                            id = d.Iddependencia,
                                                                            codigoFacultad = d.Codigofacultad.Trim(),
                                                                            codigoDependencia = d.Codigodependencia.Trim(),
                                                                            descipcion = d.Descripcion,
                                                                            idParent = d.Idparent
                                                                        }).FirstOrDefault()

                                                    }).FirstOrDefault();
                return trabajador;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TrabajadorDTO GetTrabajadorxDocumento(string documento)
        {
            try
            {
                TrabajadorDTO trabajador = ctx.Trabajador
                                                    .Where(t => (t.Documento.Trim() == documento.Trim()))
                                                    .Select(t => new TrabajadorDTO
                                                    {
                                                        id = t.Idtrabajador,
                                                        documento = t.Documento.Trim(),
                                                        nombre = t.Nombre,
                                                        apellido = t.Apellido,
                                                        nombreApellido = t.Nombreapellido,
                                                        idDependencia = t.Iddependencia,
                                                        idTipodocumento = t.Idtipodocumento,
                                                        grupo = ctx.Grupo
                                                                .Join(ctx.Trabajadorgrupo,
                                                                        g => g.Idgrupo,
                                                                        tg => tg.Idgrupo,
                                                                        (g, tg) => new { g, tg })
                                                                .Where(g => g.tg.Idtrabajador == t.Idtrabajador)
                                                                .Select(g => new GrupoDTO
                                                                {
                                                                    id = g.g.Idgrupo,
                                                                    codgrupo = g.g.Codgrupo.Trim(),
                                                                    descripcion = g.g.Descripcion,
                                                                    codigopersonal = g.tg.Codigopersonal.Trim()
                                                                }).ToList(),
                                                        tipodocumento = ctx.Tipodocumento.Where(td => td.Idtipodocumento == t.Idtipodocumento)
                                                                        .Select(td => new TipodocumentoDTO
                                                                        {
                                                                            id = td.Idtipodocumento,
                                                                            documento = td.Nombredocumento.Trim(),
                                                                            descripcion = td.Descripcion
                                                                        }).FirstOrDefault(),
                                                        dependencia = ctx.Dependencia.Where(d => d.Iddependencia == t.Iddependencia)
                                                                        .Select(d => new DependenciaDTO
                                                                        {
                                                                            id = d.Iddependencia,
                                                                            codigoFacultad = d.Codigofacultad.Trim(),
                                                                            codigoDependencia = d.Codigodependencia.Trim(),
                                                                            descipcion = d.Descripcion,
                                                                            idParent = d.Idparent
                                                                        }).FirstOrDefault()

                                                    }).FirstOrDefault();
                return trabajador;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Archivos
        public Archivo CargarBasePersonal(Archivo archivo, string usuario)
        {
            Directory.CreateDirectory(FILE.RUTA_ARCHIVOS_SERVER);
            FileStream filePersonaBase = File.Create(FILE.RUTA_ARCHIVOS_SERVER + archivo.Nombre);
            try
            {   
                filePersonaBase.Write(Convert.FromBase64String(archivo.Base64));

                using (ExcelPackage excel = new ExcelPackage(filePersonaBase))
                {
                    List<TrabajadorDTO> trabajadores = new List<TrabajadorDTO>();
                    ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;
                    
                    for(int row = 1; row <= rowCount; row++)
                    {
                        if(row == 1)
                        {
                            for (int col = 1; col <= colCount; col++)
                            {
                                string clave = worksheet.Cells[row, col].Value != null ? worksheet.Cells[row, col].Value.ToString() : "";
                                if (cabeceraExcel.ContainsKey(clave))
                                {
                                    cabeceraExcel[clave] = col;
                                }
                            }
                        }
                        else
                        {
                            string APN = worksheet.Cells[row, cabeceraExcel["APN"]].Value!= null? worksheet.Cells[row, cabeceraExcel["APN"]].Value.ToString():"";
                            string[] nombre = APN.Split(",");
                            string[] Apellidos = nombre.Length > 0? nombre[0].Split("/"): "".Split("/");
                            GrupoDTO grupoDto = new GrupoDTO()
                            {
                                codigopersonal = worksheet.Cells[row, cabeceraExcel["CODPER"]].Value != null? worksheet.Cells[row, cabeceraExcel["CODPER"]].Value.ToString():"",
                                codgrupo = worksheet.Cells[row, cabeceraExcel["GR"]].Value!= null? worksheet.Cells[row, cabeceraExcel["GR"]].Value.ToString():""
                            };
                            CuentabancariaDTO cuenta = new CuentabancariaDTO()
                            {
                                nroCuenta = worksheet.Cells[row, cabeceraExcel["NCUENTA"]].Value!=null? worksheet.Cells[row, cabeceraExcel["NCUENTA"]].Value.ToString(): "",
                                banco = new BancoDTO()
                                {
                                    codigoBanco = worksheet.Cells[row, cabeceraExcel["CUENTA"]].Value != null? worksheet.Cells[row, cabeceraExcel["CUENTA"]].Value.ToString():""
                                }
                            };
                            RetencionDTO retencionJudicial = new RetencionDTO()
                            {
                                porcentaje = worksheet.Cells[row, cabeceraExcel["PJUDI"]].Value != null ? (decimal)(double)worksheet.Cells[row, cabeceraExcel["PJUDI"]].Value : (decimal)0.0
                            };
                            TrabajadorDTO trabajador = new TrabajadorDTO()
                            {
                                nombre = nombre.Length > 0 ? nombre[1] : "",
                                apellido = Apellidos.Length >= 2 ? (Apellidos[0] + " " + Apellidos[1]) : (Apellidos.Length > 0 ? Apellidos[0] : ""),
                                nombreApellido = APN,
                                documento = worksheet.Cells[row, cabeceraExcel["LIBELE"]].Value != null ? worksheet.Cells[row, cabeceraExcel["LIBELE"]].Value.ToString() : "",
                                dependencia = new DependenciaDTO
                                {
                                    codigoDependencia = worksheet.Cells[row, cabeceraExcel["DEP"]].Value != null ? worksheet.Cells[row, cabeceraExcel["DEP"]].Value.ToString() : "",
                                    codigoFacultad = worksheet.Cells[row, cabeceraExcel["FAC"]].Value != null ? worksheet.Cells[row, cabeceraExcel["FAC"]].Value.ToString() : ""
                                },
                                idTipodocumento = TIPODOCUMENTO.DNI,
                                logUsuariocrea = usuario,
                                logUsuariomodifica = usuario,
                                logEstado = ESTADOS.ACTIVO

                            };
                            trabajador.grupo.Add(grupoDto);
                            trabajador.cuentas.Add(cuenta);
                            trabajador.retenciones.Add(retencionJudicial);

                            trabajadores.Add(trabajador);
                        }
                    }
                    InsertarTrabajadores(trabajadores);
                    filePersonaBase.Close();
                }

                Directory.Delete(FILE.RUTA_ARCHIVOS_SERVER, true);

                return archivo;
            }
            catch (Exception ex)
            {
                filePersonaBase.Close();
                Directory.Delete(FILE.RUTA_ARCHIVOS_SERVER, true);
                throw ex;
            }
        }

        private List<TrabajadorDTO> InsertarTrabajadores(List<TrabajadorDTO> trabajadores)
        {
            using (var dbcontextTransaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    List<Trabajador> _allTrabajador = ctx.Trabajador.Where(t => t.LogEstado == ESTADOS.ACTIVO).ToList();
                    foreach (Trabajador _t in _allTrabajador)
                    {
                        _t.LogEstado = ESTADOS.INACTIVO;
                    }
                    ctx.SaveChanges();
                    List<Dependencia> _allDependencias = ctx.Dependencia.Where(d=> d.LogEstado == ESTADOS.ACTIVO).ToList();
                    List<Banco> _allBancos = ctx.Banco.Where(b => b.LogEstado == ESTADOS.ACTIVO).ToList();
                    List<Grupo> _allGrupos = ctx.Grupo.Where(g => g.LogEstado == ESTADOS.ACTIVO).ToList();
                    List<Cuentabancaria> _allCuentas = ctx.Cuentabancaria.Where(c => c.LogEstado == ESTADOS.ACTIVO).ToList();
                    List<Retencion> _allRetenciones = ctx.Retencion.Where(r => r.LogEstado == ESTADOS.ACTIVO).ToList();
                    List<Trabajadorgrupo> _allTGrupos = ctx.Trabajadorgrupo.Where(tg => tg.LogEstado == ESTADOS.ACTIVO).ToList();

                    Dependencia ninguna = ctx.Dependencia.Where(d => d.Codigodependencia == DEPENDENCIAS.NINGUNA).FirstOrDefault();

                    foreach (TrabajadorDTO trabajador in trabajadores)
                    {
                        Trabajador _trabajador = _allTrabajador
                                                    .Where(t => t.Documento == trabajador.documento)
                                                    .FirstOrDefault();

                        Dependencia _dependencia = _allDependencias
                                                    .Where(d => d.Codigodependencia.Trim() == (trabajador.dependencia.codigoDependencia != ""? trabajador.dependencia.codigoDependencia : DEPENDENCIAS.NINGUNA)).FirstOrDefault();
                        if(_dependencia == null)
                        {
                            _dependencia = ninguna;
                        }
                        Banco _banco = _allBancos
                                            .Where(b => b.Codigobanco.Trim() == trabajador.cuentas[0].banco.codigoBanco)
                                            .FirstOrDefault();
                        Grupo _grupo = _allGrupos
                                            .Where(g => g.Codgrupo.Trim() == trabajador.grupo[0].codgrupo)
                                            .FirstOrDefault();

                        Cuentabancaria _cuenta = _allCuentas
                                                .Where(c => c.Nrocuenta.Trim() == trabajador.cuentas[0].nroCuenta)
                                                .FirstOrDefault();
                        Retencion _retencion = _allRetenciones
                                                .Where(r => r.Idtrabajador == (_trabajador != null? _trabajador.Idtrabajador : trabajador.id) && r.Idtiporetencion == TIPORETENCION.JUDICIAL)
                                                .FirstOrDefault();
                        Trabajadorgrupo _tgrupo = _allTGrupos
                                                    .Where(tg => tg.Idtrabajador == (_trabajador != null ? _trabajador.Idtrabajador : trabajador.id) && tg.Idgrupo == _grupo.Idgrupo)
                                                    .FirstOrDefault();
                        if (_trabajador == null)
                        {
                            _trabajador = new Trabajador()
                            {
                                Iddependencia = _dependencia.Iddependencia,
                                Apellido = trabajador.apellido,
                                Nombre = trabajador.nombre,
                                Nombreapellido = trabajador.nombreApellido,
                                Documento = trabajador.documento,
                                Idtipodocumento = trabajador.idTipodocumento,
                                LogUsuariocrea = trabajador.logUsuariocrea,
                                LogUsuariomodifica = trabajador.logUsuariomodifica,
                                LogFechacrea = DateTime.Now,
                                LogFechamodifica = DateTime.Now,
                                LogEstado = trabajador.logEstado
                            };
                            ctx.Trabajador.Add(_trabajador);
                            ctx.SaveChanges();

                            if(_banco != null)
                            {
                                _cuenta = new Cuentabancaria()
                                {
                                    Idbanco = _banco.Idbanco,
                                    Idtrabajador = _trabajador.Idtrabajador,
                                    Nrocuenta = trabajador.cuentas[0].nroCuenta,
                                    LogUsuariocrea = trabajador.logUsuariocrea,
                                    LogUsuariomodifica = trabajador.logUsuariomodifica,
                                    LogFechacrea = DateTime.Now,
                                    LogFechamodifica = DateTime.Now,
                                    LogEstado = trabajador.logEstado
                                };
                                ctx.Cuentabancaria.Add(_cuenta);
                                ctx.SaveChanges();
                            }

                            _tgrupo = new Trabajadorgrupo()
                            {
                                Idgrupo = _grupo.Idgrupo,
                                Idtrabajador = _trabajador.Idtrabajador,
                                Codigopersonal = trabajador.grupo[0].codigopersonal,
                                LogUsuariocrea = trabajador.logUsuariocrea,
                                LogUsuariomodifica = trabajador.logUsuariomodifica,
                                LogFechacrea = DateTime.Now,
                                LogFechamodifica = DateTime.Now,
                                LogEstado = trabajador.logEstado
                            };
                            ctx.Trabajadorgrupo.Add(_tgrupo);
                            ctx.SaveChanges();

                            _retencion = new Retencion()
                            {
                                Idtiporetencion = TIPORETENCION.JUDICIAL,
                                Idtrabajador = _trabajador.Idtrabajador,
                                Porcentaje = trabajador.retenciones[0].porcentaje,
                                LogUsuariocrea = trabajador.logUsuariocrea,
                                LogUsuariomodifica = trabajador.logUsuariomodifica,
                                LogFechacrea = DateTime.Now,
                                LogFechamodifica = DateTime.Now,
                                LogEstado = trabajador.logEstado
                            };
                            ctx.Retencion.Add(_retencion);
                            ctx.SaveChanges();
                        }
                        else
                        {
                            _trabajador.Documento = trabajador.documento;
                            _trabajador.Iddependencia = _dependencia.Iddependencia;
                            _trabajador.Idtipodocumento = trabajador.idTipodocumento;
                            _trabajador.Nombre = trabajador.nombre;
                            _trabajador.Apellido = trabajador.apellido;
                            _trabajador.Nombreapellido = trabajador.nombreApellido;
                            _trabajador.LogUsuariomodifica = trabajador.logUsuariomodifica;
                            _trabajador.LogFechamodifica = DateTime.Now;
                            _trabajador.LogEstado = trabajador.logEstado;

                            if (_cuenta == null)
                            {
                                _cuenta = new Cuentabancaria()
                                {
                                    Idbanco = _banco.Idbanco,
                                    Idtrabajador = _trabajador.Idtrabajador,
                                    Nrocuenta = trabajador.cuentas[0].nroCuenta,
                                    LogUsuariocrea = trabajador.logUsuariocrea,
                                    LogUsuariomodifica = trabajador.logUsuariomodifica,
                                    LogFechacrea = DateTime.Now,
                                    LogFechamodifica = DateTime.Now,
                                    LogEstado = trabajador.logEstado
                                };
                                ctx.Cuentabancaria.Add(_cuenta);
                            }
                            if (_tgrupo == null)
                            {
                                _tgrupo = new Trabajadorgrupo()
                                {
                                    Idgrupo = _grupo.Idgrupo,
                                    Idtrabajador = _trabajador.Idtrabajador,
                                    Codigopersonal = trabajador.grupo[0].codigopersonal,
                                    LogUsuariocrea = trabajador.logUsuariocrea,
                                    LogUsuariomodifica = trabajador.logUsuariomodifica,
                                    LogFechacrea = DateTime.Now,
                                    LogFechamodifica = DateTime.Now,
                                    LogEstado = trabajador.logEstado
                                };
                                ctx.Trabajadorgrupo.Add(_tgrupo);
                            }
                            _retencion.Porcentaje = trabajador.retenciones[0].porcentaje;
                            _retencion.LogUsuariomodifica = trabajador.logUsuariomodifica;
                            _retencion.LogFechamodifica = DateTime.Now;
                            _retencion.LogEstado = trabajador.logEstado;
                            ctx.SaveChanges();
                        }
                        trabajador.id = _trabajador.Idtrabajador;
                        trabajador.cuentas[0].id = _cuenta != null?_cuenta.Idcuenta:0;
                    }
                    dbcontextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbcontextTransaction.Rollback();
                    throw ex;
                }
                return trabajadores;
            }
        }

        public Archivo CargarDependencias(Archivo archivo, string usuario)
        {
            Directory.CreateDirectory(FILE.RUTA_ARCHIVOS_SERVER);
            FileStream filePersonaBase = File.Create(FILE.RUTA_ARCHIVOS_SERVER + archivo.Nombre);
            try
            {
                filePersonaBase.Write(Convert.FromBase64String(archivo.Base64));

                using (ExcelPackage excel = new ExcelPackage(filePersonaBase))
                {
                    List<DependenciaDTO> dependencias = new List<DependenciaDTO>();
                    ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 1; row <= rowCount; row++)
                    {
                        if (row == 1)
                        {
                            for (int col = 1; col <= colCount; col++)
                            {
                                string clave = worksheet.Cells[row, col].Value != null? worksheet.Cells[row, col].Value.ToString(): "";
                                if (cabeceraExcel.ContainsKey(clave))
                                {
                                    cabeceraExcel[clave] = col;
                                }
                            }
                        }
                        else
                        {
                            DependenciaDTO dependencia = new DependenciaDTO()
                            {
                                codigoDependencia = worksheet.Cells[row, cabeceraExcel["DEP"]].Value != null ? worksheet.Cells[row, cabeceraExcel["DEP"]].Value.ToString() : "",
                                codigoFacultad = worksheet.Cells[row, cabeceraExcel["FAC"]].Value != null ? worksheet.Cells[row, cabeceraExcel["FAC"]].Value.ToString() : "",
                                descipcion = worksheet.Cells[row, cabeceraExcel["DESCRIPCION"]].Value != null ? worksheet.Cells[row, cabeceraExcel["DESCRIPCION"]].Value.ToString():"",
                                idParent = worksheet.Cells[row, cabeceraExcel["COD_PART"]].Value != null ? (long?)(double)worksheet.Cells[row, cabeceraExcel["COD_PART"]].Value : null,
                                logUsuariocrea = usuario,
                                logUsuariomodifica = usuario,
                                logEstado = ESTADOS.ACTIVO
                        };

                            dependencias.Add(dependencia);
                        }
                    }
                    List<DependenciaDTO>depens = InsertarDependencias(dependencias);
                    filePersonaBase.Close();
                }

                Directory.Delete(FILE.RUTA_ARCHIVOS_SERVER, true);

                return archivo;
            }
            catch (Exception ex)
            {
                filePersonaBase.Close();
                Directory.Delete(FILE.RUTA_ARCHIVOS_SERVER, true);
                throw ex;
            }
        }

        private List<DependenciaDTO> InsertarDependencias(List<DependenciaDTO> dependencias)
        {
            using (var dbcontextTransaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    foreach (DependenciaDTO dependencia in dependencias)
                    {
                        Dependencia _dependencia = ctx.Dependencia
                                                    .Where(d => d.Codigodependencia == dependencia.codigoDependencia)
                                                    .FirstOrDefault();
                        if(_dependencia == null)
                        {
                            _dependencia = new Dependencia() 
                            {
                                Codigodependencia = dependencia.codigoDependencia,
                                Codigofacultad = dependencia.codigoFacultad,
                                Descripcion = dependencia.descipcion,
                                Idparent = dependencia.idParent,
                                LogUsuariocrea = dependencia.logUsuariocrea,
                                LogUsuariomodifica = dependencia.logUsuariomodifica,
                                LogFechacrea = DateTime.Now,
                                LogFechamodifica = DateTime.Now,
                                LogEstado = dependencia.logEstado
                            };
                            ctx.Dependencia.Add(_dependencia);
                            ctx.SaveChanges();
                        }
                        else
                        {
                            _dependencia.Idparent = dependencia.idParent;
                            _dependencia.Codigodependencia = dependencia.codigoDependencia;
                            _dependencia.Codigofacultad = dependencia.codigoFacultad;
                            _dependencia.Descripcion = dependencia.descipcion;
                            _dependencia.LogUsuariomodifica = dependencia.logUsuariomodifica;
                            _dependencia.LogFechamodifica = DateTime.Now;
                            _dependencia.LogEstado = dependencia.logEstado;
                            ctx.SaveChanges();
                        }

                        dependencia.id = _dependencia.Iddependencia;
                    }

                    dbcontextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbcontextTransaction.Rollback();
                    throw ex;
                }
            }
            return dependencias;
        }
        public Archivo CargarIMP(Archivo archivo, string usuario)
        {
            Directory.CreateDirectory(FILE.RUTA_ARCHIVOS_SERVER);
            FileStream filePersonaBase = File.Create(FILE.RUTA_ARCHIVOS_SERVER + archivo.Nombre);
            try
            {
                
                filePersonaBase.Write(Convert.FromBase64String(archivo.Base64));

                using (ExcelPackage excel = new ExcelPackage(filePersonaBase))
                {
                    List<TrabajadorDTO> imps = new List<TrabajadorDTO>();
                    ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    

                    for (int row = 1; row <= rowCount; row++)
                    {
                        if (row == 1)
                        {
                            for (int col = 1; col <= colCount; col++)
                            {
                                string clave = worksheet.Cells[row, col].Value != null ? worksheet.Cells[row, col].Value.ToString() : "";
                                if (cabeceraExcel.ContainsKey(clave))
                                {
                                    cabeceraExcel[clave] = col;
                                }
                            }
                        }
                        else
                        {
                            TrabajadorDTO dependencia = new TrabajadorDTO()
                            {
                                documento = worksheet.Cells[row, cabeceraExcel["LIBELE"]].Value != null ? worksheet.Cells[row, cabeceraExcel["LIBELE"]].Value.ToString() : "",
                                nombreApellido = worksheet.Cells[row, cabeceraExcel["APN"]].Value != null ? worksheet.Cells[row, cabeceraExcel["APN"]].Value.ToString() : "",
                                retenciones = new List<RetencionDTO>()
                                {
                                    new RetencionDTO()
                                    {
                                        idTipoRetencion = TIPORETENCION.QUINTA,
                                        porcentaje = worksheet.Cells[row, cabeceraExcel["IMPORTE"]].Value != null ? (decimal)(double)worksheet.Cells[row, cabeceraExcel["IMPORTE"]].Value : 0
                                    }
                                },
                                logUsuariocrea = usuario,
                                logUsuariomodifica = usuario,
                                logEstado = ESTADOS.ACTIVO
                            };

                            imps.Add(dependencia);
                        }
                    }
                    List<TrabajadorDTO> depens = InsertarRetenciones(imps);
                    filePersonaBase.Close();
                }

                Directory.Delete(FILE.RUTA_ARCHIVOS_SERVER, true);

                return archivo;
            }
            catch (Exception ex)
            {
                filePersonaBase.Close();
                
                Directory.Delete(FILE.RUTA_ARCHIVOS_SERVER, true);
                throw ex;
            }
        }

        private List<TrabajadorDTO> InsertarRetenciones(List<TrabajadorDTO> imps)
        {
            using (var dbcontextTransaction = ctx.Database.BeginTransaction())
            {
                int countTemp = 0;
                try
                {
                    foreach (TrabajadorDTO trabajdor in imps)
                    {
                        
                        Trabajador _trabajador = ctx.Trabajador
                                                    .Where(t => t.Documento == trabajdor.documento)
                                                    .FirstOrDefault();
                        if (_trabajador != null)
                        {
                            Retencion _quinta = ctx.Retencion
                                                    .Where(r => r.Idtrabajador == _trabajador.Idtrabajador
                                                                && r.Idtiporetencion == trabajdor.retenciones[0].idTipoRetencion)
                                                    .FirstOrDefault();
                            if( _quinta == null)
                            {
                                _quinta = new Retencion()
                                {
                                    Idtiporetencion = trabajdor.retenciones[0].idTipoRetencion,
                                    Idtrabajador = _trabajador.Idtrabajador,
                                    Porcentaje = trabajdor.retenciones[0].porcentaje,
                                    LogUsuariocrea = trabajdor.logUsuariocrea,
                                    LogUsuariomodifica = trabajdor.logUsuariomodifica,
                                    LogFechacrea = DateTime.Now,
                                    LogFechamodifica = DateTime.Now,
                                    LogEstado = trabajdor.logEstado
                                };
                                ctx.Retencion.Add(_quinta);
                                ctx.SaveChanges();
                            }else
                            {
                                _quinta.Porcentaje = trabajdor.retenciones[0].porcentaje;
                                _quinta.LogUsuariomodifica = trabajdor.logUsuariomodifica;
                                _quinta.LogFechamodifica = DateTime.Now;
                                _quinta.LogEstado = trabajdor.logEstado;
                                ctx.SaveChanges();
                            }
                            trabajdor.id = _trabajador.Idtrabajador;
                        }
                        countTemp++;
                    }

                    dbcontextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbcontextTransaction.Rollback();
                    countTemp = 0;
                    throw ex;
                }
            }
            return imps;
        }
        #endregion

        #region Planillas
        public RespuestaMasivo ProcesarMasivo(Archivo archivo)
        {
            Directory.CreateDirectory(FILE.RUTA_ARCHIVOS_SERVER);
            FileStream fileExcelMasivo = File.Create(FILE.RUTA_ARCHIVOS_SERVER + archivo.Nombre);
            RespuestaMasivo respuesta = new RespuestaMasivo();
            try
            {
                fileExcelMasivo.Write(Convert.FromBase64String(archivo.Base64));

                using (ExcelPackage excel = new ExcelPackage(fileExcelMasivo))
                {
                    List<PlanillaDetalleDTO> detalles = new List<PlanillaDetalleDTO>();
                    ExcelWorksheet worksheet = excel.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 1; row <= rowCount; row++)
                    {
                        if (row == 1)
                        {
                            for (int col = 1; col <= colCount; col++)
                            {
                                string clave = worksheet.Cells[row, col].Value != null ? worksheet.Cells[row, col].Value.ToString() : "";
                                if (detalleExcel.ContainsKey(clave))
                                {
                                    detalleExcel[clave] = col;
                                }
                            }
                        }
                        else
                        {
                            PlanillaDetalleDTO detalle = new PlanillaDetalleDTO()
                            {
                                anhoPago = worksheet.Cells[row, detalleExcel["ANHOPAGO"]].Value != null ? (int)(double)worksheet.Cells[row, detalleExcel["ANHOPAGO"]].Value : 0,
                                meses = worksheet.Cells[row, detalleExcel["MES"]].Value != null ? (int)(double)worksheet.Cells[row, detalleExcel["MES"]].Value : 0,
                                dias = worksheet.Cells[row, detalleExcel["DIAS"]].Value != null ? worksheet.Cells[row, detalleExcel["DIAS"]].Value.ToString() : "",
                                montoTotal = worksheet.Cells[row, detalleExcel["MontoTotal"]].Value != null ? (decimal)(double)worksheet.Cells[row, detalleExcel["MontoTotal"]].Value : 0,
                                totalDias = worksheet.Cells[row, detalleExcel["DiasTotal"]].Value != null ? (int)(double)worksheet.Cells[row, detalleExcel["DiasTotal"]].Value : 0,
                                diasMeses = worksheet.Cells[row, detalleExcel["DiasExp"]].Value != null ? (int)(double)worksheet.Cells[row, detalleExcel["DiasExp"]].Value : 0,
                                horarios = worksheet.Cells[row, detalleExcel["HORARIOS"]].Value != null ? worksheet.Cells[row, detalleExcel["HORARIOS"]].Value.ToString() : "",
                                trabajador = new TrabajadorDTO()
                                {
                                    documento = worksheet.Cells[row, detalleExcel["DNI"]].Value != null ? worksheet.Cells[row, detalleExcel["DNI"]].Value.ToString() : "",
                                    nombreApellido = worksheet.Cells[row, detalleExcel["USUARIO EXCEL"]].Value != null ? worksheet.Cells[row, detalleExcel["USUARIO EXCEL"]].Value.ToString() : ""
                                }
                            };

                            detalles.Add(detalle);
                        }
                    }
                    respuesta = ValidarDetalles(detalles);
                    fileExcelMasivo.Close();
                }

                Directory.Delete(FILE.RUTA_ARCHIVOS_SERVER, true);

                return respuesta;
            }
            catch (Exception ex)
            {
                fileExcelMasivo.Close();
                Directory.Delete(FILE.RUTA_ARCHIVOS_SERVER, true);
                throw ex;
            }
        }

        private RespuestaMasivo ValidarDetalles(List<PlanillaDetalleDTO> detalles)
        {
            try
            {
                RespuestaMasivo respuesta = new RespuestaMasivo();
                foreach (PlanillaDetalleDTO detalle in detalles)
                {
                    TrabajadorDTO trabajador = GetTrabajadorxDocumento(detalle.trabajador.documento);
                    if( trabajador != null)
                    {
                        detalle.idTrabajador = trabajador.id;
                        detalle.trabajador = trabajador;
                        detalle.grupo = trabajador.grupo[0].codgrupo;
                        detalle.monto = (detalle.montoTotal / detalle.totalDias) * detalle.diasMeses;
                        respuesta.verificados.Add(detalle);
                    } else
                    {
                        respuesta.noencontrados.Add(detalle);
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PlanillaCabeceraDTO GuardarPlanillaQuinta(PlanillaCabeceraDTO planilla, string usuario)
        {
            using (var dbcontextTransaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    Planillacabecera _planillaCabecera = new Planillacabecera()
                    {
                        Iddependencia = planilla.idDependencia,
                        Idestado = planilla.idEstado,
                        Anhoejecucion = planilla.anhoEjecucion,
                        Anhodocumento = planilla.anhoDocumento,
                        Nroexpedinte = planilla.nroExpediente,
                        Centrocostos = planilla.centroCostos,
                        Actividadoperativa = planilla.actividadOperativa,
                        Seccionfuncional = planilla.seccionFuncional,
                        Planilla = planilla.planilla,
                        Fechaingreso = planilla.fechaIngreso,
                        Fechaactualizacion = planilla.fechaActualizacion,
                        Notatransaccion = planilla.notaTransaccion,
                        Docuemntoingreso = planilla.docuemntoIngreso,
                        Folio = planilla.folio,
                        Asunto = planilla.asunto,
                        Observacion = planilla.observacion,
                        Periodoexpedientes = planilla.periodoExpediente,
                        LogUsuariocrea = usuario,
                        LogUsuariomodifica = usuario,
                        LogFechacrea = DateTime.Now,
                        LogFechamodifica = DateTime.Now,
                        LogEstado = ESTADOS.ACTIVO
                    };
                    ctx.Planillacabecera.Add(_planillaCabecera);
                    ctx.SaveChanges();
                    planilla.id = _planillaCabecera.Idplanillacabecera;
                    foreach (PlanillaDetalleDTO detalle in planilla.detalle)
                    {
                        Planilladetalle _detalle = new Planilladetalle()
                        {
                            Idtrabajador = detalle.idTrabajador,
                            Idplanillacabecera = planilla.id,
                            Anhopago = detalle.anhoPago,
                            Meses = detalle.meses,
                            Totaldias = detalle.totalDias,
                            Montototal = detalle.montoTotal,
                            Diasmes = detalle.diasMeses,
                            Dias = detalle.dias,
                            Horarios = detalle.horarios,
                            Monto = detalle.monto,
                            Grupo = detalle.grupo,
                            LogUsuariocrea = usuario,
                            LogUsuariomodifica = usuario,
                            LogFechacrea = DateTime.Now,
                            LogFechamodifica = DateTime.Now,
                            LogEstado = ESTADOS.ACTIVO
                        };
                        ctx.Planilladetalle.Add(_detalle);
                        ctx.SaveChanges();

                        detalle.id = _detalle.Idplanilladetalle;
                    }
                    dbcontextTransaction.Commit();
                    return planilla;
                }
                catch (Exception ex)
                {
                    dbcontextTransaction.Rollback();
                    throw ex;
                }
            }
        }

        public List<TopeTrabajadorDTO> ObtenerTopes(long idTrabajador, int anho)
        {
            try
            {
                List<TopeTrabajadorDTO> topes = ctx.Topetrabajador
                                                    .Where(t => t.Idtrabajador == idTrabajador
                                                                && t.Anho == anho
                                                                && t.LogEstado == ESTADOS.ACTIVO)
                                                    .OrderBy(t => t.Mes)
                                                    .Select(t => new TopeTrabajadorDTO()
                                                    {
                                                        id = t.Idtopetrabajador,
                                                        idTrabajador = t.Idtopetrabajador,
                                                        anho = t.Anho,
                                                        mes = t.Mes,
                                                        montoTope = t.Montotope,
                                                        logUsuariocrea = t.LogUsuariocrea,
                                                        logUsuariomodifica = t.LogUsuariomodifica,
                                                        logFechacrea = t.LogFechacrea,
                                                        logFechamodifica = t.LogFechamodifica,
                                                        logEstado = t.LogEstado
                                                    }).ToList();
                return topes;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ExpedienteDTO> ObtenerExpedientes(long idTrabajador, int anho, int mes)
        {
            try
            {
                List<ExpedienteDTO> expedientes = ctx.Planilladetalle
                                                     .Join(ctx.Planillacabecera,
                                                            pd => pd.Idplanillacabecera,
                                                            pc => pc.Idplanillacabecera,
                                                            (pd,pc) => new { pd, pc})
                                                     .Join(ctx.Estado,
                                                            pd => pd.pc.Idestado,
                                                            e => e.Idestado,
                                                            (pd,e) => new { pd, e})
                                                     .Where(pd => pd.pd.pd.Idtrabajador == idTrabajador
                                                                && pd.pd.pd.Anhopago == anho
                                                                && pd.pd.pd.Meses == mes
                                                                && pd.pd.pd.LogEstado == ESTADOS.ACTIVO)
                                                     .Select(pd => new ExpedienteDTO
                                                     {
                                                         documentoIngreso = pd.pd.pc.Docuemntoingreso,
                                                         nroExpediente = pd.pd.pc.Nroexpedinte,
                                                         estado = pd.e.Descripcion,
                                                         mes = pd.pd.pd.Meses,
                                                         dias = pd.pd.pd.Dias,
                                                         Horarios = pd.pd.pd.Horarios
                                                     }).ToList();
                return expedientes;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
