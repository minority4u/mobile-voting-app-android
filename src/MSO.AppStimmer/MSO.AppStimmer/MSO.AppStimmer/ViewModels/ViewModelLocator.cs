/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MSO.AppStimmer"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MSO.AppStimmer.Services;
using MSO.AppStimmer.Views;
using MSO.AppStimmer.Views.Pages;

namespace MSO.AppStimmer.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigation = new NavigationService();
            navigation.Configure(PagesKeys.AppStimmer, typeof(AppStimmerPage));
            navigation.Configure(PagesKeys.AppStimmerEditor, typeof(AppStimmerEditorPage));
            navigation.Configure(PagesKeys.AppStimmers, typeof(AppStimmersPage));
            navigation.Configure(PagesKeys.Settings, typeof(SettingsPage));

            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            SimpleIoc.Default.Register<MainPageMasterViewModel>();
            SimpleIoc.Default.Register<AppStimmerViewModel>();
            SimpleIoc.Default.Register<AppStimmerEditorViewModel>();
            SimpleIoc.Default.Register<AppStimmersViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<CurrentUserViewModel>();

            SimpleIoc.Default.Register(() => navigation);
        }

        public MainPageMasterViewModel Master => ServiceLocator.Current.GetInstance<MainPageMasterViewModel>();

        public AppStimmerViewModel AppStimmer => ServiceLocator.Current.GetInstance<AppStimmerViewModel>();

        public AppStimmersViewModel AppStimmers => ServiceLocator.Current.GetInstance<AppStimmersViewModel>();

        public AppStimmerEditorViewModel AppStimmerEditor => ServiceLocator.Current.GetInstance<AppStimmerEditorViewModel>();

        public SettingsViewModel Settings => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        public CurrentUserViewModel CurrentUser => ServiceLocator.Current.GetInstance<CurrentUserViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}