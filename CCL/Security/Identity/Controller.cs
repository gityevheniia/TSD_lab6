namespace CCL.Security.Identity
{
    public class Controller : User
    {
        public Controller(int userId, string name, string surname, string email)
            : base(userId, name, surname, email, nameof(Controller))
        {
        }
    }
}