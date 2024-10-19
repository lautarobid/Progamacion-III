using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class AdminService : UserService
    {
        public AdminService()
        {
            // Inicialización con un Admin de ejemplo
            _users.Add(new Admin { Name = "AdminUser", LastName = "AdminLast", Email = "admin@example.com", AccessLevel = "High" });
        }

        // Crear un nuevo Admin
        public override void CreateUser(User user)
        {
            if (user is Admin admin)
            {
                _users.Add(admin);
            }
            else
            {
                throw new ArgumentException("Invalid user type. Expected Admin.");
            }
        }

        // Asignar permisos específicos de Admin
        public void AssignPermissions(int id)
        {
            var admin = GetUserById(id) as Admin;
            if (admin != null)
            {
                admin.AssignPermissions();
            }
            else
            {
                throw new ArgumentException("User is not an Admin.");
            }
        }

        // Obtener todos los Admins
        public List<Admin> GetAllAdmins()
        {
            List<Admin> admins = new List<Admin>();
            foreach (var user in _users)
            {
                if (user is Admin admin)
                {
                    admins.Add(admin);
                }
            }
            return admins;
        }
    }
}
//Crear Admin (CreateUser): Este método permite crear un nuevo usuario solo si es del tipo Admin. Si no es un Admin, se lanza una excepción.
//Asignar permisos(AssignPermissions): Este método permite asignar permisos a un Admin. Si el usuario no es un Admin, lanza una excepción.
//Obtener todos los Admins (GetAllAdmins): Devuelve una lista de todos los usuarios que son de tipo Admin.