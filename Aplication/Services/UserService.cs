using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace ProgIII.Aplication.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>();

        public UserService()
        {
            // Inicialización de la lista con algunos datos de ejemplo.
            _users.Add(new Admin { Name = "AdminUser", LastName = "AdminLast", Email = "admin@example.com", AccessLevel = "High" });
            _users.Add(new TruckDriver { Name = "DriverUser", LastName = "DriverLast", Email = "driver@example.com", DriverLicense = "D123456", Truck = "Volvo FH" });
            _users.Add(new Client { Name = "ClientUser", LastName = "ClientLast", Email = "client@example.com", IdClient = "C123", Bill = "$500" });
        }

        // Obtener todos los usuarios
        public List<User> GetAllUsers()
        {
            return _users;
        }

        // Obtener un usuario por ID (en este caso usando un índice de la lista)
        public User GetUserById(int id)
        {
            if (id < 0 || id >= _users.Count)
            {
                throw new ArgumentException("Invalid user ID");
            }

            return _users[id];
        }

        // Crear un nuevo usuario
        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            _users.Add(user);
        }

        // Actualizar un usuario por ID
        public void UpdateUser(int id, User updatedUser)
        {
            if (id < 0 || id >= _users.Count)
            {
                throw new ArgumentException("Invalid user ID");
            }

            if (updatedUser == null)
            {
                throw new ArgumentNullException(nameof(updatedUser), "Updated user cannot be null");
            }

            _users[id] = updatedUser;
        }

        // Eliminar un usuario por ID
        public void DeleteUser(int id)
        {
            if (id < 0 || id >= _users.Count)
            {
                throw new ArgumentException("Invalid user ID");
            }

            _users.RemoveAt(id);
        }
    }
}