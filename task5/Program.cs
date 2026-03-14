using System;
using System.Collections.Generic;

namespace BuilderExample
{

    public class Character
    {
        public string Name;
        public string Height;
        public string Build;
        public string HairColor;
        public string EyeColor;
        public string Clothing;
        public List<string> Inventory = new List<string>();
        public List<string> Deeds = new List<string>();

        public void ShowInfo()
        {
            Console.WriteLine($"Ім'я: {Name}");
            Console.WriteLine($"Зовнішність: {Height}, {Build} статура, волосся {HairColor}, очі {EyeColor}");
            Console.WriteLine($"Одяг: {Clothing}");
            Console.WriteLine($"Інвентар: {string.Join(", ", Inventory)}");
            Console.WriteLine($"Вчинки: \n - {string.Join("\n - ", Deeds)}");
            Console.WriteLine(new string('-', 40));
        }
    }


    public interface ICharacterBuilder
    {
        ICharacterBuilder SetName(string name);
        ICharacterBuilder SetHeight(string height);
        ICharacterBuilder SetBuild(string build);
        ICharacterBuilder SetAppearance(string hairColor, string eyeColor);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder AddInventory(string item);
        ICharacterBuilder AddDeed(string deed);
        Character GetResult();
    }


    public class HeroBuilder : ICharacterBuilder
    {
        private Character _hero = new Character();

        public ICharacterBuilder SetName(string name) { _hero.Name = name; return this; }
        public ICharacterBuilder SetHeight(string height) { _hero.Height = height; return this; }
        public ICharacterBuilder SetBuild(string build) { _hero.Build = build; return this; }
        public ICharacterBuilder SetAppearance(string hairColor, string eyeColor)
        {
            _hero.HairColor = hairColor;
            _hero.EyeColor = eyeColor;
            return this;
        }
        public ICharacterBuilder SetClothing(string clothing) { _hero.Clothing = clothing; return this; }
        public ICharacterBuilder AddInventory(string item) { _hero.Inventory.Add(item); return this; }

        public ICharacterBuilder AddDeed(string deed)
        {
            _hero.Deeds.Add($"[Добра справа] {deed}");
            return this;
        }

        public Character GetResult()
        {
            return _hero;
        }
    }

    public class EnemyBuilder : ICharacterBuilder
    {
        private Character _enemy = new Character();

        public ICharacterBuilder SetName(string name) { _enemy.Name = name; return this; }
        public ICharacterBuilder SetHeight(string height) { _enemy.Height = height; return this; }
        public ICharacterBuilder SetBuild(string build) { _enemy.Build = build; return this; }
        public ICharacterBuilder SetAppearance(string hairColor, string eyeColor)
        {
            _enemy.HairColor = hairColor;
            _enemy.EyeColor = eyeColor;
            return this;
        }
        public ICharacterBuilder SetClothing(string clothing) { _enemy.Clothing = clothing; return this; }
        public ICharacterBuilder AddInventory(string item) { _enemy.Inventory.Add(item); return this; }

        public ICharacterBuilder AddDeed(string deed)
        {
            _enemy.Deeds.Add($"[Зла справа] {deed}");
            return this;
        }

        public Character GetResult()
        {
            return _enemy;
        }
    }


    public class Director
    {
        public void ConstructDreamHero(ICharacterBuilder builder)
        {
            builder.SetName("Маг Ельдаріон")
                   .SetHeight("185 см")
                   .SetBuild("Струнка")
                   .SetAppearance("Сріблясте", "Смарагдові")
                   .SetClothing("Мантія зоряного світла")
                   .AddInventory("Посох істини")
                   .AddInventory("Зілля лікування")
                   .AddDeed("Врятував селище від гоблінів")
                   .AddDeed("Знайшов стародавній артефакт");
        }

        public void ConstructWorstEnemy(ICharacterBuilder builder)
        {
            builder.SetName("Лорд Морок")
                   .SetHeight("210 см")
                   .SetBuild("Кремезна")
                   .SetAppearance("Лисий", "Червоні")
                   .SetClothing("Шипована чорна броня")
                   .AddInventory("Проклятий меч")
                   .AddDeed("Спалив бібліотеку знань")
                   .AddDeed("Викрав принцесу");
        }
    }


    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Director director = new Director();

            Console.WriteLine(" СТВОРЕННЯ ГЕРОЯ МРІЇ ");
            ICharacterBuilder heroBuilder = new HeroBuilder();
            director.ConstructDreamHero(heroBuilder);
            Character myHero = heroBuilder.GetResult();
            myHero.ShowInfo();

            Console.WriteLine(" СТВОРЕННЯ НАЙЗАПЕКЛІШОГО ВОРОГА ");
            ICharacterBuilder enemyBuilder = new EnemyBuilder();
            director.ConstructWorstEnemy(enemyBuilder);
            Character myEnemy = enemyBuilder.GetResult();
            myEnemy.ShowInfo();

            Console.ReadLine();
        }
    }
}