using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Commons
{
    public class EstadoDTO : Auditoria
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
