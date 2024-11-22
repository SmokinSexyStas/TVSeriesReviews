using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVSeriesReviews.WPF.Models;

namespace TVSeriesReviews.WPF.Services
{
    public  interface IUserSessionService
    {
        User? CurrentUser { get; set; }
        event Action<User?> UserChanged;
        void UpdateUser(User? user);
    }
}
