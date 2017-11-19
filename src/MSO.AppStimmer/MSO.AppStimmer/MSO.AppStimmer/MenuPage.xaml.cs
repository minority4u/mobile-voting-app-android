using System;
using MSO.StimmApp.Models;
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

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MenuPageItem;
            if (item == null)
                return;

            var page = (Page) Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            this.InitializePage(page);
            this.ResetMenuPage();
        }

        public void InitializePage(Page page, string titleBarColor = "F9C470")
        {
            var navigationPage = new NavigationPage(page)
            {
                BarBackgroundColor = Color.FromHex(titleBarColor)
            };

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