using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkTSCI.Model
{
    public class Usuario : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdTipoUsuario { get; set; }
    }
}
