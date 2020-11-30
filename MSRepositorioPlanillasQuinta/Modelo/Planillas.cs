using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Planillas
    {
        public long Idplanilla { get; set; }
        public long Idusuario { get; set; }
        public string Descripcionplanilla { get; set; }
        public string Correlativo { get; set; }
        public string Tipoplanilla { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsauriomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short? LogEstado { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
