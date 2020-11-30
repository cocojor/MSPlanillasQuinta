using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Usuariorol
    {
        public long Idusuario { get; set; }
        public long Idrol { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual Rol IdrolNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
