using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApplication7
{
    [KnownType(typeof(Star))]
    [KnownType(typeof(NonStarObject))]
    [KnownType(typeof(Planet))]
    [DataContract]
    public abstract class AstronomicalObject 
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public double Mass { get; set; }
        [DataMember]
        public double Radius { get; set; }
        [DataMember]
        public double Temperature { get; set; }
        [DataMember]
        public double RotationPeriod { get; set; }

        public abstract string[] getObjectInfo();
        public abstract void setParam(string[] param);
        public abstract string[] getNames();
    }
}
