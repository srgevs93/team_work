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
    public partial class Count : Form
    {
        public int count;
        public Count()
        {
            InitializeComponent();
            Save.DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                Save.Enabled = false;
            else
                Save.Enabled = true;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                count = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Некорректный ввод. Попробуйте еще раз.");
            }
        }

        private void Count_Load(object sender, EventArgs e)
        {
            textBox1.Text = count.ToString();
        }
    }
}
