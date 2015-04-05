using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace team_work
{
    public partial class Date : Form
    {
        public DateTime date;
        public bool save = false;
        public Date()
        {
            InitializeComponent();
            OK.DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        private void Clear_Click(object sender, EventArgs e)
        {
            textBox6.Text = "0";
            textBox5.Text = "0";
            textBox4.Text = "0";
            textBox3.Text = "1";
            textBox2.Text = "1";
            textBox1.Text = "1";
        }

        private void Date_Load(object sender, EventArgs e)
        {
            textBox1.Text = date.Day.ToString();
            textBox2.Text = date.Year.ToString();
            textBox3.Text = date.Month.ToString();
            textBox4.Text = date.Hour.ToString();
            textBox5.Text = date.Minute.ToString();
            textBox6.Text = date.Second.ToString();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            
            string Year = textBox2.Text;
            string Month = textBox3.Text;
            string Day = textBox1.Text;
            string Hour = textBox4.Text;
            string Min = textBox5.Text;
            string Sec = textBox6.Text;
            try
            {
                date = new DateTime(Convert.ToInt32(Year),
                    Convert.ToInt32(Month), Convert.ToInt32(Day), Convert.ToInt32(Hour),
                    Convert.ToInt32(Min), Convert.ToInt32(Sec));
                
            }
            catch 
            {
                MessageBox.Show("Некорректный ввод. Попробуйте еще раз.");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                OK.Enabled = false;
            else
                OK.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                OK.Enabled = false;
            else
                OK.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                OK.Enabled = false;
            else
                OK.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                OK.Enabled = false;
            else
                OK.Enabled = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
                OK.Enabled = false;
            else
                OK.Enabled = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
                OK.Enabled = false;
            else
                OK.Enabled = true;
        }
    }
}
