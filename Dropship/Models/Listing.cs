using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dropship.Models
{
    public class Listing
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public decimal BasePrice { get; set; } 
    }
}
