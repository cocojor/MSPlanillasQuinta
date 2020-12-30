using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Cuentabancaria
    {
        public long Idcuenta { get; set; }
        public long Idbanco { get; set; }
        public long Idtrabajador { get; set; }
        public string Nrocuenta { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual Banco IdbancoNavigation { get; set; }
        public virtual Trabajador IdtrabajadorNavigation { get; set; }
    }
}
