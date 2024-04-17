using System;
using System.Threading.Tasks;

namespace ProjectNotes.Services
{
    public class AuthService
    {
        // Event to notify when the user logs in
        public event EventHandler<UserLoggedInEventArgs> UserLoggedIn;

        // Simulated user database (replace with actual authentication logic)
        private bool _isLoggedIn;
        private string _loggedInUsername;

        public AuthService()
        {
            // Initialize any necessary properties or services
        }

        // Simulate user login (replace with actual authentication logic)
        public async Task<bool> LoginAsync(string username, string password)
        {
            // Validate credentials (e.g., check against a database)
            if (username == "yourusername" && password == "yourpassword")
            {
                _isLoggedIn = true;
                _loggedInUsername = username;
                UserLoggedIn?.Invoke(this, new UserLoggedInEventArgs(username));
                return true;
            }
            return false;
        }

        // Simulate user logout
        public void Logout()
        {
            _isLoggedIn = false;
            _loggedInUsername = null;
        }

        // Check if the user is logged in
        public bool IsLoggedIn => _isLoggedIn;

        // Get the currently logged-in username
        public string GetLoggedInUsername() => _loggedInUsername;
    }

    // Custom event arguments for user login
    public class UserLoggedInEventArgs : EventArgs
    {
        public string Username { get; }

        public UserLoggedInEventArgs(string username)
        {
            Username = username;
        }
    }
}
