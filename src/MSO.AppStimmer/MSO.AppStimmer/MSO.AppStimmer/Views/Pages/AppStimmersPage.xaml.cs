using System;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmersPage : ContentPage
    {
        public AppStimmersPage()
        {
            this.InitializeComponent();
        }
        
        public AppStimmersViewModel ViewModel => this.BindingContext as AppStimmersViewModel;
        SearchBar searchBar = null;

        private  void AppStimmersListView_OnItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs itemTappedEventArgs)
        {
            // close the searchbar keyboard if we tab in the background
            if (SearchBar.IsFocused)
            {
                SearchBar.Unfocus();
                this.ListView.DataSource.RefreshFilter();
                return;
            }

            if (!(itemTappedEventArgs.ItemData is AppStimmer appStimmer))
                return;

            this.ViewModel.EditAppStimmer(appStimmer);
        }


        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (ListView.DataSource != null)
            {
                this.ListView.DataSource.Filter = FilterAppstimmers;
                this.ListView.DataSource.RefreshFilter();
            }
        }


        private bool FilterAppstimmers(object obj)
        {
            // filter within the title or description, returns only Appstimmer the user voted for
            
            var appStimmer = obj as AppStimmer;

            // check wheather no filter is set so far
            // show all items the user voted for
            if ((searchBar == null || searchBar.Text == null) && appStimmer.VotedFor)
                return true;

            // checks wheather 
            // searchbar text contains in description or title
            // and user voted for this appstimmer
            if ((appStimmer.Description.ToLower().Contains(searchBar.Text.ToLower())
                                       || appStimmer.Title.ToLower().Contains(searchBar.Text.ToLower()))
                                       && appStimmer.VotedFor)
                return true;
            else
                return false;
        }

        private async void BackButtonImage_OnTapped(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}