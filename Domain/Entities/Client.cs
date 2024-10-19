using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public string IdClient { get; set; }
        public string Bill { get; set; }

        // Método específico de Client
        public void TravelList()
        {
            Console.WriteLine("Travel List called.");
        }

        // Sobrescribir el método ShowInformation
        public override void ShowInformation()
        {
            base.ShowInformation();
            Console.WriteLine($"Client ID: {IdClient}, Bill: {Bill}");
        }
    }
}