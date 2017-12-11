using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowImageAttachmentView : ContentView
    {
        public ShowImageAttachmentView()
        {
            this.InitializeComponent();

            //var navigationBarHeight = App.NavigationBarController.Height;
            //this.NavigationBarOverlayGrid.RowDefinitions[0].Height = new GridLength(navigationBarHeight);
        }

        //private void PinchGestureRecognizer_OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}
    }
}