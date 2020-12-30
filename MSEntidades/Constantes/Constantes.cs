using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Constantes
{
    public class Constantes
    {
        public class ESTADOS
        {
            public static short INACTIVO = 0;
            public static short ACTIVO = 1;
        }

        public class FILE
        {
            public static string RUTA_ARCHIVOS_SERVER = "../Archivos/";
        }

        public class TIPODOCUMENTO
        {
            public static long DNI = 1;
        }

        public class TIPORETENCION
        {
            public static long QUINTA = 1;
            public static long JUDICIAL = 2;
        }

        public class DEPENDENCIAS
        {
            public static string NINGUNA = "ZZ";
        }
    }
}
