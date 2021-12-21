using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace league_quotes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        textBox1.Visible = true;
                        textBox2.Visible = false;
                        label2.Visible = true;
                        label3.Visible = false;
                        button1.Visible = true;
                        button2.Visible = false;
                        button3.Visible = false;
                        break;
                    }
                case 1:
                    {
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        button1.Visible = false;
                        button2.Visible = true;
                        button3.Visible = false;
                        break;
                    }
                case 2:
                    {
                        textBox1.Visible = false;
                        textBox2.Visible = true;
                        label2.Visible = false;
                        label3.Visible = true;
                        button1.Visible = false;
                        button2.Visible = false;
                        button3.Visible = true;
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            treeView1.Visible = true;
            treeView1.Nodes.Clear();
            int i = -1;
            string n1, n2, line, champion="yes";
            Boolean k = true, exists = false;
            n1 = textBox1.Text;
            n2 = char.ToUpper(n1[0]) + n1.Substring(1);
            StreamReader sr = new StreamReader(Application.StartupPath + "\\quotes.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                if (line.StartsWith("."))
                {
                    champion = line;
                    k = true;
                    line = sr.ReadLine();
                }
                if (line.Contains(n1) || line.Contains(n2))
                {
                    if (k == true)
                    {
                        treeView1.Nodes.Add(champion.Substring(1));
                        k = false;
                        i++;
                    }
                    treeView1.Nodes[i].Nodes.Add(line);
                    exists = true;
                }
                line = sr.ReadLine();
            }
            sr.Close();
            if (exists == false)
                treeView1.Nodes.Add("Nobody says this word.");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            treeView1.Visible = true;
            treeView1.Nodes.Clear();
            string n1, n2, line, champion, currentChamp="doesnt`t matter";
            champion = textBox2.Text;
            champion = char.ToUpper(champion[0]) + champion.Substring(1);
            Boolean k = false,  exists = false; //k-false -> nu exista campionu ala
            n1 = textBox1.Text;
            n2 = char.ToUpper(n1[0]) + n1.Substring(1);
            StreamReader sr = new StreamReader(Application.StartupPath + "\\quotes.txt");
            line = sr.ReadLine();
            while(line != null)
            {
                if (line.StartsWith("."))
                {
                    currentChamp = line.Substring(1);
                    line = sr.ReadLine();
                }
                if(currentChamp == champion)
                {
                    k = true;
                    if (line.Contains(n1) || line.Contains(n2))
                    {
                        treeView1.Nodes.Add(line);
                        exists = true;
                    }
                }
                line = sr.ReadLine();
            }
            if (k == false)
                treeView1.Nodes.Add("This champion does not exist.");
            else
                if (exists == false)
                    treeView1.Nodes.Add("This champion doesn`t say that`.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            treeView1.Visible = true;
            treeView1.Nodes.Clear();
            string line, champion, currentChamp = "doesnt`t matter";
            champion = textBox2.Text;
            champion = char.ToUpper(champion[0]) + champion.Substring(1);
            Boolean k = false; //k-false -> nu exista campionu ala
            StreamReader sr = new StreamReader(Application.StartupPath + "\\quotes.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                if (line.StartsWith("."))
                {
                    currentChamp = line.Substring(1);
                    line = sr.ReadLine();
                }
                if (currentChamp == champion)
                {
                    k = true;
                    treeView1.Nodes.Add(line);
                }
                line = sr.ReadLine();
            }
            if (k == false)
                treeView1.Nodes.Add("This champion does not exist.");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(treeView1.SelectedNode.Text);
        }
    }
}
