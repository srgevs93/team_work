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
    public partial class Place : Form
    {
        public float lon;
        public float lat;
        public Place()
        {
            
            InitializeComponent();
            Save.DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                lon = Convert.ToSingle(textBox2.Text);
                lat = Convert.ToSingle(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод (например, точка вместо запятой в дробных числах). Попробуйте еще раз. ");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                Save.Enabled = false;
            }
            else
            {
                Save.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                Save.Enabled = false;
            }
            else
            {
                Save.Enabled = true;
            }
        }

        private void Place_Load(object sender, EventArgs e)
        {
            textBox1.Text = lat.ToString();
            textBox2.Text = lon.ToString();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox2.Text = "0";
            textBox1.Text = "0";
        }
    }
}
