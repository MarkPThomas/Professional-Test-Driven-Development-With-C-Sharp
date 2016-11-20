using System;
using Caliburn.Micro;

namespace OSIM.WinClient.ViewModels
{
    public interface ISignInViewModel
    {
        string Username { get; set; }
        string Password { get; set; }
        bool CanSignIn { get; }
        bool CanCancel { get; }
        string ErrorMessage { get; set; }
        void SignIn();
    }

    public class SignInViewModel : Screen, ISignInViewModel
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }

        public void SignIn() 
        {
            if (Username == "username" && Password == "password")
                ErrorMessage = string.Empty;
            else
                ErrorMessage = "Incorrect username or password.";
        }

        public bool CanSignIn
        {
            get { return ((!string.IsNullOrEmpty(Username)) && (!string.IsNullOrEmpty(Password))); }
        }

        public bool CanCancel
        {
            get { return true; }
        }
    }
}