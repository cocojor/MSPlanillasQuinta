using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class CuentabancariaDTO: Auditoria
    {
        public long idBanco { get; set; }
        public long idTrabajador { get; set; }
        public string nroCuenta { get; set; }
        public BancoDTO banco = new BancoDTO();
    }
}
