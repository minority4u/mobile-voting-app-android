using System.Collections.ObjectModel;
using MSO.AppStimmer.Core.ViewModels;
using MSO.AppStimmer.Models;
using MSO.AppStimmer.Views;
using MSO.AppStimmer.Views.Pages;

namespace MSO.AppStimmer.ViewModels
{
    public class MainPageMasterViewModel : BaseViewModel
    {
        public ObservableCollection<MenuPageItem> MenuItems { get; private set; }

        public MainPageMasterViewModel()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            this.MenuItems = new ObservableCollection<MenuPageItem>
            {
                new MenuPageItem(typeof(AppStimmerPage), "Appstimmen",
                    "MSO.AppStimmer.Resources.Icons.thumbs_up.scale-100.png"),
                new MenuPageItem(typeof(AppStimmerEditorPage), "Neuer Appstimmeer",
                    "MSO.AppStimmer.Resources.Icons.plus.scale-100.png"),
                new MenuPageItem(typeof(AppStimmersPage), "Deine Appstimmer",
                    "MSO.AppStimmer.Resources.Icons.list.scale-100.png"),
                new MenuPageItem(typeof(AppStimmersPage), "Favoriten",
                    "MSO.AppStimmer.Resources.Icons.star_filled.scale-100.png"),
                new MenuPageItem(typeof(SettingsPage), "Einstellungen",
                    "MSO.AppStimmer.Resources.Icons.settings.scale-100.png"),
            };
        }
    }
}
