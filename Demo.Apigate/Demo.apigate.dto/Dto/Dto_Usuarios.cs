using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.apigate.dto.Dto
{
    public class Dto_Usuarios
    {
        public int U_Id { get; set; }
        public string? U_Nombre { get; set; }
        public string? U_Apellidos { get; set; }
        public string? U_Telefono { get; set; }
        public string? U_Direccion { get; set; }
        public string? U_Contrasena { get; set; }
        public bool? U_Estado { get; set; }
        public string? Correo { get; set; }
        public int accion { get; set; }
    }
}
