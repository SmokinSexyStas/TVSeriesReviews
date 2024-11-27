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
using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.ViewModels;

namespace TVSeriesReviews.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataContext is HomeViewModel viewModel)
            {
                var listBox = sender as ListBox;
                if (listBox != null)
                {
                    viewModel.SelectedGenres.Clear();
                    foreach (var item in listBox.SelectedItems)
                    {
                        viewModel.SelectedGenres.Add(item as Genre);
                    }
                }
            }
        }
    }
}
