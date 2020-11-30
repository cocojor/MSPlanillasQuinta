using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Grupo
    {
        public Grupo()
        {
            Trabajador = new HashSet<Trabajador>();
        }

        public long Idgrupo { get; set; }
        public string Grupo1 { get; set; }
        public string Descripcion { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual ICollection<Trabajador> Trabajador { get; set; }
    }
}
