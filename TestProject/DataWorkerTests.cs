using TVSeriesReviews.WPF.Models;
using TVSeriesReviews.WPF.Models.Data;
using TVSeriesReviews.WPF.ViewModels;
using TVSeriesReviews.WPF.Views;

namespace TestProject
{
    [TestClass]
    public class DataWorkerTests
    {
        [TestMethod]
        public void GetCompleteTVShow_ReturnsTVShow_WhenIdExists()
        {
            // arrange
            int testId = 1;
            // act
            var result = DataWorker.GetCompleteTVShow(testId);
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(testId, result.Id);
            Assert.IsTrue(result.TVShowDirectors.Any());
            Assert.IsTrue(result.TVShowGenres.Any());
            Assert.IsTrue(result.TVShowActors.Any());
        }

        [TestMethod]
        public void GetCompleteTVShow_ReturnsNull_WhenIdDoesNotExist()
        {
            // arrange
            int nonExistentId = -1;
            // act
            var result = DataWorker.GetCompleteTVShow(nonExistentId);
            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsUserExists_ReturnsTrue_WhenUserExists()
        {
            // arrange
            User user = new User();
            user.Login = "test";
            user.Password = "qwerty12";
            // act
            bool result = DataWorker.IsUserExists(user);
            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsUserExists_ReturnsFalse_WhenUserDoesNotExist()
        {
            // arrange
            User user = new User();
            user.Login = "test";
            user.Password = "fakepassword";
            // act
            bool result = DataWorker.IsUserExists(user);
            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CreateUser_ReturnsTrue_WhenLoginDoesNotExist()
        {
            // arrange
            User user = new User();
            user.Login = "create_test";
            user.Password = "testpassword";
            // act
            bool result = DataWorker.CreateUser(user);
            // assert
            Assert.IsTrue(result);
            // cleanup
            DataWorker.DeleteUser(user);
        }

        [TestMethod]
        public void CreateUser_ReturnsFalse_WhenLoginExists()
        {
            // arrange
            User user = new User();
            user.Login = "test";
            user.Password = "testpassword";
            // act
            bool result = DataWorker.CreateUser(user);
            // assert
            Assert.IsFalse(result);
        }
    }

    //[TestClass]
    //public class HomeViewModelTests
    //{
    //    [TestMethod]
    //    public void SelectedTVShow_InvokesNavigateTVShowCommand()
    //    {
    //        // arrange
    //        var homeViewModel = new HomeViewModel();
    //        TVShow testShow = new TVShow { Id = 1 };

    //        bool commandExecuted = false;
    //        homeViewModel.NavigateTVShowCommand = new RelayCommand<TVShow>((_) => commandExecuted = true);

    //        // act
    //        homeViewModel.SelectedTVShow = testShow;

    //        // assert
    //        Assert.IsTrue(commandExecuted);
    //    }
    //}

    //[TestClass]
    //public class MainViewModelTests
    //{
    //    [TestMethod]
    //    public void NavigateTVShow_SetsCurrentViewToTVShowView_WhenTVShowExists()
    //    {
    //        // arrange
    //        var mainViewModel = new MainViewModel();
    //        TVShow testShow = new TVShow { Id = 1 };

    //        // act
    //        mainViewModel.NavigateTVShow(testShow);

    //        // assert
    //        Assert.IsInstanceOfType(mainViewModel.CurrentView, typeof(TVShowView));
    //    }

    //    [TestMethod]
    //    public void NavigateTVShow_SetsCurrentViewToErrorView_WhenTVShowIsNull()
    //    {
    //        // arrange
    //        var mainViewModel = new MainViewModel();

    //        // act
    //        mainViewModel.NavigateTVShow(null);

    //        // assert
    //        Assert.IsInstanceOfType(mainViewModel.CurrentView, typeof(ErrorView));
    //    }
    //}



}