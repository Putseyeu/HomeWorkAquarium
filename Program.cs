using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkAkwarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Управление аквариумом");
            Aquarium aquarium = new Aquarium();
            string userInput = "";

            while (userInput != "0")
            {
                aquarium.ShowInfo();
                Console.WriteLine("\nВыбериет действие " +
                    "1 - Добавить рыбу " +
                    "2 - Убрать рыбу " +
                    "3 - Следующий день " +
                    "0 - закрыть приложение.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        break;

                    case "1":
                        aquarium.AddFish();
                        break;

                    case "2":
                        aquarium.DeleteFish();
                        break;

                    case "3":
                        aquarium.SkipDays();
                        break;
                }
            }
        }
    }

    class Aquarium
    {
        private List<Fish> _fishs = new List<Fish>();
        private int _maxNumberFishs = 10;

        public void AddFish()
        {
            if (_fishs.Count < _maxNumberFishs)
            {
                _fishs.Add(new Fish());
            }
            else
            {
                Console.WriteLine("Превышено допустимое коичесвтво рыб в аквариуме " + _maxNumberFishs);
            }
        }

        public void ShowInfo()
        {
            if (_fishs.Count > 0)
            {
                Console.WriteLine("\nВ аквариуме сейчас ");

                for (int i = 0; i < _fishs.Count; i++)
                {
                    Console.Write($"\n{i + 1} Рыба {_fishs[i].Name} ");

                    if (_fishs[i].DaysLife > 0)
                    {
                        Console.Write($"которой еще жить {_fishs[i].DaysLife} дней");
                    }
                    else
                    {
                        Console.Write("cдохла");
                    }
                }
            }
            else
            {
                Console.WriteLine("Аквариум пуст");
            }
        }

        public void DeleteFish()
        {
            Console.WriteLine("Введите номер рыбы из списка, для удаления из аквариума");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int intValue))
            {
                intValue -= 1;
                if (intValue > 0)
                {
                    _fishs.RemoveAt(intValue);
                }
            }
            else
            {
                Console.WriteLine("Не верный ввод");
            }
        }

        public void SkipDays()
        {
            for (int i = 0; i < _fishs.Count; i++)
            {
                _fishs[i].SkipDaysLife();
            }
        }
    }

    class Fish
    {
        public string Name { get; private set; }
        public int DaysLife { get; private set; }

        public Fish()
        {
            SetName();
            SetDaysLife();
        }

        public void SkipDaysLife()
        {
            int numberDays = 1;
            DaysLife -= numberDays;
        }

        private void SetName()
        {
            Console.WriteLine($"Введите название рыбы которую добовляеет в аквариум.");
            Name = Console.ReadLine();
        }

        private void SetDaysLife()
        {
            Console.WriteLine($"Введите среднее количество дней жизни рыбы.");
            bool done = false;

            while (done != true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int intValue))
                {
                    DaysLife = intValue;
                    done = true;                   
                }
                else
                {
                    Console.WriteLine("Не коректный вод данных. Повторите.");
                }
            }
        }
    }
}
