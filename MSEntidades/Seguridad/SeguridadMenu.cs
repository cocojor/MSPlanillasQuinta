using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Seguridad
{
    public class SeguridadMenu
    {
        public long? idPermiso { get; set; }
        public long? idParent { get; set; }
        public string icoMenu { get; set; }
        public string descripcion { get; set; }
        public string ruta { get; set; }
        public string Submenu { get; set; }
        public int? nivel { get; set; }
        public List<SeguridadMenu> hijos { get; set; } = new List<SeguridadMenu>();
    }
}
