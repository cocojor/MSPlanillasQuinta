﻿using System;
using System.Collections.Generic;

namespace MSRepositorioPlanillasQuinta.Modelo
{
    public partial class Planillacabecera
    {
        public long Idplanillacabecera { get; set; }
        public long Iddependencia { get; set; }
        public long Idestado { get; set; }
        public int? Anhoejecucion { get; set; }
        public int? Anhodocumento { get; set; }
        public string Nroexpedinte { get; set; }
        public string Docuemntoingreso { get; set; }
        public string Centrocostos { get; set; }
        public string Actividadoperativa { get; set; }
        public string Seccionfuncional { get; set; }
        public string Planilla { get; set; }
        public string Procesamiento { get; set; }
        public DateTime? Fechaingreso { get; set; }
        public DateTime? Fechaactualizacion { get; set; }
        public string Notatransaccion { get; set; }
        public string Folio { get; set; }
        public string Periodoexpedientes { get; set; }
        public string Asunto { get; set; }
        public string Observacion { get; set; }
        public string LogUsuariocrea { get; set; }
        public string LogUsuariomodifica { get; set; }
        public DateTime LogFechacrea { get; set; }
        public DateTime LogFechamodifica { get; set; }
        public short LogEstado { get; set; }
    }
}
