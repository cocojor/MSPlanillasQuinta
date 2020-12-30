using MSEntidades.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Seguridad
{
    public class UsuarioDto: Auditoria
    {
        public string usuario1 { get; set; }
        public string clave { get; set; }
    }
}
