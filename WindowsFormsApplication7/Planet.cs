using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApplication7
{
    [DataContract]
    [KnownType(typeof(GasPlanet))]
    [KnownType(typeof(SolidPlanet))]
    public abstract class Planet : NonStarObject
    {
        [DataMember]
        public int Satellites { get; set; }
        [DataMember]
        public int AttractivePower { get; set; }
  //      public abstract void setParam(string[] param);
    }
}
