using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class PlanillaDetalleDTO: Auditoria
    {
        public long idTrabajador { get; set; }
        public long idPlanillaCabecera { get; set; }
        public int anhoPago { get; set; }
        public int meses { get; set; }
        public int totalDias { get; set; }
        public decimal montoTotal { get; set; }
        public int diasMeses { get; set; }
        public string dias { get; set; }
        public string horarios { get; set; }
        public decimal monto { get; set; }
        public decimal descuento { get; set; }
        public string concepto { get; set; }
        public decimal porcentajeJudicial{get;set;}
        public decimal judiacial { get; set; }
        public decimal porcentajeQuinta { get; set; }
        public decimal quinta { get; set; }
        public string banco { get; set; }
        public string numeroCuenta { get; set; }
        public TrabajadorDTO trabajador = new TrabajadorDTO();
        public string grupo { get; set; }
    }
}
