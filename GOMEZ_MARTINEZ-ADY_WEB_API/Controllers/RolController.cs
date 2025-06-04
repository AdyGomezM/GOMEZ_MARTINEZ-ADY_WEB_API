
using Domain.DTO; 
using Domain.Entities; 
using Microsoft.AspNetCore.Http; 
using Microsoft.AspNetCore.Mvc; 
using GOMEZ_MARTINEZ_ADY_WEB_API.Services.IServices;
using GOMEZ_MARTINEZ_ADY_WEB_API.Services.Services;
using Microsoft.AspNetCore.Authorization;

namespace GOMEZ_MARTINEZ_ADY_WEB_API.Controllers
{
    [Authorize]
    // Indicamos que esta clase es un controlador de API.
    [ApiController]

    // Definimos la ruta base del controlador. Por defecto será: /Rol
    [Route("[controller]")]
    public class RolController : Controller
    {
        // Creamos una variable para acceder a los métodos del servicio de roles.
        private readonly IRolServices _rolServices;

        // Constructor del controlador, donde inyectamos el servicio de roles.
        // Así podemos usar sus métodos en todo el controlador.
        public RolController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        //metodos del controlador

        // Obtener todos los roles registrados en la base de datos.
        [HttpGet]
        public async Task<IActionResult> GetRols()
        {
            // Llamamos al servicio que obtiene todos los roles.
            var rols = await _rolServices.GetRols();

            // Devolvemos la lista con estado 200 OK.
            return Ok(rols);
        }

        // Obtener un solo rol por su ID.
        // Por ejemplo: /Rol/2
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRol(int id)
        {
            // Llamamos al servicio para buscar el rol por ID.
            var rol = await _rolServices.GetByIdRol(id);

            // Si no existe, devolvemos un mensaje con 404 Not Found.
            if (rol == null)
                return NotFound($"No se encontró un rol con ID {id}.");

            // Si sí existe, devolvemos el rol con estado 200 OK.
            return Ok(rol);
        }

        // Crear un nuevo rol en la base de datos.
        [HttpPost("crear")]
        public async Task<IActionResult> PostRol([FromBody] Rol request)
        {
            // Validamos que los datos enviados sean correctos.
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // Si hay error, devolvemos un 400 Bad Request.

            // Usamos el servicio para guardar el nuevo rol.
            var createdRol = await _rolServices.CreateRol(request);

            // Devolvemos estado 201 Created con la ubicación del nuevo rol.
            return CreatedAtAction(nameof(GetRol), new { id = createdRol.PKRol }, createdRol);
        }

        // Actualizar un rol existente.
        [HttpPut("editar/{id:int}")]
        public async Task<IActionResult> PutRol(int id, [FromBody] Rol request)
        {
            // Verificamos que el ID enviado en la URL coincida con el del cuerpo del mensaje.
            if (id != request.PKRol)
                return BadRequest("El ID en la URL no coincide con el ID del cuerpo.");

            // Llamamos al servicio para actualizar el rol.
            var updatedRol = await _rolServices.EditRol(request);

            // Si no se encontró el rol, devolvemos un 404 Not Found.
            if (updatedRol == null)
                return NotFound($"No se pudo actualizar el rol con ID {id}.");

            // Si todo salió bien, devolvemos el rol actualizado con estado 200 OK.
            return Ok(updatedRol);
        }

        // Eliminar un rol de la base de datos.
        [HttpDelete("eliminar/{id:int}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            // Llamamos al servicio para eliminar el rol.
            var deleted = await _rolServices.DeleteRol(id);

            // Si no se encontró el rol, devolvemos 404 Not Found.
            if (!deleted)
                return NotFound($"No se encontró el rol con ID {id} para eliminar.");

            // Si se eliminó correctamente, mostramos un mensaje con estado 200 OK.
            return Ok(new { message = $"Rol con ID {id} eliminado correctamente." });
        }
    }
}