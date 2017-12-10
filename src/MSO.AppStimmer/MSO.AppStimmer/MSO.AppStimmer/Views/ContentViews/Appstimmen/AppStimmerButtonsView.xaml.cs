using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Messages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.Appstimmen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmerButtonsView : ContentView
    {
        public AppStimmerButtonsView()
        {
            InitializeComponent();
        }

        private void LikeImageButton_OnTapped(object sender, EventArgs e)
        {
            Messenger.Default.Send(new AppStimmerButtonPressedMessage(true));
        }

        private void DislikeImageButton_OnTapped(object sender, EventArgs e)
        {
            Messenger.Default.Send(new AppStimmerButtonPressedMessage(false));
        }
    }
}