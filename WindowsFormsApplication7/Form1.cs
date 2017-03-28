using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        List<AstronomicalObject> astronomicalObjects = new List<AstronomicalObject>();
        int mode;
        public Form1()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private AstronomicalObject changeObject(AstronomicalObject astrObject)
        {
            astrObject = new SolidPlanet();
            PropertyDescriptor descr = TypeDescriptor.GetProperties(astrObject)["Id"];
            
            // curr.
            switch (cmb.Text)
            {
                case "Звезда":
                    Star star = (Star)astrObject;
                        return star;
                case "Газовая планета":
                    GasPlanet gasPlanet = (GasPlanet)astrObject;
                        return gasPlanet;
                case "Твердотельная планета":
                    SolidPlanet solidPlanet = (SolidPlanet)astrObject;
                    return solidPlanet;
                case "Комета":
                    Comet comet = (Comet)astrObject;
                    return comet;
         //       case "Астероид":
           //         GasPlanet gasPlanet = (GasPlanet)astrObject;
             //     return gasPlanet;
              //      break;
              //  default:
                //    break;
            }

            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(cmb.Text);

            List<AstronomicalObject> temp = new List<AstronomicalObject>();
            temp.Add(new Star());
            temp.Add(new SolidPlanet());
            temp.Add(new GasPlanet());
            temp.Add(new Comet());
            AstronomicalObject newObj = null;
   //         if (mode == 1)
     //       {
                newObj = setInfo(temp[cmb.SelectedIndex]);
                astronomicalObjects.Add(newObj);
            //  astronomicalObjects.
            txtBoxOutput.Lines = newObj.getObjectInfo();
       //     }
        }

        private string[] getInfo()
        {
            string[] str = null;
            List<TextBox> txtBox = new List<TextBox>();
            txtBox.Add(textBox1);
            txtBox.Add(textBox2);
            txtBox.Add(textBox3);
            txtBox.Add(textBox4);
            txtBox.Add(textBox5);
            txtBox.Add(textBox6);
            txtBox.Add(textBox7);
            int len = 1;
            for (int i = 0; i < 7; i++)
            {
                if (txtBox[i].Visible == true)
                {
                    Array.Resize<string>(ref str, len);
                    len++;
                    str[i] = txtBox[i].Text;
                }
            }
            return str;
        }
        private AstronomicalObject setInfo(AstronomicalObject obj)
        {
            string[] str = getInfo();
            obj.setParam(str);
            return obj;
        }
        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<AstronomicalObject> temp = new List<AstronomicalObject>();
            temp.Add(new Star());
            temp.Add(new SolidPlanet());
            temp.Add(new GasPlanet());
            temp.Add(new Comet());

            int i = 0;
            string[] str;
            List<Label> lbl = new List<Label>();
            lbl.Add(label1);
            lbl.Add(label2);
            lbl.Add(label3);
            lbl.Add(label4);
            lbl.Add(label5);
            lbl.Add(label6);
            lbl.Add(label7);

            List<TextBox> txtBox = new List<TextBox>();
            txtBox.Add(textBox1);
            txtBox.Add(textBox2);
            txtBox.Add(textBox3);
            txtBox.Add(textBox4);
            txtBox.Add(textBox5);
            txtBox.Add(textBox6);
            txtBox.Add(textBox7);

            str = temp[cmb.SelectedIndex].getNames();
            for (i = 0; i < 7; i++)
            {
                lbl[i].Visible = false;
                txtBox[i].Visible = false;
                txtBox[i].Clear();
            }

            for (i = 0; i < str.Length; i++)
            {
                lbl[i].Text = str[i];
                lbl[i].Visible = true;
                txtBox[i].Visible = true;
            } 
        }
    }
}
