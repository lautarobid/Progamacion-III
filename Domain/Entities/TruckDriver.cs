using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TruckDriver : User
    {
        public string DriverLicense { get; set; }
        public string Truck { get; set; }

        // Método específico de TruckDriver
        public void DriverList()
        {
            Console.WriteLine("Driver List called.");
        }

        // Sobrescribir el método ShowInformation
        public override void ShowInformation()
        {
            base.ShowInformation();
            Console.WriteLine($"Driver License: {DriverLicense}, Truck: {Truck}");
        }
    }
}