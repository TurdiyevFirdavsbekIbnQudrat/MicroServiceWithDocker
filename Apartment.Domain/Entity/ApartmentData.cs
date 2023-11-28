using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entity
{
    public class ApartmentData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? address { get; set; }
        public string? Description { get; set; }
    }
}
