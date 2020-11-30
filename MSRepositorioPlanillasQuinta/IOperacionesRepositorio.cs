using MSEntidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSRepositorioPlanillasQuinta
{
    public interface IOperacionesRepositorio
    {
        List<SeguridadMenu> ListarMenus(long idusuario, long idrol);
        Token Login(string credentials);
        List<RolDTO> GetRolesbyToken(string token);
    }
}
