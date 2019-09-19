using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dropship.Models
{
    public class Card : Listing
    {
        public string SetCode { get; set; } //JSON: Ensure all set codes are string literals or have Escaped spaces.
        public string CollectorsNumber { get; set; } //Convention: Promos with overlapping collectors numbers are <number>P
        public string UID { get => SetCode + "_" + CollectorsNumber.ToString(); } //ID eg. CB01_127
    }
}
