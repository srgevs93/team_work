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
        DateTime data = DateTime.Now;   //дата наблюдений
        float lon=0;     //долгота
        float lat=0;     //широта
        int count = 100; //кол-во выводимых звезд
        List<SpacePoint> list;
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
        //
        //показать...
        //
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
                SpacePoint sp = new SpacePoint(0, lat, 8);
                //if (list.Count != 0)         list.Clear();
                list = Query.QuerySkyMap(sp, 120, count);
                ShowList();
            }

        }

        private void ShowList()
        {
            // Shutdown the painting of the ListBox as items are added.
            listBox1.BeginUpdate();
            listBox1.Items.Add("CatID \t ID \t Magnitude");
            for (int i = 0; i < list.Count; i++)
            {
                listBox1.Items.Add(list[i].CatID.ToString() + " \t" + list[i].ID.ToString() +
                    " \t" + list[i].Magnitude.ToString()+" \t"+list[i].RA.ToString()+
                    " \t" +list[i].DE.ToString());
            }
            // Allow the ListBox to repaint and display the new items.
            listBox1.EndUpdate();
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Info = listBox1.SelectedItem.ToString();
            string[] words = Info.Split('\t');
            label1.Text = "Информация и звезде: \n Номер в каталоге: "+words[0] +
                " \n Звездная величина: "+words[2]+ "\n RA="+words[3]+"\n "+words[4];
        }

        private void звезднойВеличинеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            звезднойВеличинеToolStripMenuItem.Checked = true;
            координатамToolStripMenuItem.Checked = false;
            поАлфавитуToolStripMenuItem.Checked = false;
            
        }

        private void координатамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            координатамToolStripMenuItem.Checked = true;
            поАлфавитуToolStripMenuItem.Checked = false;
            звезднойВеличинеToolStripMenuItem.Checked = false;
        }

        private void поАлфавитуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            поАлфавитуToolStripMenuItem.Checked = true;
            координатамToolStripMenuItem.Checked = false;
            звезднойВеличинеToolStripMenuItem.Checked = false;
        }
    }
}
