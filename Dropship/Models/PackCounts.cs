using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dropship.Models
{
    public enum PackCounts
    {
        PACK = 1,
        BUNDLE = 10, //MtG Bundles
        S_BOX = 24, //UFS and MtG Masters
        BOX = 36,  //MtG regular sets
        S_CASE = 144, //MtG Masters
        CASE = 216 //MtG regular
    }
}
