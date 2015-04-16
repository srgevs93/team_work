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
            dateTimePicker1.Value = dateTimePicker1.MinDate;            
        }

        private void Date_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = new DateTime(1753, 01, 01);
            dateTimePicker1.MaxDate = new DateTime(3000, 12, 30);
            dateTimePicker1.Value = date;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            
            try
            {
                date = new DateTime();
                date = dateTimePicker1.Value;
                                
            }
            catch 
            {
                MessageBox.Show("Некорректный ввод. Попробуйте еще раз.");
            }
            
        }
        
    }
}
