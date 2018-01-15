using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MSO.StimmApp.Elements;
using MSO.StimmApp.Models;
using MSO.StimmApp.Views;
using MSO.StimmApp.Views.Pages;
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

            var page = (Page) Activator.CreateInstance(item.TargetType);
            
            if (page is AppStimmerEditorPage)
            {
                App.NavigationService.NavigateTo(page);
            }
            else
            {
                App.NavigationService.NavigateTo(page, true, true);
            }

            //if (page is AppStimmerEditorPage)
            //{

            //}
            //else
            //{
            //    page.Title = item.Title;
            //    this.InitializePage(page);
            //}

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