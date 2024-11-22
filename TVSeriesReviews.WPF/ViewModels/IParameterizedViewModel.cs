using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVSeriesReviews.WPF.ViewModels
{
    public interface IParameterizedViewModel
    {
        void Initialize(object parameter);
    }
}
