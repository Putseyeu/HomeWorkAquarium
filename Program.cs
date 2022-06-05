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
                    Console.Write($"\n{i+1} Рыба {_fishs[i].Name} ");

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

            string userInput =Console.ReadLine();
            if (int.TryParse(userInput, out int intValue))
            {
                intValue--;
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
               _fishs[i].SkipDaysLife(_fishs[i].DaysLife);
            }
        }
    }

    class Fish
    {
        private Dictionary<string, int> _fish = new Dictionary<string, int>();
        public string Name { get; private set; }
        public int DaysLife { get; private set; }

        public Fish()
        {
            CreatingFishLibrary();
            SetName();
            GetDaysLife(Name);
        }

        public void SkipDaysLife(int daysLife)
        {
            daysLife--;
            DaysLife = daysLife;
            return;
        }

        private void CreatingFishLibrary()
        {
            _fish.Add("Акантодорас", 3240);
            _fish.Add("Бетта", 1080);
            _fish.Add("Бычок", 1800);
            _fish.Add("Нанностомус",5);
        }

        private void SetName()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine($"Выбирите рыбу которую хотите добавить в аквариум.");
                ShowInfoFish();
                string userInput = Console.ReadLine();

                if (_fish.ContainsKey(userInput))
                {
                    Name = userInput;
                    done = true;
                }
                else
                {
                    Console.WriteLine($"{userInput}  с таким название рыбы нету");
                }
            }           
        }

        private void GetDaysLife(string name)
        {
            if (_fish.ContainsKey(name))
            {
                DaysLife = _fish[name];
            }
        }

        private void ShowInfoFish()
        {
            Console.WriteLine();
            foreach (var fish in _fish)
            {
                Console.WriteLine($"Название рыбы {fish.Key} : продолжительность жизни { fish.Value} дней");                
            }
        }
    }
}
