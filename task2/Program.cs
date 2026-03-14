using System;

namespace AbstractFactoryExample
{

    public abstract class Laptop
    {
        public abstract void ShowInfo();
    }

    public abstract class Smartphone
    {
        public abstract void ShowInfo();
    }


    public class IProneLaptop : Laptop
    {
        public override void ShowInfo() =>
            Console.WriteLine(" - Ноутбук IProne MacBok: Дорогий, металевий, ідеально тягне важкий графічний дизайн (Photoshop, CorelDRAW).");
    }

    public class IProneSmartphone : Smartphone
    {
        public override void ShowInfo() =>
            Console.WriteLine(" - Смартфон IProne 15: Крута камера, статусний, але швидко сідає батарея.");
    }

    public class KiaomiLaptop : Laptop
    {
        public override void ShowInfo() =>
            Console.WriteLine(" - Ноутбук Kiaomi Book: Пластиковий, дешевий і сердитий. Чисто писати звіти в Word та рахувати в Excel.");
    }

    public class KiaomiSmartphone : Smartphone
    {
        public override void ShowInfo() =>
            Console.WriteLine(" - Смартфон Kiaomi Top: Топ за свої гроші, багато пам'яті, є інфрачервоний порт.");
    }

    public class BalaxyLaptop : Laptop
    {
        public override void ShowInfo() =>
            Console.WriteLine(" - Ноутбук Balaxy Pro: Хороший екран, надійний робочий апарат для лабораторії.");
    }

    public class BalaxySmartphone : Smartphone
    {
        public override void ShowInfo() =>
            Console.WriteLine(" - Смартфон Balaxy S24: Класний стилус, зручно малювати і писати нотатки.");
    }


    public abstract class TechFactory
    {
        public abstract Laptop CreateLaptop();
        public abstract Smartphone CreateSmartphone();
    }


    public class IProneFactory : TechFactory
    {
        public override Laptop CreateLaptop() => new IProneLaptop();
        public override Smartphone CreateSmartphone() => new IProneSmartphone();
    }

    public class KiaomiFactory : TechFactory
    {
        public override Laptop CreateLaptop() => new KiaomiLaptop();
        public override Smartphone CreateSmartphone() => new KiaomiSmartphone();
    }

    public class BalaxyFactory : TechFactory
    {
        public override Laptop CreateLaptop() => new BalaxyLaptop();
        public override Smartphone CreateSmartphone() => new BalaxySmartphone();
    }


    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Замовлення партії техніки IProne ===");
            // Створюємо фабрику IProne
            TechFactory appleFactory = new IProneFactory();
            // Вона робить нам девайси саме цього бренду
            Laptop myMac = appleFactory.CreateLaptop();
            Smartphone myIphone = appleFactory.CreateSmartphone();
            myMac.ShowInfo();
            myIphone.ShowInfo();

            Console.WriteLine("\n=== Замовлення партії техніки Kiaomi ===");
            TechFactory xiaomiFactory = new KiaomiFactory();
            Laptop myXiaomBook = xiaomiFactory.CreateLaptop();
            Smartphone myXiaomiPhone = xiaomiFactory.CreateSmartphone();
            myXiaomBook.ShowInfo();
            myXiaomiPhone.ShowInfo();

            Console.ReadLine();
        }
    }
}