using com.calitha.goldparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parserProject
{
    public partial class Form1 : Form
    {
        MyParser P;
        public Form1()
        {
            InitializeComponent();
            P = new MyParser("hello1.cgt", listBox1, listBox2);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            P.Parse(textBox1.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
