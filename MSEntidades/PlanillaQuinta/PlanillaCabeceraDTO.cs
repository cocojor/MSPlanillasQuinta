using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class PlanillaCabeceraDTO : Auditoria
    {
        public long idDependencia { get; set; }
        public long idEstado { get; set; }
        public int anhoEjecucion { get; set; }
        public int anhoDocumento { get; set; }
        public string nroExpediente { get; set; }
        public string docuemntoIngreso {get;set;}
        public string centroCostos { get; set; }
        public string actividadOperativa { get; set; }
        public string seccionFuncional { get; set; }
        public string planilla { get; set; }
        public DateTime procesamiento { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public string notaTransaccion { get; set; }
        public string folio { get; set; }
        public string periodoExpediente { get; set; }
        public int mesProcesamiento { get; set; }
        public string asunto { get; set; }
        public string presupuestal { get; set; }
        public string siaf { get; set; }
        public string observacion { get; set; }
        public List<PlanillaDetalleDTO> detalle = new List<PlanillaDetalleDTO>();
        public EstadoDTO estado = new EstadoDTO();
        public DependenciaDTO dependencia = new DependenciaDTO();
    }
}
