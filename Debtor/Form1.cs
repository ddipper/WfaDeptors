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

namespace Debtor
{
    public partial class Form1 : Form
    {
        private List<Dolzhnik> dolzhniks = new List<Dolzhnik>();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dolzhnik deptor1 = new Dolzhnik(textBox1.Text, numericUpDown1.Value, DateTime.Now);
            listBox1.Items.Add(deptor1.Name);
            listBox2.Items.Add(deptor1.Dolg);
            listBox3.Items.Add(deptor1.Time);
            dolzhniks.Add(deptor1);
        
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
        }
        private void RewriteInfo()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            foreach(var dolzhnik in dolzhniks)
            {
                listBox1.Items.Add(dolzhnik.Name);
                listBox2.Items.Add(dolzhnik.Dolg);
                listBox3.Items.Add(dolzhnik.Time);
            }
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save deptors";
            saveFileDialog1.Filter = "txt files|*.txt|all files|*.*";
            saveFileDialog1.FileName = "Dolg.txt";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var dolzhnik in dolzhniks)
                        {
                            sw.WriteLine(dolzhnik);
                        }
                    }
                }
                MessageBox.Show("File save");
            }
        }

        private void openAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open deptors";
            openFileDialog1.Filter = "txt files|*.txt";
            openFileDialog1.FileName = "Dolg.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(openFileDialog1.FileName,FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            var boy = sr.ReadLine();
                            var boyPar = boy.Split('|');
                            var newDeptor = new Dolzhnik(boyPar[0], Convert.ToDecimal(boyPar[1]), Convert.ToDateTime(boyPar[2]));
                            dolzhniks.Add(newDeptor);
                        }
                        RewriteInfo();
                    }
                }
                MessageBox.Show("Open save");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox1.SelectedIndex;
            listBox3.SelectedIndex = listBox1.SelectedIndex;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
            listBox3.SelectedIndex = listBox2.SelectedIndex;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.SelectedIndex = listBox3.SelectedIndex;
            listBox1.SelectedIndex = listBox3.SelectedIndex;
        }
    }
}
