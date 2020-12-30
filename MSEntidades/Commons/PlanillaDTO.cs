using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Commons
{
    public class PlanillaDTO : Auditoria
    {
        
        public long idUsuario { get; set; }
        public string descripcionPlanilla { get; set; }
        public string correlativo { get; set; }
        public string tipoPlanilla { get; set; }
    }
}
