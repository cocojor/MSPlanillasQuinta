using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Permiso
    {
        public Permiso()
        {
            Rolpermiso = new HashSet<Rolpermiso>();
        }

        public long Idpermiso { get; set; }
        public long Idpadre { get; set; }
        public string Descripcion { get; set; }
        public string Ruta { get; set; }
        public string Iconmenu { get; set; }
        public string Submenu { get; set; }
        public int? Nivel { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual ICollection<Rolpermiso> Rolpermiso { get; set; }
    }
}
