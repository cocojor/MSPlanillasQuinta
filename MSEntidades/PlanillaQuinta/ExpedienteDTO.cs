using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class ExpedienteDTO
    {
        public string documentoIngreso { get; set; }
        public string nroExpediente { get; set; }
        public int? mes { get; set; }
        public string dias { get; set; }
        public string Horarios { get; set; }
        public string estado { get; set; }
    }
}
