using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class TrabajadorDTO: Auditoria
    {
        public long idDependencia { get; set; }
        public long idTipodocumento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nombreApellido { get; set; }
        public string documento { get; set; }
        public TipodocumentoDTO tipodocumento = new TipodocumentoDTO();
        public List<GrupoDTO> grupo= new List<GrupoDTO>();
        public DependenciaDTO dependencia = new DependenciaDTO();
        public List<CuentabancariaDTO> cuentas = new List<CuentabancariaDTO>();
        public List<RetencionDTO> retenciones = new List<RetencionDTO>();
    }
}
