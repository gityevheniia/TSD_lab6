using CCL.Security.Identity;
using System;

namespace CCL.Security
{
    public static class SecurityContext
    {
        private static User _currentUser = null;

        public static User GetUser()
        {
            if (_currentUser == null)
            {
                throw new InvalidOperationException("User is not set.");
            }
            return _currentUser;
        }

        public static void SetUser(User user)
        {
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
