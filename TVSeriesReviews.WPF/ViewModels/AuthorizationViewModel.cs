using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.Models.Data;

namespace TVSeriesReviews.WPF.ViewModels
{
    public class AuthorizationViewModel : ViewModelBase
    {
        private User? _user;
        public User? User { get { return _user; } set { _user = value; } }
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value; 
                OnPropertyChanged(nameof(Login));
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand AuthorizeUserCommand {  get; set; }

        public AuthorizationViewModel()
        {
            _login = string.Empty;
            _password = string.Empty;
            _errorMessage = string.Empty;

            AuthorizeUserCommand = new RelayCommand(AuthorizeUser);
        }

        private void AuthorizeUser()
        {
            _user = new User { Login = _login, Password = _password };
            if (DataWorker.IsUserExists(_user))
            {
                ErrorMessage = string.Empty;
                NavigateHomeCommand.Execute(null);
            }
            else
            {
                ErrorMessage = "Authorization error";
            }
        }
    }
}
