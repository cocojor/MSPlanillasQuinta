using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Seguridad
{
    public class Token
    {
        public string stateCode { get; set; }
        public long tipoToken { get; set; }
        public string requestAt { get; set; }
        public long expiresIn { get; set; }
        public string accessToken { get; set; }
        public string refreshToken { get; set; }
    }
}
