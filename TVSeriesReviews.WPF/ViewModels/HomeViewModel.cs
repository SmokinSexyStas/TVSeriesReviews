using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.Models.Data;
using TVSeriesReviews.WPF.Views;
using TVSeriesReviews.WPF.ViewModels;
using System.Data.Entity;


namespace TVSeriesReviews.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<TVShow> TVShows { get; set; }
        public ObservableCollection<Genre> genres { get; set; } = new ObservableCollection<Genre>();
        private TVShow? _selectedTVShow;
        public TVShow? SelectedTVShow
        {
            get => _selectedTVShow;
            set
            {
                _selectedTVShow = value;
                OnPropertyChanged(nameof(SelectedTVShow));

                NavigateTVShowCommand.Execute(value);
            }
        }

        public ICommand NavigateTVShowCommand { get; set; }

        public HomeViewModel()
        {
            var shows = DataWorker.GetAllTVShows();
            TVShows = new ObservableCollection<TVShow>(shows);

            _selectedTVShow = null;

            NavigateTVShowCommand = new RelayCommand<TVShow>(NavigateTVShow);
        }

        private void NavigateTVShow(TVShow selectedShow)
        { 
            var mainViewModel = App.Current.MainWindow.DataContext as MainViewModel;
            mainViewModel?.NavigateTVShow(selectedShow);
        }
    }
}
