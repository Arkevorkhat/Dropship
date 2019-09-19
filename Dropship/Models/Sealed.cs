using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dropship.Models
{
    public class Sealed : Listing //Read "public class Sealed extends Listing"
    {
       
        public int NumPacks { get; set; }
        public void setPacks(PackCounts count)
        {
            this.NumPacks = (int) count; //This is bad form, but it'll work.
            //The reason that this isn't good is because we're using an enum (PackCounts)
            //enums typically, though not always, use ints (Integers) as their backing type
            //if we extend the PackCounts enum to have values above 2147483647, we'll start
            //having issues where the backing type becomes long, or if it gets truly massive,
            //possibly long long. If this happens, this code will break.
        }
    }
}
