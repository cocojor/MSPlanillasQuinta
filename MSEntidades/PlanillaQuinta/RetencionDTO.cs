using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class RetencionDTO: Auditoria
    {
        public long idTipoRetencion { get; set; }
        public long idTrabajador { get; set; }
        public decimal monto { get; set; }
        public decimal porcentaje { get; set; }
        public TipoRetencionDTO tipoRetencion = new TipoRetencionDTO();
    }
}
