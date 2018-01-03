﻿using System;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmersPage : PopupPage
    {
        public AppStimmersPage()
        {
            this.InitializeComponent();
        }
        
        public AppStimmersViewModel ViewModel => this.BindingContext as AppStimmersViewModel;
        SearchBar searchBar = null;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.ViewModel.LoadAllAppStimmers();
        }

        private async void AppStimmersListView_OnItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs itemTappedEventArgs)
        {
            // close the searchbar keyboard if we tab in the background
            if (SearchBar.IsFocused)
            {
                SearchBar.Unfocus();
                return;
            }

            if (!(itemTappedEventArgs.ItemData is AppStimmer appStimmer))
                return;

            await this.ViewModel.EditAppStimmer(appStimmer);
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
            // filter within the title or the description, returns only Appstimmer the user voted for
            
            AppStimmer appStimmer = (AppStimmer)obj;

            // check wheather no filter is set so far
            if (searchBar?.Text == null && appStimmer.VotedFor)
                return true;

            // checks wheather 
            // searchbartext contains in description or title
            // user voted for this appstimmer
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