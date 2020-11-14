using MSRepositorioPlanillasQuinta.Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSRepositorioPlanillasQuinta
{
    public class BaseRepository
    {
        protected readonly DBPlanillasContext ctx;

        public BaseRepository(DBPlanillasContext ctx)
        {
            this.ctx = ctx;
        }
    }
}
