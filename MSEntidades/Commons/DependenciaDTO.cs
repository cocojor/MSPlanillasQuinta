using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Commons
{
    public class DependenciaDTO : Auditoria
    {
        public long? idParent { get; set; }
        public string codigoFacultad { get; set; }
        public string codigoDependencia { get; set; }
        public string descipcion { get; set; }
    }
}
