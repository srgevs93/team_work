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
    public partial class Main : Form
    {
        DateTime data;   //дата наблюдений
        float lon=0;     //долгота
        float lat=0;     //широта
        int count = 100; //кол-во выводимых звезд
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void датаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Date date = new Date();
            date.date = new DateTime();
            date.date = data;
            date.ShowDialog();
            if (date.DialogResult == DialogResult.OK)
            {                
                data = date.date;
            }
        }

        private void местоположениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Place place = new Place();
            place.lat = lat;
            place.lon = lon;
            place.ShowDialog();
            if (place.DialogResult == DialogResult.OK)
            {
                lat = place.lat;
                lon = place.lon;
            }
        }

        private void фильтрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filters = new Filters();
            filters.Show();
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //показать...
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message =
        "Вы действительно хотите вывести на экран звездные объекты в данное время:"+
        data.ToString()+"\nВ месте с такими координатами Ш:"+lat.ToString()+" Д:"+
        lon.ToString()+"? \nКоличество объектов: "+count.ToString()
        +"\nИзменить выходные параметры можно на вкладке Данные главного меню.";
            const string caption = "Вычисления";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Calculate");
            }

        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clear all results");
        }

        private void количествоЗвездToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Count starCount = new Count();
            starCount.count = count;
            starCount.ShowDialog();
            if (starCount.DialogResult == DialogResult.OK)
            {
                count = starCount.count;
            }

        }

        private void руководствоПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Для просмотра звездных объектов, необходимо ввести следующие данные:"+
                "\nКоординаты и время наблюдений (вкладка Данные главного меню), количество звездных "+
                "объектов, выводимых на экран (вкладка Вид главного меню). Можно выбрать фильтры,"+
                "накладываемые на выборку объектов (вкладка Вид главного меню). Для сортировки"+
                " выводы откройте в главном меню Вид - Сортировка по... и выберите признак для сортировки."+
                "Сама операция выводов списка звездных объектов находится на вкладке Файл - показать.."+
                "Если сразу после запуска выбрать данное действие, все данные будут выбраны по умолчанию.";
            MessageBox.Show(message,"Руководство пользователя");
        }
    }
}
