using System;
using MSO.StimmApp.Elements;
using MSO.StimmApp.Models;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            this.InitializeComponent();
            this.MasterPage.ListView.ItemSelected += OnItemSelected;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuPageItem;
            if (item == null)
                return;

            var page = (PopupPage) Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            await PopupNavigation.PushAsync(page);
            //this.InitializePage(page);
            this.ResetMenuPage();
        }

        public void InitializePage(Page page)
        {
            var navigationPage = new ColoredNavigationPage(page);

            App.NavigationService.Initialize(navigationPage);
            this.Detail = navigationPage;
        }

        private void ResetMenuPage()
        {
            this.MasterPage.ListView.SelectedItem = null;
            this.IsPresented = false;
        }
    }
}