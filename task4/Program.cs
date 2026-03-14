using System;

namespace SimplePrototype
{
    
    public class Virus
    {
        public int Weight;
        public int Age;
        public string Name;
        public string Species;

        // Звичайний масив для дітей
        public Virus[] Children;

        // Конструктор для швидкого заповнення даних
        public Virus(int weight, int age, string name, string species)
        {
            Weight = weight;
            Age = age;
            Name = name;
            Species = species;
        }

        // 2. Метод клонування (Прототип)
        public Virus Clone()
        {
            //  Створюємо копію самого себе з тими ж даними
            Virus copy = new Virus(Weight, Age, Name, Species);

            //  Якщо у віруса є діти, їх ТЕЖ треба скопіювати
            if (Children != null)
            {
                // Створюємо порожній масив такого ж розміру
                copy.Children = new Virus[Children.Length];

                // Проходимось по кожній дитині і просимо її скопіювати себе
                for (int i = 0; i < Children.Length; i++)
                {
                    copy.Children[i] = Children[i].Clone();
                }
            }

            return copy;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            // 3-тє покоління: Син
            Virus child = new Virus(1, 1, "Син", "Грип");

            // 2-ге покоління: Батько
            Virus parent = new Virus(2, 5, "Батько", "Грип");
            parent.Children = new Virus[] { child }; // Додаємо сина в масив батька

            // 1-ше покоління: Дідусь
            Virus grandParent = new Virus(3, 10, "Дідусь", "Грип");
            grandParent.Children = new Virus[] { parent }; // Додаємо батька в масив дідуся


            Virus cloneGrandParent = grandParent.Clone();



            Console.WriteLine("--- До зміни ---");
            Console.WriteLine($"Оригінал (Дідусь): {grandParent.Name}, його дитина: {grandParent.Children[0].Name}");
            Console.WriteLine($"Клон (Дідусь): {cloneGrandParent.Name}, його дитина: {cloneGrandParent.Children[0].Name}");

            // Міняємо ім'я дитині КЛОНА. Якщо все правильно, оригінал не зміниться.
            cloneGrandParent.Children[0].Name = "Клон-Батько";

            Console.WriteLine("\n--- Після зміни імені клону ---");
            Console.WriteLine($"Оригінал (Дідусь): {grandParent.Name}, його дитина: {grandParent.Children[0].Name} (не змінився!)");
            Console.WriteLine($"Клон (Дідусь): {cloneGrandParent.Name}, його дитина: {cloneGrandParent.Children[0].Name}");

            Console.ReadLine();
        }
    }
}