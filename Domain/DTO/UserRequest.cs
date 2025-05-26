using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    // que sirve para mover datos de un lado a otro en nuestra aplicación (por ejemplo, del backend al frontend).
    public class UserRequest
    {
        // Esta propiedad es el ID del usuario, sirve como identificador único (llave primaria).
        public int PKUser { get; set; }

        // Esta propiedad guarda el nombre completo del usuario.
        public string Name { get; set; }

        // Aquí se guarda el nombre de usuario que usará para iniciar sesión.
        public string Username { get; set; }

        // Esta propiedad guarda la contraseña del usuario.
       
        public string Password { get; set; }

        // Esta es una llave foránea (FK) que hace referencia al rol del usuario (como "administrador", "cliente", etc.).
        // El signo de interrogación (?) significa que este valor puede ser nulo, es decir, el usuario puede no tener rol asignado.
        public int? FKRol { get; set; }
    }
}
