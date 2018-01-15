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
            this.InitializeComponent();
        }


        private async void LikeImageButton_OnTapped(object sender, EventArgs e)
        {
            await this.LikeButton.ScaleTo(0.80, 100, Easing.Linear);
            this.LikeButton.ScaleTo(1, 100, Easing.Linear);
            Messenger.Default.Send(new AppStimmerButtonPressedMessage(true));
        }

        private async void DislikeImageButton_OnTapped(object sender, EventArgs e)
        {
            await this.DislikeButton.ScaleTo(0.80, 100, Easing.Linear);
            this.DislikeButton.ScaleTo(1, 100, Easing.Linear);
            Messenger.Default.Send(new AppStimmerButtonPressedMessage(false));
        }

        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            await this.InfoButton.ScaleTo(0.80, 100, Easing.Linear);
            this.InfoButton.ScaleTo(1, 100, Easing.Linear);
        }
    }
}