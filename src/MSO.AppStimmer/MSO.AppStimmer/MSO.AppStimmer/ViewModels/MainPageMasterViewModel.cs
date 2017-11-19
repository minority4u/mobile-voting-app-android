using System.Collections.ObjectModel;
using MSO.StimmApp.Core.ViewModels;
using MSO.StimmApp.Models;
using MSO.StimmApp.Views.Pages;

namespace MSO.StimmApp.ViewModels
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
                    "MSO.StimmApp.Resources.Icons.thumbs_up.scale-100.png"),
                new MenuPageItem(typeof(AppStimmerEditorPage), "Neuer Appstimmer",
                    "MSO.StimmApp.Resources.Icons.plus.scale-100.png"),
                new MenuPageItem(typeof(AppStimmersPage), "Deine Appstimmer",
                    "MSO.StimmApp.Resources.Icons.list.scale-100.png"),
                new MenuPageItem(typeof(AppStimmersPage), "Favoriten",
                    "MSO.StimmApp.Resources.Icons.star_filled.scale-100.png"),
                new MenuPageItem(typeof(SettingsPage), "Einstellungen",
                    "MSO.StimmApp.Resources.Icons.settings.scale-100.png"),
            };
        }
    }
}
