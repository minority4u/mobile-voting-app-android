/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MSO.StimmApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MSO.StimmApp.Core.Services;
using MSO.StimmApp.Services;
using MSO.StimmApp.Views;
using MSO.StimmApp.Views.Pages;

namespace MSO.StimmApp.ViewModels
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
            navigation.Configure(PagesKeys.AddAttachmentPopup, typeof(AddAttachmentPopupPage));

            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            if (App.IsTestMode)
            {
                SimpleIoc.Default.Register<IAppStimmerService, MockAppStimmerService>();
            }
            else
            {
                //SimpleIoc.Default.Register<IAppStimmerService, RestAppstimmerService>();
            }

            SimpleIoc.Default.Register<MenuPageMasterViewModel>();
            SimpleIoc.Default.Register<AppStimmerViewModel>();
            SimpleIoc.Default.Register<AppStimmerEditorViewModel>();
            SimpleIoc.Default.Register<AppStimmersViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<CurrentUserViewModel>();


            SimpleIoc.Default.Register(() => navigation);
        }

        public MenuPageMasterViewModel Master => ServiceLocator.Current.GetInstance<MenuPageMasterViewModel>();

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