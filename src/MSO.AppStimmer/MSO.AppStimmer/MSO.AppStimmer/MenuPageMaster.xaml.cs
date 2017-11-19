using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageMaster : ContentPage
    {
        public ListView ListView => this.MenuItemsList;

        public MenuPageMaster()
        {
            this.InitializeComponent();
        }
    }
}