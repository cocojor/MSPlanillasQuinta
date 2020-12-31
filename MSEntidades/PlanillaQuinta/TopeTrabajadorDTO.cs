using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class TopeTrabajadorDTO : Auditoria
    {
        public long idTrabajador { get; set; }
        public int anho { get; set; }
        public int mes { get; set; }
        public decimal montoTope {get;set;}
    }
}
