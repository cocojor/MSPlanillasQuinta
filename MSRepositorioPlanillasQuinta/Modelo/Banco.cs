using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Banco
    {
        public Banco()
        {
            Cuentabancaria = new HashSet<Cuentabancaria>();
        }

        public long Idbanco { get; set; }
        public string Nombrebanco { get; set; }
        public string Codigobanco { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual ICollection<Cuentabancaria> Cuentabancaria { get; set; }
    }
}
