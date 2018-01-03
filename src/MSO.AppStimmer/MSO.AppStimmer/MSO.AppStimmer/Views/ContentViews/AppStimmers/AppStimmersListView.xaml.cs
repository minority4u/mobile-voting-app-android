using System.Collections.Generic;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ItemTappedEventArgs = Xamarin.Forms.ItemTappedEventArgs;

namespace MSO.StimmApp.Views.ContentViews.AppStimmers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmersListView : SfListView
    {
        

        public AppStimmersListView()
        {
            this.InitializeComponent();

   
        }

        public AppStimmersViewModel ViewModel => this.BindingContext as AppStimmersViewModel;

        private void AppStimmersListView_OnItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs itemTappedEventArgs)
        {
            var appStimmer = itemTappedEventArgs.ItemData as AppStimmer;
            if (appStimmer == null)
                return;


            this.ViewModel.EditAppStimmer(appStimmer);
            
        }


    }
}