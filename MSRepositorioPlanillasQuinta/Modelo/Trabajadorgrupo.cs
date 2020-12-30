using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Trabajadorgrupo
    {
        public long Idtrabajador { get; set; }
        public long Idgrupo { get; set; }
        public string Codigopersonal { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual Grupo IdgrupoNavigation { get; set; }
        public virtual Trabajador IdtrabajadorNavigation { get; set; }
    }
}
