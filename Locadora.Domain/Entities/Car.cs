using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaltaStore.Shared.Entities;

namespace Locadora.Domain.Entities
{
    public class Car : Entity
    {
        
        public string Brand { get; private set; }
        public string Plate { get; private set; }
        public string Model { get; private set; }
        public string Color { get; private set; }
        public DateTime year { get; private set; }
    }
}
