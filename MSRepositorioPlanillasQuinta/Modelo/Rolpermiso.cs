using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Rolpermiso
    {
        public long Idrol { get; set; }
        public long Idpermiso { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifca { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public DateTime LogEstado { get; set; }

        public virtual Permiso IdpermisoNavigation { get; set; }
        public virtual Rol IdrolNavigation { get; set; }
    }
}
