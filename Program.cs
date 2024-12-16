using ConsoleApp1;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager();

            while (true)
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1. Додати користувача");
                Console.WriteLine("2. Переглянути список користувачів");
                Console.WriteLine("3. Вихід");
                Console.Write("Оберіть дію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Введіть ім'я: ");
                        string name = Console.ReadLine();
                        Console.Write("Введіть роль: ");
                        string role = Console.ReadLine();

                        userManager.AddUser(id, name, role);
                        break;

                    case "2":
                        userManager.ListUsers();
                        break;

                    case "3":
                        Console.WriteLine("Завершення роботи...");
                        return;

                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
