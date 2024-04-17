using System;
using System.Windows.Input;
using ProjectNotes.Commands;
using ProjectNotes.Services;

namespace ProjectNotes.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly AuthService AuthService;

        public LoginViewModel()
        {
            AuthService = AuthService.Instance; // Use the singleton instance (or inject it via dependency injection)
            LoginCommand = new RelayCommand(Login, CanLogin);
        }

        // Properties for binding
        public string Username { get; set; }
        public string Password { get; set; }

        // Command for login button
        public ICommand LoginCommand { get; }

        private bool CanLogin(object parameter) => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);

        private async void Login(object parameter)
        {
            try
            {
                bool isAuthenticated = await AuthService.LoginAsync(Username, Password);
                if (isAuthenticated)
                {
                    // User logged in successfully
                    // You can navigate to another view or update UI accordingly
                    // For example:
                    // NavigationService.NavigateTo<OverviewScreenViewModel>();
                }
                else
                {
                    // Show an error message (invalid credentials, etc.)
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., network errors, database issues)
                // Log or display the error message
            }
        }
    }  
}
