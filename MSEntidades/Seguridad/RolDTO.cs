using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Seguridad
{
    public class RolDTO
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }
    }
}
