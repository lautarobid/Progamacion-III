using Aplication.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        // En una aplicación real, este servicio debería ser inyectado con DI (Dependency Injection)
        public AdminController()
        {
            _adminService = new AdminService();
        }

        // Obtener todos los Admins
        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAllAdmins()
        {
            var admins = _adminService.GetAllAdmins();
            return Ok(admins);
        }

        // Obtener un Admin por ID
        [HttpGet("{id}")]
        public ActionResult<Admin> GetAdminById(int id)
        {
            try
            {
                var admin = (Admin)_adminService.GetUserById(id);
                return Ok(admin);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Crear un nuevo Admin
        [HttpPost]
        public ActionResult CreateAdmin([FromBody] Admin admin)
        {
            try
            {
                _adminService.CreateUser(admin);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Asignar permisos a un Admin
        [HttpPost("{id}/assign-permissions")]
        public ActionResult AssignPermissions(int id)
        {
            try
            {
                _adminService.AssignPermissions(id);
                return Ok("Permissions assigned.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Actualizar un Admin por ID
        [HttpPut("{id}")]
        public ActionResult UpdateAdmin(int id, [FromBody] Admin updatedAdmin)
        {
            try
            {
                _adminService.UpdateUser(id, updatedAdmin);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Eliminar un Admin por ID
        [HttpDelete("{id}")]
        public ActionResult DeleteAdmin(int id)
        {
            try
            {
                _adminService.DeleteUser(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
//GetAllAdmins(): Este método responde a una solicitud HTTP GET y devuelve una lista de todos los administradores (Admin) almacenados en el sistema.
//GetAdminById(): Permite obtener un Admin específico por su ID.
//CreateAdmin(): Este método permite crear un nuevo Admin. Usa el método CreateUser del AdminService.
//AssignPermissions(): Este método permite asignar permisos a un administrador a través de una solicitud HTTP POST.
//UpdateAdmin(): Permite actualizar la información de un Admin específico a través de una solicitud HTTP PUT.
//DeleteAdmin(): Elimina un administrador por ID usando una solicitud HTTP DELETE.