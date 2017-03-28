using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication7
{
    [Serializable]
    class Star : AstronomicalObject
    {
        public string StarType { get; set; }
        public string StarColor { get; set; }

        public Star(string StarType, string StarColor)
        {
            this.StarColor = StarColor;
            this.StarType = StarType;
        }

        public Star()
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
            str[5] = StarType;
            str[6] = StarColor;
            return str;
        }

        public override void setParam(string[] param)
        {
            Name = param[0];
            Mass = Int32.Parse(param[1]);
            Radius = Int32.Parse(param[2]);
            Temperature = Int32.Parse(param[3]);
            RotationPeriod = Int32.Parse(param[4]);
            StarColor = param[5];
            StarType = param[6];
        }

        public override string[] getNames()
        {
            string[] str = new string[7];
            str[0] = "Название";
            str[1] = "Масса";
            str[2] = "Радиус";
            str[3] = "Температура";
            str[4] = "Период вращения";
            str[5] = "Тип звезды";
            str[6] = "Цвет звезды";
            return str;
        }
    }
}
