using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TVSeriesReviews.WPF.ViewModels;
using TVSeriesReviews.WPF.Models;

namespace TVSeriesReviews.WPF.Views
{
    /// <summary>
    /// Interaction logic for TVShowView.xaml
    /// </summary>
    public partial class TVShowView : UserControl
    {
        public TVShowView(TVShow selectedShow)
        {
            InitializeComponent();
            DataContext = new TVShowViewModel(selectedShow);
        }
    }
}
