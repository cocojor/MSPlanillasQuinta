using MSRepositorioPlanillasQuinta.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSRepositorioPlanillasQuinta
{
    public class OperacionesRepositorio: BaseRepository, IOperacionesRepositorio
    {
        public OperacionesRepositorio(DBPlanillasContext ctx): base(ctx) 
        { 
        }
    }
}
