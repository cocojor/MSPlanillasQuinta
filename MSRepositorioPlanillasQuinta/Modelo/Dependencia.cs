using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Dependencia
    {
        public Dependencia()
        {
            InverseIdparentNavigation = new HashSet<Dependencia>();
            Planillacabecera = new HashSet<Planillacabecera>();
            Trabajador = new HashSet<Trabajador>();
        }

        public long Iddependencia { get; set; }
        public long? Idparent { get; set; }
        public string Codigofacultad { get; set; }
        public string Codigodependencia { get; set; }
        public string Descripcion { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual Dependencia IdparentNavigation { get; set; }
        public virtual ICollection<Dependencia> InverseIdparentNavigation { get; set; }
        public virtual ICollection<Planillacabecera> Planillacabecera { get; set; }
        public virtual ICollection<Trabajador> Trabajador { get; set; }
    }
}
