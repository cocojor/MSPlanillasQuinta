using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Commons
{
    public class Auditoria
    {
        public long id { get; set; }
        public string logUsuariocrea { get; set; }
        public string logUsuariomodifica { get; set; }
        public DateTime logFechacrea { get; set; }
        public DateTime logFechamodifica { get; set; }
        public short logEstado { get; set; }
    }
}
