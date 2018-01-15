using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Elements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColoredNavigationPage : NavigationPage
    {
        public ColoredNavigationPage(Page page) : base(page)
        {
            this.InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            App.NavigationService.GoBack();
            return true;
        }
    }
}