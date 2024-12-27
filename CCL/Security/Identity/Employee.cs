using System;

namespace CCL.Security.Identity
{
    public class Employee : User
    {
        public Employee(int userId, string name, string surname, string email)
            : base(userId, name, surname, email, nameof(Employee))
        {
        }
    }
}