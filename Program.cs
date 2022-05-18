using System;
using System.Collections.Generic;
using System.Linq;

namespace laba444
{
    class Program
    {
        class Shelter
        {
            public List<Pet> Allpets = new List<Pet>();


            public void Count()
            {
                int countdogs = 0;
                int countcats = 0;
                int countbirds = 0;
                foreach (Pet pet in Allpets)
                if (pet.GetType().Name == "Cat")
                    countcats++;
                else
                if (pet.GetType().Name == "Dog")
                    countdogs++;
                else
                if (pet.GetType().Name =="Bird")
                           countbirds++;
                else
                if(pet.GetType().Name == "Parrot")
                           countbirds++;
                Console.WriteLine("Всего животных - " + Allpets.Count);
                Console.WriteLine(new String('-', 50));
                Console.WriteLine("Колво птиц - " + countbirds + " " + 
                                  "Колво собак - " + countdogs + " " + 
                                  "Колво котов - " + countcats);
                Console.WriteLine(new String('-', 50));
            }

            public void Determine(List<Pet> Allpets)
            {
                foreach (Pet pet in Allpets)
                    Console.WriteLine("Животные в питомнике - " + pet.GetType().Name);
                Console.WriteLine(new String('-', 50));
            }

            public void Addpet(Pet pet)
            {
                Allpets.Add(pet);
            }

            public void DetermineType(Pet pet)
            {
                 Console.WriteLine("Тип вашего животного - " + pet.GetType().Name);
                Console.WriteLine(new String('-', 50));
            }
        }
        abstract class Pet  // Создаём абстрактный класс питомца
        {
            public void Breathe()  // создаём общий метод для всех питомцев
            {
                Console.WriteLine("Breathing");
            }

            public void Move()// создаём общий метод для всех питомцев
            {
                Console.WriteLine("Walking");
            }

            public void Sounds() // создаём общий метод для всех питомцев
            {
                Console.WriteLine("Sleeping");
            }

        }
        class Cat : Pet // Создаём класс кошкт и наследуем его от класса питомца

        {
            public Cat(string Name, int Age, int Weight)
            {
                name = Name;
                age = Age;                         // задаём характеристики кошке
                weight = Weight;
            }
            public string name { get; set; }
            public int age { get; set; }       // конструктор
            public int weight { get; set; }

            /// Текущий уровень насыщения
            public int CurrentSatietyState { get; set; }
            /// Максимальный уровень насыщения
            public int MaxSatietyState { get; set; }
            /// Необходимый уровень насыщения
            public int NecessarySaturationState { get; set; }

            public Cat() // создаём ещё одие класс кошки, для метода кормления кошки
            {
                //Задаем максимальный уровень насыщения
                MaxSatietyState = 200;
                Random r = new Random();
                //Задаем необходимый уровень насыщения
                NecessarySaturationState = r.Next(MaxSatietyState / 2, MaxSatietyState); //(random)
                //Задаем начальный уровень насыщения
                CurrentSatietyState = r.Next(1,
                    (MaxSatietyState - NecessarySaturationState) / 2 + NecessarySaturationState);
            }


            public enum Food  //класс с константами, в виде еды и значений
            {
                Мышь = 80,
                Молоко = 50,
                Мясо = 100,
                Китикэт = 90,
                Выход = 0
            }
            public string Eat(Food enter)  // метод ввода еды, доступной из класса Food
            {
                switch (enter)
                {
                    case Food.Мышь: return "Кот сожрал мышку";
                    case Food.Молоко: return "Кот выпил молоко, уровень сытости";
                    case Food.Мясо: return "Кот съел мясо, уровень сытости";
                    case Food.Китикэт: return "Кот заточил китикэт, уровень сытости";
                    default: return "";
                }
            }

            public void FeedCat()     // метод кормления кошки
            {

                Cat myCat = new Cat();
                Console.WriteLine("Максимальный уровень насыщения: {0}", myCat.MaxSatietyState);
                Console.WriteLine("Необходимый уровень насыщения: {0}", myCat.NecessarySaturationState);
                Console.WriteLine("Текущий уровень насыщения: {0}", myCat.CurrentSatietyState);
                Console.WriteLine("Для завершения кормления введите \"Выход\"");

                Food anyfood = Food.Молоко;
                do
                {                                                                                              // реализовуем кормление кошки
                    Console.WriteLine("Что хочет скушать кот?\n Мышь\n Молоко\n Мясо\n Китикэт");
                    string enter = Console.ReadLine();
                    anyfood = (Food)Enum.Parse(typeof(Food), enter);
                    myCat.CurrentSatietyState += Convert.ToInt32(anyfood);

                    Console.WriteLine(myCat.Eat(anyfood) + ", уровень сытости: " + myCat.CurrentSatietyState);

                    if (myCat.CurrentSatietyState > myCat.MaxSatietyState)
                    {
                        Console.WriteLine("Надо срочно худеть. Кот будет худеть? Да/Нет ");     // если кот хочет худеть, уровень сытости обнуляется 
                        var yes = Console.ReadLine();
                        if (yes == "Да")
                        {
                            myCat.CurrentSatietyState = 10;
                            Console.WriteLine("Уровень сытости: " + myCat.CurrentSatietyState);
                        }
                        else
                        {
                            anyfood = Food.Выход;
                        }
                    }
                } while (anyfood != Food.Выход);
            }
            public void Golos()
            {                                                // метод голоса кошки
                Console.WriteLine("Мяу мяу мяу мяу");
            }
        }


