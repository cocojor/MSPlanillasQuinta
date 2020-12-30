using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class GrupoDTO : Auditoria
    {
        public string codgrupo { get; set; }
        public string descripcion { get; set; }
        public string tipogrupo { get; set; }
        public string codigopersonal { get; set; }
    }
}
