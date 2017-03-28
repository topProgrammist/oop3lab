using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApplication7
{
    [DataContract]
    [KnownType(typeof(Comet))]
    public abstract class NonStarObject : AstronomicalObject
    {
  //      public AstronomicalObject CentralBody { get; set; }

   //     public bool Life { get; set; }
        public double DistanceToTheStar { get; set; }

    }
}
