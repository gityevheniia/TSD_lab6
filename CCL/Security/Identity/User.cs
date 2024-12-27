namespace CCL.Security.Identity
{
    public abstract class User
    {
        public User(int userId, string name, string surname, string email, string userType)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
            UserType = userType;
        }

        public int UserId { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        protected string UserType { get; }
    }
}