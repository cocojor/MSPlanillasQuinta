using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Trabajador
    {
        public Trabajador()
        {
            Planilladetalle = new HashSet<Planilladetalle>();
        }

        public long Idtrabajador { get; set; }
        public long Iddependencia { get; set; }
        public long Idgrupo { get; set; }
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
        public virtual Grupo IdgrupoNavigation { get; set; }
        public virtual Tipodocumento IdtipodocumentoNavigation { get; set; }
        public virtual ICollection<Planilladetalle> Planilladetalle { get; set; }
    }
}
