using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace jinxianzhi
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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            common.n = 1;

            if (this.tbYear.Text.Trim().ToString() == "")
                MessageBox.Show("年份不能为空！", "提示");
            else
            {
                int num = int.Parse(this.tbYear.Text.Trim().ToString());
                common.num = num;
                //添加文本控件

                string name = "txt";

                for (int i = 1; i <= num; i++)
                {
                    TextBox txt = new TextBox();
                    Button but = new Button();
                    Label la = new Label();
                    txt.Name = "tt" + name + i;
                    but.Name = "t" + name + i;
                    la.Name = "t" + name + i;
                    la.Height = 30;
                    la.Width = 65;
                    la.Font = new Font("宋体", 13);
                    but.Font = new Font("宋体", 11);
                    but.Height = 22;
                    //txt.Text = "tt" + name + i;
                    la.Location = new Point(12, 15 + i * 30);
                    txt.Location = new Point(80, 15 + i * 30);
                    but.Location = new Point(200, 15 + i * 30);
                    but.Text = "清空";
                    la.Text = "第" + i + "年";
                    but.MouseClick += new MouseEventHandler(DelButton_Click);
                    pYear.Controls.Add(la);
                    pYear.Controls.Add(txt);
                    pYear.Controls.Add(but);
                }
            }
      

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }
        private void DelButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String name = "t" +  btn.Name;

            foreach (Control c in this.pYear.Controls)
            {
                if (c is TextBox && c.Name == name)
                {
                    TextBox temp = c as TextBox;
                    //temp.Text = "0000";
                    temp.Clear();

                }
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pYear.Controls.Clear();
            
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pYear_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ssssss = 0;

            if (tbYear.Text.Trim().ToString() == "")
                MessageBox.Show("年份不能为空！", "提示");

            else if (common.n == 0)
                MessageBox.Show("年利润不能为空！点击确认！", "提示");

            for (int i = 1; i <= common.num; i++)
            {
                
                foreach (Control c in this.pYear.Controls)
                {
                    if (c is TextBox && c.Name == "tttxt" + i)
                    {
                        TextBox temp = c as TextBox;
                        if (temp.Text.Trim().ToString() == "")
                        {
                            MessageBox.Show("第" + i + "年的利润不能为空！", "提示");
                            ssssss = 1;
                        }
                            
                      
                    }
                }
            }
                if (ssssss == 0 && common.n == 1)
                {
                    ListBox list1 = this.listBox1;

                    if (tbGai.Text.Trim().ToString() == "")
                        MessageBox.Show("贴现率不能为空！", "提示");
                    else
                    {
                        float gai = float.Parse(tbGai.Text.Trim().ToString());
                        float state = 1;
                        float zong = 0;
                        for (int ii = 1; ii <= common.num; ii++)
                        {
                            for (int j = 0; j < ii; j++)
                                state = state * (1 + gai);
                            foreach (Control cc in this.pYear.Controls)
                            {
                                if (cc is TextBox && cc.Name == "tttxt" + ii)
                                {
                                    TextBox tempp = cc as TextBox;

                                    float lirun = float.Parse(tempp.Text.Trim().ToString());
                                    float tiexianyinzi=1;
                                    for (int xun = 0; xun < ii; xun++)
                                    { tiexianyinzi = tiexianyinzi/(1 + gai); }
                                    float tiexian = lirun  * tiexianyinzi;
                                    //float tiexian = lirun * (1 / state);
                                    zong = zong + tiexian;
                                    list1.Items.Add("第" + ii + "年:    " + tempp.Text.Trim().ToString() + "元   贴现因子为"+tiexianyinzi+"   净现值:    " + tiexian + "元");

                                }
                            }

                        }
                        list1.Items.Add(common.num + "年的总净现值为:    " + zong + "元");
                        list1.Items.Add("************************************************");
                    }
                }
          

           


     
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
