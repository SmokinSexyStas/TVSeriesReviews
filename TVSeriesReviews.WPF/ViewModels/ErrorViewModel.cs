using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesReviews.WPF.ViewModels
{
    class ErrorViewModel : ViewModelBase
    {
        private string _errorText;
        public string ErrorText { get => _errorText; set => _errorText = value; }
        public ErrorViewModel()
        {
            ErrorText = "Error";
        }
    }
}
