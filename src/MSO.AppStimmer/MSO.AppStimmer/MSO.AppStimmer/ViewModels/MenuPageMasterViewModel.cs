using System.Collections.ObjectModel;
using MSO.StimmApp.Core.ViewModels;
using MSO.StimmApp.Models;
using MSO.StimmApp.Views;
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
                new MenuPageItem(typeof(AppStimmerPage), PagesKeys.AppStimmer, "Appstimmen",
                    "MSO.StimmApp.Resources.Icons.thumbs_up.svg"),
                new MenuPageItem(typeof(AppStimmerEditorPage), PagesKeys.AppStimmerEditor, "Neuer Appstimmer",
                    "MSO.StimmApp.Resources.Icons.plus.svg"),
                new MenuPageItem(typeof(AppStimmersPage), PagesKeys.AppStimmers, "Deine Appstimmer",
                    "MSO.StimmApp.Resources.Icons.list.svg"),
                new MenuPageItem(typeof(SettingsPage), PagesKeys.Settings, "Einstellungen",
                    "MSO.StimmApp.Resources.Icons.settings.svg"),
            };
        }
    }
}
