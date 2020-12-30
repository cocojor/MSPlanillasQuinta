using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Retencion
    {
        public long Idretencion { get; set; }
        public long Idtiporetencion { get; set; }
        public long Idtrabajador { get; set; }
        public decimal Monto { get; set; }
        public decimal Porcentaje { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual Tiporetencion IdtiporetencionNavigation { get; set; }
        public virtual Trabajador IdtrabajadorNavigation { get; set; }
    }
}
