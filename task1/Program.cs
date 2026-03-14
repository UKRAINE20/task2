using System;
using System.Collections.Generic;

namespace FactoryMetod
{
    public abstract class Subscription
    {
        public int Price;
        public int MinMonths;
        public string Channels;

        public void ShowInfo()
        {
            Console.WriteLine($"Price: {Price}, MinMonths: {MinMonths}, Channels: {Channels}");
        }

    }

    public class DomesticSubscription : Subscription
    {
        public DomesticSubscription()
        {
            Price = 120;
            MinMonths = 1;
            Channels = "Новини, Спорт";
        }
    }

    public class EducationalSubscription : Subscription
    {
        public EducationalSubscription()
        {
            Price = 100;
            MinMonths = 2;
            Channels = "Історія, Наука";
        }
    }
    public class PremiumSubscription : Subscription
    {
        public PremiumSubscription()
        {
            Price = 400;
            MinMonths = 6;
            Channels = "Всі канали, 4к якість";
        }
    }

    public abstract class Platform
    {

        public abstract Subscription CreateSubscription(string type);
    }

   
    public class WebSite : Platform
    {
        public override Subscription CreateSubscription(string type)
        {
            Console.WriteLine(" Купівля через Вебсайт:");

            if (type == "domestic") return new DomesticSubscription();
            if (type == "educational") return new EducationalSubscription();
            if (type == "premium") return new PremiumSubscription();

            return null;
        }
    }

    public class MobileApp : Platform
    {
        public override Subscription CreateSubscription(string type)
        {
            Console.WriteLine(" Купівля через Мобільний додаток (Apple Pay/Google Pay):");

            if (type == "domestic") return new DomesticSubscription();
            if (type == "educational") return new EducationalSubscription();
            if (type == "premium") return new PremiumSubscription();

            return null;
        }
    }

    public class ManagerCall : Platform
    {
        public override Subscription CreateSubscription(string type)
        {
            Console.WriteLine(" Купівля через Менеджера (перевірка даних):");

            if (type == "domestic") return new DomesticSubscription();
            if (type == "educational") return new EducationalSubscription();
            if (type == "premium") return new PremiumSubscription();

            return null;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 


            Platform site = new WebSite();
            Platform app = new MobileApp();
            Platform manager = new ManagerCall();

            Subscription sub1 = site.CreateSubscription("domestic");
            sub1.ShowInfo();
            Console.WriteLine(); 

            Subscription sub2 = app.CreateSubscription("educational");
            sub2.ShowInfo();
            Console.WriteLine();


            Subscription sub3 = manager.CreateSubscription("premium");
            sub3.ShowInfo();

            Console.ReadLine(); 
        }
    }

}