using System;
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

        private void TestAttachmentsView_OnBindingContextChanged(object sender, EventArgs e)
        {
            var view = (Grid) sender;
            view.BindingContext = this.BindingContext;
        }
    }
}