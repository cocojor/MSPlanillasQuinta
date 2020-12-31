using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Trabajador
    {
        public Trabajador()
        {
            Cuentabancaria = new HashSet<Cuentabancaria>();
            Planilladetalle = new HashSet<Planilladetalle>();
            Retencion = new HashSet<Retencion>();
            Topetrabajador = new HashSet<Topetrabajador>();
            Trabajadorgrupo = new HashSet<Trabajadorgrupo>();
        }

        public long Idtrabajador { get; set; }
        public long Iddependencia { get; set; }
        public long Idtipodocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nombreapellido { get; set; }
        public string Documento { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual Dependencia IddependenciaNavigation { get; set; }
        public virtual Tipodocumento IdtipodocumentoNavigation { get; set; }
        public virtual ICollection<Cuentabancaria> Cuentabancaria { get; set; }
        public virtual ICollection<Planilladetalle> Planilladetalle { get; set; }
        public virtual ICollection<Retencion> Retencion { get; set; }
        public virtual ICollection<Topetrabajador> Topetrabajador { get; set; }
        public virtual ICollection<Trabajadorgrupo> Trabajadorgrupo { get; set; }
    }
}