        class Dog : Pet // Создаём класс собаки и наследуем от питомца
        {
            public Dog(string Name, int Age, int Weight)
            {
                name = Name;                   // характеристики собаки
                age = Age;
                weight = Weight;
            }
            public string name { get; set; }
            public int age { get; set; }         // конструктор
            public int weight { get; set; }
            public void Golos() // метод голоса собаки
            {
                Console.WriteLine("Гав гав гав");
            }
            public void Duel(Dog dog, Cat cat) // метод дуели кошки и собаки
            {
                string winner;
                int PowerofDog = (dog.age * dog.weight) / 2;
                int PowerofCat = cat.age * cat.weight;
                if (PowerofCat < PowerofDog)
                {
                    winner = dog.name;
                    Console.WriteLine("Победитель дуели - " + dog.name + ", собака покусала кота");
                }
                else                                 // победитель определяется по характеристикам, которые умножаются у каждого животного
                if (PowerofCat > PowerofDog)
                {
                    winner = cat.name;
                    Console.WriteLine("Победитель дуели - " + cat.name + ", кот поцарапал собаку");
                }
                else
                    if (PowerofCat == PowerofDog)
                    Console.WriteLine("Из данной дуели не вышел победитель");
                else
                    Console.WriteLine("Error");
            }
        }

        class Bird : Pet // Создаём класс птицы и наследуем его от питомца
        {
            public string Fly() // метод полёта
            {
                Console.WriteLine("Если хотите испугать птицу введите 1, если не хотите, введите другое число");
                int i = Int32.Parse(Console.ReadLine());
                if (i == 1)
                {
                    string a = "птичка улетела";
                    Console.WriteLine(a);
                    return a;
                }
                else
                    return "";
            }


        }
        class Parrot : Bird // Создаём подкласс попугая, наследуя его от птицы
        {
            public Parrot(string Name, int Years, bool Spelling)
            {
                name = Name;
                years = Years;          // характеристика попугая
                spelling = Spelling;
            }
            public string name { get; set; }
            public int years { get; set; }      // конструктор попугая
            public bool spelling { get; set; }

            public void Spelling() // метод голоса попугая(попугай может повторять за вами)
            {
                if (spelling == true)
                {
                    Console.WriteLine("Введите слово, которое повторит " + name);
                    string yourword = Console.ReadLine();
                    Golos(yourword);
                }
                else                         // переменная spelling  в конструкторе
                if (spelling == false)
                {
                    Console.WriteLine(name + " не умеет повторять за человеком");
                }
                else
                    Console.WriteLine("не false/true");
                void Golos(string yourword)
                {
                    Console.WriteLine(name + " повторил " + yourword);
                }
                Console.WriteLine(new String('-', 50));

            }

        }

        static void Main(string[] args)
        {
            var shelter = new Shelter();

            var cat = new Cat("Марфа", 8, 5);
            shelter.Addpet(cat);
            Console.WriteLine("Имя кота - " + cat.name);
            Console.WriteLine("Возраст кота - " + cat.age + " лет");
            Console.WriteLine("Вес кота - " + cat.weight + " кг");
            cat.FeedCat();
            cat.Golos();
            Console.WriteLine(new String('-', 50));


            var dog = new Dog("Шарик", 12, 86);
            shelter.Addpet(dog);                          // Создаём объекты животных и применяем к ним методы из условия
            Console.WriteLine("Имя собаки - " + dog.name);
            Console.WriteLine("Возраст собаки - " + dog.age + " лет");
            Console.WriteLine("Вес собаки - " + dog.weight + " кг");
            dog.Golos();
            dog.Duel(dog, cat);
            Console.WriteLine(new String('-', 50));


            var parrot1 = new Parrot("Kesha", 3, true);
            shelter.Addpet(parrot1);
            Console.WriteLine("Имя попугая - " + parrot1.name);
            Console.WriteLine("Возраст попугая - " + parrot1.years);
            parrot1.Spelling();
            parrot1.Fly();

            shelter.DetermineType(dog);
            shelter.Determine(shelter.Allpets);
            shelter.Count();
        }


    }
}
