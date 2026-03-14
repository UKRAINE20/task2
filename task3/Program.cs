using System;

namespace SingletonSimple
{
    // sealed забороняє наслідування 
    public sealed class Authenticator
    {
        //  Створюємо єдиний екземпляр ОДРАЗУ. 
        // C# сам гарантує, що це безпечно для потоків і створиться лише один раз.
        private static readonly Authenticator _instance = new Authenticator();

        //  Приватний конструктор, щоб ніхто не міг написати "new Authenticator()"
        private Authenticator()
        {
            Console.WriteLine(" Створено головний Authenticator!");
        }

        //  Простий метод, який просто віддає вже готовий екземпляр
        public static Authenticator GetInstance()
        {
            return _instance;
        }


        public void Login(string username)
        {
            Console.WriteLine($"Користувач '{username}' успішно увійшов.");
        }
    }


    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Спроба 1...");
            Authenticator auth1 = Authenticator.GetInstance();
            auth1.Login("Студент");

            Console.WriteLine("\nСпроба 2...");
            Authenticator auth2 = Authenticator.GetInstance();
            auth2.Login("Викладач");

            Console.WriteLine("\nПеревірка:");
            if (auth1 == auth2)
            {
                Console.WriteLine("Успіх! Це один і той самий об'єкт. Одинак працює ідеально.");
            }

            Console.ReadLine();
        }
    }
}