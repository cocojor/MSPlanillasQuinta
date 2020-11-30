using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Usuario
    {
        public Usuario()
        {
            Planillas = new HashSet<Planillas>();
            Usuariorol = new HashSet<Usuariorol>();
        }

        public long Idusuario { get; set; }
        public string Usuario1 { get; set; }
        public string Clave { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual ICollection<Planillas> Planillas { get; set; }
        public virtual ICollection<Usuariorol> Usuariorol { get; set; }
    }
}
