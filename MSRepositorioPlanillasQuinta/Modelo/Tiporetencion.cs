using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Tiporetencion
    {
        public Tiporetencion()
        {
            Retencion = new HashSet<Retencion>();
        }

        public long Idtiporetencion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual ICollection<Retencion> Retencion { get; set; }
    }
}
