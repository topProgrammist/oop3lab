using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WindowsFormsApplication7
{
    [DataContract]
    class SolidPlanet : Planet
    {
        public SolidPlanet()
        {

        }

        public override string[] getObjectInfo()
        {
            string[] str = new string[7];
            str[0] = Name;
            str[1] = Mass.ToString();
            str[2] = Radius.ToString();
            str[3] = Temperature.ToString();
            str[4] = RotationPeriod.ToString();
            str[5] = Satellites.ToString() ;
            str[6] = AttractivePower.ToString();
            return str;
        }

        public override void setParam(string[] param)
        {
            Name = param[0];
            Mass = Int32.Parse(param[1]);
            Radius = Int32.Parse(param[2]);
            Temperature = Int32.Parse(param[3]);
            RotationPeriod = Int32.Parse(param[4]);
            Satellites = Int32.Parse(param[5]);
            AttractivePower = Int32.Parse(param[6]);
        }

        public override string[] getNames()
        {
            string[] str = new string[7];
            str[0] = "Название";
            str[1] = "Масса";
            str[2] = "Радиус";
            str[3] = "Температура";
            str[4] = "Период вращения";
            str[5] = "Число спутников";
            str[6] = "Сила притяжения";
            return str;
        }
    }
}
