namespace CCL.Security.Identity
{
    public class SecurityOfficer : User
    {
        public SecurityOfficer(int userId, string name, string surname, string email)
            : base(userId, name, surname, email, nameof(SecurityOfficer))
        {
        }
    }
}