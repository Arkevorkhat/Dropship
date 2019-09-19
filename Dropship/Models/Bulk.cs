using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dropship.Models
{
    public class Bulk : Listing
    {
        public int Count { get; set; }
        public string SetCode { get; set; } //Random sets will have code RND, other sets 
        //will use the native set code for the game.

    }
}
