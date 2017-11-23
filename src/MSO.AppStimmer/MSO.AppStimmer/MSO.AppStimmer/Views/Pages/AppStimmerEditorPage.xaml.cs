using MSO.StimmApp.Views.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmerEditorPage : TabbedPage
    {
        public AppStimmerEditorPage()
        {
            this.InitializeComponent();

            //this.Children.Add(new ContentPage
            //{
            //    Title = "Overview",
            //    Content = new AppStimmerEditorOverviewView()
            //});

            //this.Children.Add(new ContentPage
            //{
            //    Title = "Details",
            //    Content = new AppStimmerEditorDetailsView()
            //});
        }
    }
}