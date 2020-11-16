using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб4
{
    // Главный общий класс
    public class Space 
    {
        //Поле для рандомного заполнения
        public static Random rnd = new Random();
        //Общее для комет, планет и звезд свойство - удаленность от Земли
        public int Distance = 0;
        //Возвращает удаленность от Земли
        public virtual String GetInfo()
        {
            var str = String.Format("\nУдаленность от Земли: {0}", this.Distance);
            return str;
        }
    }

    //Класс планет
    public class Planet : Space
    {
        public int Radius = 0; // Радиус
        public int Gravity = 0; // Сила притяжения
        public bool Atmosphere = false; // Наличие атмосферы
        //Информация о радиусе, силе притяжения и наличию атмосферы 
        public override String GetInfo()
        {
            var str = "Планета";
            str += base.GetInfo();
            str += String.Format("\nРадиус: {0}", this.Radius);
            str += String.Format("\nСила притяжения: {0}", this.Gravity);
            str += String.Format("\nНаличие атмосферы: {0}", this.Atmosphere);
            return str;
        }
        //Создание экземпляра класса "Планета"
        public static Planet Generate()
        {
            return new Planet
            {
                Distance = rnd.Next() % 100, // спелость от 0 до 100
                Radius = 10000 + rnd.Next() % 20000,
                Gravity = rnd.Next() % 100,
                Atmosphere = rnd.Next() % 2 == 0 // наличие листика true или false
            };
        }
    }

    //Класс звезд
    public class Star : Space
    {
        public int Density = 0; // Плотность
        public string Color = ""; // Цвет 
        public int Temperature = 0; // Температура
        public override String GetInfo()
        {
            var str = "Звезда";
            str += base.GetInfo();
            str += String.Format("\nПлотность: {0}", this.Density);
            str += String.Format("\nЦвет: {0}", this.Color);
            str += String.Format("\nТемпература: {0}", this.Temperature);
            return str;
        }
        //Создание экземпляра класса "Звезда"
        public static Star Generate()
        {
            return new Star
            {
                Distance = rnd.Next() % 100, 
                Density = 10000 + rnd.Next() % 20000,
                Color = RandomColor(),
                Temperature = 1000000 + rnd.Next() % 20000000 
            };
        }
        //Рандомная генерация цвета планеты
        public static string RandomColor()
        {
            string str = "";
            var rnd = new Random();
            {
                switch (rnd.Next() % 3)
                {
                    case 0:
                        str = "Белая";
                        break;
                    case 1:
                        str = "Желтая";
                        break;
                    case 2:
                        str = "Красная";
                        break;
                }
            }
            return str;
        }

    }

    //Класс комет
    public class Comet : Space
    {
        public int SolarSystemIntersection = 0; // Прохождение через солнечную систему
        public string Name = ""; // Имя
        public override String GetInfo()
        {
            var str = "Комета";
            str += base.GetInfo();
            str += String.Format("\nПериод прохождения через солнечную систему: {0}", this.SolarSystemIntersection);
            str += String.Format("\nИмя: {0}", this.Name);
            return str;
        }
        //Создание экземпляра класса "Комета"
        public static Comet Generate()
        {

            return new Comet
            {
                Distance = rnd.Next() % 100, // спелость от 0 до 100
                SolarSystemIntersection = 2000 + rnd.Next() % 3000,
                Name = RandomName(),
            };
        }

        //Рандомная генерация имени кометы
        public static string RandomName()
        {
            string str = "";
            var rnd = new Random();
            {
                switch (rnd.Next() % 3) 
                {
                    case 0: 
                        str = "Комета Лавджоя";
                        break;
                    case 1:
                        str = "Комета Макнота";
                        break;
                    case 2:
                        str = "Комета Лекселя";
                        break;
                }
            }
            return str;
        }
    }

  
}