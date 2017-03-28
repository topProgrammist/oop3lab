using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;

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

        private void button1_Click(object sender, EventArgs e)
        {



            List<AstronomicalObject> temp = new List<AstronomicalObject>();
            temp.Add(new Star());
            temp.Add(new SolidPlanet());
            temp.Add(new GasPlanet());
            temp.Add(new Comet());
            AstronomicalObject newObj;
            newObj = setInfo(temp[cmb.SelectedIndex]);
            if (mode == 0)
            {
                astronomicalObjects.Add(newObj);
                listBox1.Items.Add(newObj.Name);
            }
            else
                astronomicalObjects[listBox1.SelectedIndex] = newObj;
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

        private void makeVisible(int index)
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

            str = temp[index].getNames();
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
        private void cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = 0;
            button1.Visible = true;
            button1.Text = "Добавить";
            txtBoxOutput.Visible = false;
            makeVisible(cmb.SelectedIndex);
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                astronomicalObjects.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                txtBoxOutput.Clear();
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            string[] str;
            txtBoxOutput.Visible = true;
            str = astronomicalObjects[listBox1.SelectedIndex].getObjectInfo();
            txtBoxOutput.Lines = str;

            foreach (var label in Controls.OfType<Label>())
            {
                label.Visible = false;
            }
            foreach (var TextBox in Controls.OfType<TextBox>())
            {
                if (TextBox != txtBoxOutput)
                    TextBox.Visible = false;
            }
            button1.Visible = false;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            mode = 1;
            button1.Visible = true;
            txtBoxOutput.Visible = false;
            List<AstronomicalObject> temp = new List<AstronomicalObject>();
            temp.Add(new Star());
            temp.Add(new SolidPlanet());
            temp.Add(new GasPlanet());
            temp.Add(new Comet());
            int index = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Object.ReferenceEquals(temp[i].GetType(), astronomicalObjects[listBox1.SelectedIndex].GetType()))
                    index = i;
            }
            makeVisible(index);
            button1.Text = "Изменить";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            astronomicalObjects.Clear();
                            listBox1.Items.Clear();
                            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<AstronomicalObject>));
                            List<AstronomicalObject> temp = (List<AstronomicalObject>)jsonFormatter.ReadObject(myStream);
                            astronomicalObjects = temp;
                            foreach (AstronomicalObject obj in astronomicalObjects)
                                listBox1.Items.Add(obj.Name);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("ОШИБКА");
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<AstronomicalObject>));
                    jsonFormatter.WriteObject(myStream, astronomicalObjects);
                    myStream.Close();
                }
            }
        }
    }
}
