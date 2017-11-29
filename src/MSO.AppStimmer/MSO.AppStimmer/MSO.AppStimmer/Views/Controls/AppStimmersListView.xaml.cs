using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmersListView : ListView
    {
        public AppStimmersListView()
        {
            this.InitializeComponent();
        }

        public AppStimmersViewModel ViewModel => this.BindingContext as AppStimmersViewModel;

        private void AppStimmersListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var appStimmer = e.Item as AppStimmer;
            if (appStimmer == null)
                return;


            this.ViewModel.EditAppStimmer(appStimmer);
        }
    }
}