using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб4
{
    public partial class Form1 : Form
    {
        // Динамический массив типа Space
        List<Space> spaceList = new List<Space>();

        public Form1()
        {
            InitializeComponent();
        }

        // Кнопка "Перезаполнить"
        private void btnRefill_Click(object sender, EventArgs e)
        {
            this.spaceList.Clear();
            // Рандомное заполнение динамического массива объектами классов планета, звезда и комета
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3) //Генерируется случайное число от 0 до 2
                {
                    case 0: // если 0, то планета
                        this.spaceList.Add(Planet.Generate());
                        break;
                    case 1: // если 1 то звезда
                        this.spaceList.Add(Star.Generate());
                        break;
                    case 2: // если 2 то комета
                        this.spaceList.Add(Comet.Generate());
                        break;
                }
            }

            ShowInfo();
            SpaceList();
        }

        //Информация о количестве объектов в автомате
        private void ShowInfo()
        {
            //Счетчики под каждый тип
            int planetCount = 0;
            int starCount = 0;
            int cometCount = 0;

            //Пройдемся по всему списку
            foreach (var space in this.spaceList)
            {
                // Проверяем что объект space является планетой, звездой или кометой
                // Используем ключевое слово is
                if (space is Planet) //Читается как "если space есть Планета"
                {
                    planetCount += 1;
                }
                else if (space is Star)
                {
                    starCount += 1;
                }
                else if (space is Comet)
                {
                    cometCount += 1;
                }
            }

            //Выводим информацию в форму
            txtInfo.Text = "Планеты\tЗвезды\tКометы";
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t{1}\t{2}", planetCount, starCount, cometCount);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //Если список пуст, то напишем что пусто и выйдем из функции
            if (this.spaceList.Count == 0)
            {
                txtOut.Text = "Автомат пуст";
                return;
            }

            // Взяли первое комическое тело
            var space = this.spaceList[0];
            // Взятие это на самом деле создание указателя на область в памяти
            // где хранится экземпляр класса, так что удаление надо прописать отдельно
            this.spaceList.RemoveAt(0);
            txtOut.Text = space.GetInfo();
            if (space is Planet) //Читается как "если space есть Планета"
            {
                pictureBox1.Image = Properties.Resources._1_2;
            }
            if (space is Star)
            {
                pictureBox1.Image = Properties.Resources._1_3;
            }
            if (space is Comet)
            {
                pictureBox1.Image = Properties.Resources._1_4;
            }
            //Обновим информацию о количестве товара на форме
            ShowInfo();
            SpaceList();
        }
        private void SpaceList()
        {
            richTextBox1.Text = "";
            for (var i = 0; i < this.spaceList.Count; ++i)
            {
                var space = this.spaceList[i];
                if (space is Planet)
                {
                    richTextBox1.Text = richTextBox1.Text + ("\n Планета");
                }
                if (space is Star)
                {
                    richTextBox1.Text = richTextBox1.Text + ("\n Звезда");
                }
                if (space is Comet)
                {
                    richTextBox1.Text = richTextBox1.Text + ("\n Комета"); ;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 examp = new Form2();
            examp.Show();
        }
    }
}
