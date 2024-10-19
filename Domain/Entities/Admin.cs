using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Admin : User
    {
        public string AccessLevel { get; set; }

        // Método específico de Admin
        public void AssignPermissions()
        {
            Console.WriteLine("Permissions assigned.");
        }

        // Sobrescribir el método ShowInformation
        public override void ShowInformation()
        {
            base.ShowInformation();
            Console.WriteLine($"Access Level: {AccessLevel}");
        }
    }
}