using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSeriesReviews.WPF.Models;

namespace TVSeriesReviews.WPF.Services
{
    public class UserSessionService : IUserSessionService
    {
        private User? _currentUser;
        public User? CurrentUser
        {
            get => _currentUser;
            set
            {
                if (_currentUser != value)
                {
                    _currentUser = value;
                    UserChanged?.Invoke(_currentUser);
                }
            }
        }

        public event Action<User?> UserChanged;

        public void UpdateUser(User? user)
        {
            CurrentUser = user;
        }
    }
}
