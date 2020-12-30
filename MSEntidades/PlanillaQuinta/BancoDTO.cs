using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class BancoDTO: Auditoria
    {
        public string nombreBanco { get; set; }
        public string codigoBanco { get; set; }
    }
}
