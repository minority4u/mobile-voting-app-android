using System;
using MSO.StimmApp.Core.Helpers;
using MSO.StimmApp.Elements;
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

        public void InitializePage(Page page)
        {
            var navigationPage = new ColoredNavigationPage(page);

            //var binding = new Binding();
            //binding.Mode = BindingMode.TwoWay;
            //binding.Source = App.Settings.AppPrimaryColor;

            //navigationPage.SetBinding(NavigationPage.BarBackgroundColorProperty, binding);

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