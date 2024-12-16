namespace ConsoleApp1
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        public User(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Role: {Role}";
        }
    }
}
