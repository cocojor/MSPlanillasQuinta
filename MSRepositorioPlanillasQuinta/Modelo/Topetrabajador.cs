using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Topetrabajador
    {
        public long Idtopetrabajador { get; set; }
        public long Idtrabajador { get; set; }
        public int Anho { get; set; }
        public int Mes { get; set; }
        public decimal Montotope { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual Trabajador IdtrabajadorNavigation { get; set; }
    }
}
