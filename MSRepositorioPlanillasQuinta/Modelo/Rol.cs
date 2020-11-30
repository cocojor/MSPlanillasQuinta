using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Rol
    {
        public Rol()
        {
            Rolpermiso = new HashSet<Rolpermiso>();
            Usuariorol = new HashSet<Usuariorol>();
        }

        public long Idrol { get; set; }
        public string Descripcion { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual ICollection<Rolpermiso> Rolpermiso { get; set; }
        public virtual ICollection<Usuariorol> Usuariorol { get; set; }
    }
}
