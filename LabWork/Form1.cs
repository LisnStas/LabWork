using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            string[] listFlavors = File.ReadAllLines("Flavors.txt");
            foreach (var name in listFlavors)
            {
                string[] flavors = name.Split(' ');
                comboBox1.Items.Add(flavors[0]);
            }

            if (comboBox1.SelectedIndex == -1)
            {
                comboBox1.SelectedIndex = comboBox1.FindString("Vanilla");
            }

            listBox1.Items.AddRange(File.ReadAllLines("Toppings.txt"));

        }
               
        private void button1_Click(object sender, EventArgs e)
        {
            string value = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
                value = radioButton1.Text;
            else
                value = radioButton2.Text;


            if (comboBox1.SelectedItem == null)
            {
                return;
            }
            string comboBoxValue = comboBox1.SelectedItem.ToString();

            string allLine = "";
            foreach (String line in listBox1.SelectedItems)
            {
                allLine += line + Environment.NewLine;
            }

            string dateTime = DateTime.Now.ToString("dd'/'MM'/'yyyy");
            string appendText = $"{dateTime}{Environment.NewLine}{value}{Environment.NewLine}{comboBoxValue}{Environment.NewLine}{allLine}{Environment.NewLine}";
            File.AppendAllText("Orders.txt", appendText);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}