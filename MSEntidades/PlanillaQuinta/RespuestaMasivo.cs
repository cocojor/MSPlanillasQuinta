using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.PlanillaQuinta
{
    public class RespuestaMasivo
    {
        public List<PlanillaDetalleDTO> verificados = new List<PlanillaDetalleDTO>();
        public List<PlanillaDetalleDTO> noencontrados = new List<PlanillaDetalleDTO>();
    }
}
