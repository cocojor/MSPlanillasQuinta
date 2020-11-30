using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Contactoexpediente
    {
        public long Idcontactoexpediente { get; set; }
        public long Idplanillacabecera { get; set; }
        public DateTime Fechacontacto { get; set; }
        public string Contacto { get; set; }
        public string Motivo { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual Planillacabecera IdplanillacabeceraNavigation { get; set; }
    }
}
