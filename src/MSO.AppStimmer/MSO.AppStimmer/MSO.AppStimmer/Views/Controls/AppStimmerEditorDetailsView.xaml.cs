using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmerEditorDetailsView : ContentView
    {
        public AppStimmerEditorDetailsView()
        {
            this.InitializeComponent();
        }

        public AppStimmerEditorViewModel ViewModel => this.BindingContext as AppStimmerEditorViewModel;

        private void AddAttachmentImageButton_OnTapped(object sender, EventArgs e)
        {
            this.ViewModel.IsAddingAttachment = true;
        }
    }
}