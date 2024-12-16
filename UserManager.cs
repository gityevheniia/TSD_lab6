using ConsoleApp1;
using System;
using System.Collections.Generic;

namespace AccessControlSystem
{
    public class UserManager
    {
        private List<User> users = new List<User>();

        public void AddUser(int id, string name, string role)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Помилка: Ім'я не може бути порожнім!");
                return;
            }

            if (string.IsNullOrWhiteSpace(role))
            {
                Console.WriteLine("Помилка: Роль не може бути порожньою!");
                return;
            }

            users.Add(new User(id, name, role));
            Console.WriteLine("Користувача успішно додано!");
        }

        public void ListUsers()
        {
            Console.WriteLine("Список користувачів:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}
