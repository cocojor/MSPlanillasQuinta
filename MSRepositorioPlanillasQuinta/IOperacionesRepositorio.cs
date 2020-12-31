using MSEntidades.Commons;
using MSEntidades.PlanillaQuinta;
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
        List<PlanillaDTO> GetPlanillasbyToken(string token);
        List<DependenciaDTO> GetDependencias();
        List<EstadoDTO> GetEstados();
        CollectionsResponse<TrabajadorDTO> GetTrabajadores(string filtro, short estado, short pagina, short regxpag);
        Archivo CargarBasePersonal(Archivo archivo, string usuario);
        Archivo CargarDependencias(Archivo archivo, string usuario);
        Archivo CargarIMP(Archivo archivo, string usuario);
        TrabajadorDTO GetTrabajador(long idTrabajador);
        RespuestaMasivo ProcesarMasivo(Archivo archivo);
        PlanillaCabeceraDTO GuardarPlanillaQuinta(PlanillaCabeceraDTO planilla, string usuario);
        List<TopeTrabajadorDTO> ObtenerTopes(long idTrabajador, int anho);
        List<ExpedienteDTO> ObtenerExpedientes(long idTrabajador, int anho, int mes);
    }
}
