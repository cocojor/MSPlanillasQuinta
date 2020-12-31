using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Planilladetalle
    {
        public long Idplanilladetalle { get; set; }
        public long Idtrabajador { get; set; }
        public long Idplanillacabecera { get; set; }
        public int? Anhopago { get; set; }
        public int? Meses { get; set; }
        public int? Totaldias { get; set; }
        public decimal? Montototal { get; set; }
        public int? Diasmes { get; set; }
        public string Dias { get; set; }
        public string Horarios { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Descuento { get; set; }
        public string Concepto { get; set; }
        public decimal? Porcentajejudicial { get; set; }
        public decimal? Judicial { get; set; }
        public decimal? Porcentajequinta { get; set; }
        public decimal? Quinta { get; set; }
        public decimal? Descuentoadicional { get; set; }
        public string Banco { get; set; }
        public string Numerocuenta { get; set; }
        public string Grupo { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }

        public virtual Planillacabecera IdplanillacabeceraNavigation { get; set; }
        public virtual Trabajador IdtrabajadorNavigation { get; set; }
    }
}
