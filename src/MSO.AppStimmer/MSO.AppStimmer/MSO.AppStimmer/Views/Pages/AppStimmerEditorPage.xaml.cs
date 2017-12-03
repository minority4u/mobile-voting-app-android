using MSO.StimmApp.ViewModels;
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
        }

        public AppStimmerEditorPage(AppStimmerEditorViewModel viewModel)
        {          
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}