using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmerAttachmentsListView : ListView
    {
        public AppStimmerAttachmentsListView()
        {
            this.InitializeComponent();
        }

        private void AppStimmerAttachmentsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            ((ListView) sender).SelectedItem = null;
        }
    }
}