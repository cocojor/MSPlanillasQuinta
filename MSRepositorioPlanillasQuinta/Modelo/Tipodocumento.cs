using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Tipodocumento
    {
        public Tipodocumento()
        {
            Trabajador = new HashSet<Trabajador>();
        }

        public long Idtipodocumento { get; set; }
        public string Documento { get; set; }
        public string Descripcion { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual ICollection<Trabajador> Trabajador { get; set; }
    }
}
