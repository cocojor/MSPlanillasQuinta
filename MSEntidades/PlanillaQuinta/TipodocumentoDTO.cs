using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class TipodocumentoDTO: Auditoria
    {
        public string documento { get; set; }
        public string descripcion { get; set; }
    }
}
