using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Elements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomNavigationBar : ContentView
    {
        public CustomNavigationBar()
        {
            this.InitializeComponent();
        }

        private async void BackButtonImage_OnTapped(object sender, EventArgs e)
        {
            await App.NavigationService.GoBack();
        }
    }
}