using System.Collections.ObjectModel;
using MSO.StimmApp.Core.ViewModels;
using MSO.StimmApp.Models;
using MSO.StimmApp.Views.Pages;

namespace MSO.StimmApp.ViewModels
{
    public class MenuPageMasterViewModel : BaseViewModel
    {
        public ObservableCollection<MenuPageItem> MenuItems { get; private set; }

        public MenuPageMasterViewModel()
        {
            this.InitializeMenuItems();
        }

        private void InitializeMenuItems()
        {
            this.MenuItems = new ObservableCollection<MenuPageItem>
            {
                new MenuPageItem(typeof(AppStimmerPage), "Appstimmen",
                    "MSO.StimmApp.Resources.Icons.thumbs_up.svg"),
                new MenuPageItem(typeof(AppStimmerEditorPage), "Neuer Appstimmer",
                    "MSO.StimmApp.Resources.Icons.plus.svg"),
                new MenuPageItem(typeof(AppStimmersPage), "Deine Appstimmer",
                    "MSO.StimmApp.Resources.Icons.list.svg"),
                new MenuPageItem(typeof(AppStimmersPage), "Favoriten",
                    "MSO.StimmApp.Resources.Icons.star.svg"),
                new MenuPageItem(typeof(SettingsPage), "Einstellungen",
                    "MSO.StimmApp.Resources.Icons.settings.svg"),
            };
        }
    }
}
