using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Seguridad
{
    public class UsuarioDto 
    {
        public long Id { get; set; }
        public string Usuario1 { get; set; }
        public string Clave { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }
    }
}
