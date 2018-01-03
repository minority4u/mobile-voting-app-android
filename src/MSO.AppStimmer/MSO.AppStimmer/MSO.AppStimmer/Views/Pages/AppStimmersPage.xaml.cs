﻿using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmersPage : ContentPage
    {
        public AppStimmersPage()
        {
            InitializeComponent();

        }

        
        public AppStimmersViewModel ViewModel => this.BindingContext as AppStimmersViewModel;
        SearchBar searchBar = null;


        private void AppStimmersListView_OnItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs itemTappedEventArgs)
        {
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
        // filter within the title or the description

            // check wheather no filter is set so far
            if (searchBar?.Text == null)
                return true;

            // title or description contains the filter expression
            if (obj is AppStimmer appstimmer && (appstimmer.Description.ToLower().Contains(searchBar.Text.ToLower())
                                       || appstimmer.Title.ToLower().Contains(searchBar.Text.ToLower())))
                return true;
            else
                return false;
        }

    }
}