using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    [Serializable]
    public abstract class Planet : NonStarObject
    {
        public string Satellites { get; set; }
        public int AttractivePower { get; set; }
  //      public abstract void setParam(string[] param);
    }
}
