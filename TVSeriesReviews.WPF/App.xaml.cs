using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using TVSeriesReviews.WPF.ViewModels;
using Prism.DryIoc;
using Prism.Ioc;
using TVSeriesReviews.WPF.Views;
using TVSeriesReviews.WPF.Services;

namespace TVSeriesReviews.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return ContainerLocator.Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // events registration
            containerRegistry.RegisterSingleton<IUserSessionService, UserSessionService>();

            // nav registration
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
            containerRegistry.RegisterForNavigation<TVShowView, TVShowViewModel>();
            containerRegistry.RegisterForNavigation<AuthorizationView, AuthorizationViewModel>();
            containerRegistry.RegisterForNavigation<RegistrationView, RegistrationViewModel>();
            containerRegistry.RegisterForNavigation<ErrorView, ErrorViewModel>();
            containerRegistry.RegisterForNavigation<HeaderView, HeaderViewModel>();
            containerRegistry.RegisterForNavigation<UserProfileView, UserProfileViewModel>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var regionManager = ContainerLocator.Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion<HomeView>("ContentRegion");
            regionManager.RegisterViewWithRegion<HeaderView>("HeaderRegion");
        }

    }

}
