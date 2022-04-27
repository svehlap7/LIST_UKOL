using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIST_UKOL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> list = new List<int>();
        private bool prvocislo(int cisla)
        {
            if (cisla < 2)
            {
                return false;
            }

            if (cisla % 2 == 0 && cisla != 2)
            {
                return false;
            }

            for (int delitel = 3; delitel <= Math.Sqrt(cisla); delitel += 2)
            {
                if (cisla % delitel == 0)
                {
                    return false;
                }

            }
            return true;
        }

        private void Vypis(List<int> list, ListBox l)
        {
            listBox1.Items.Clear();
            foreach (int item in list)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cisla = 0;
            int n = Convert.ToInt32(textBox1.Text);
            Random random1 = new Random();

            for (int i = 0; i < n; i++)
            {
                list.Add(random1.Next(20, 30));

            }
            Vypis(list, listBox1);
            int maxi = list.Max();
            MessageBox.Show("MAX cislo je: " + maxi);
            MessageBox.Show("Prvni poradi MAX cisla je: " + list.IndexOf(maxi));
            MessageBox.Show("Posledni poradi MAX cisla je: " + list.LastIndexOf(maxi));
            MessageBox.Show("Prumer vsech cisel je: " + list.Average());

            bool xyz = false;
            foreach (int x in list)
            {
                if (prvocislo(x))
                {
                    cisla = x;
                    xyz = true;
                    break;
                }
            }

            if (xyz)
            {
                MessageBox.Show("Prvni prvocislo je: " + cisla);
            }
            else
            {
                MessageBox.Show("NENI PRVOCISLO!");
            }

            list = list.Distinct().ToList();
            Vypis(list, listBox1);
        }
    }
}
