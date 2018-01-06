using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.Maps;
using MSO.StimmApp.Core.Maps.Geo;
using MSO.StimmApp.Elements;
using MSO.StimmApp.ViewModels;
using Plugin.Geolocator;
using Rg.Plugins.Popup.Pages;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsContentPage : ContentPage
    {
        private IPlacesService placesService;
        private IGeoLocationService locationService;
        private bool suppressShowingResults;

        public MapsContentPage()
        {
            this.InitializeComponent();
            this.placesService = SimpleIoc.Default.GetInstance<IPlacesService>();
            this.locationService = SimpleIoc.Default.GetInstance<IGeoLocationService>();
        }

        //protected override async void OnAppearing()
        //{    
        //    base.OnAppearing();     
        //}

        private async Task TrySelectPositionFromCurrentLocation()
        {
            var timeout = TimeSpan.FromSeconds(5);
            var position = await this.locationService.TryGetCurrentPosition(timeout);

            if (position == null)
                return;

            var mapPos = new Position(position.Latitude, position.Longitude);
            this.ViewModel.SelectPosition(mapPos);

            var region = MapSpan.FromCenterAndRadius(mapPos, Distance.FromKilometers(0.25));
            this.MapsView.MoveToMapRegion(region);
        }

        public MapsContentPage(MapAttachmentViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;

            this.placesService = SimpleIoc.Default.GetInstance<IPlacesService>();
            this.locationService = SimpleIoc.Default.GetInstance<IGeoLocationService>();

            var attachment = this.ViewModel.Attachment;

            // Mannheim train station. We want to show the "get current location" functionality, that's why it isn't set to UAS Mannheim at the beginning.
            var position = new Position(49.3977085, 8.3647718);
            var radius = 1.0;

            if (!string.IsNullOrEmpty(attachment.AttachmentSource))
            {
                var positions = attachment.AttachmentSource.Split(';');
                var latidude = Convert.ToDouble(positions[0], CultureInfo.InvariantCulture);
                var longitude = Convert.ToDouble(positions[1], CultureInfo.InvariantCulture);
                radius = 0.25;

                position = new Position(latidude, longitude);
                this.ViewModel.SelectPosition(position);
            }

            var region = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(radius));
            this.MapsView.MapRegion = region;    
        }

        private async void TapGestureOnTapped(object sender, EventArgs eventArgs)
        {
            await this.ViewModel.SaveAttachment();
        }

        MapAttachmentViewModel ViewModel => this.BindingContext as MapAttachmentViewModel;

        private async void PlacesSearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var text = e.NewTextValue;

            if (string.IsNullOrEmpty(text))
            {
                await this.ShowResultsFrameAsync(false);
                return;
            }
                
            await this.ViewModel.SearchForPlaces(text);

            if (text.Length > 0)
                await this.ShowResultsFrameAsync(true);
        }

        private async Task ShowResultsFrameAsync(bool show)
        {
            if (show)
            {
                if (!this.suppressShowingResults)
                {
                    this.ViewModel.IsSearching = true;
                    await this.SearchPredictionsFrame.FadeTo(1, 250U, Easing.Linear);
                }
            }
            else
            {
                await this.SearchPredictionsFrame.FadeTo(0, 250U, Easing.Linear);
                this.ViewModel.IsSearching = false;
            }

            //this.ViewModel.IsSearching = show;
        }

        //private async void SearchPredictionsListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    var predictionItem = e.Item as AutoCompletePrediction;
        //    if (predictionItem == null)
        //        return;

        //    var place = await this.placesService.GetPlace(predictionItem.PlaceId);
        //    var position = new Position(place.Latitude, place.Longitude);

        //    var region = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.5));
        //    this.MapsView.MoveToMapRegion(region);

        //    this.ViewModel.SelectPosition(position);
        //    this.MapsView.Focus();

        //    this.suppressShowingResults = true;
        //    this.ViewModel.SearchText = predictionItem.Description;

        //    await this.ShowResultsFrameAsync(false);

        //    this.suppressShowingResults = false;
        //}

        private async void MapsView_OnMapClicked(object sender, TKGenericEventArgs<Position> e)
        {
            await this.ShowResultsFrameAsync(false);
        }

        private async void PlacesSearchBar_OnFocused(object sender, FocusEventArgs e)
        {
            if (this.ViewModel.SearchText?.Length >= 1)
            {
                await this.ShowResultsFrameAsync(true);
            }
        }

        private async void SearchPredictionsListView_OnItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var predictionItem = e.ItemData as AutoCompletePrediction;
            if (predictionItem == null)
                return;

            var place = await this.placesService.GetPlace(predictionItem.PlaceId);
            var position = new Position(place.Latitude, place.Longitude);

            var region = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.5));
            this.MapsView.MoveToMapRegion(region);

            this.ViewModel.SelectPosition(position);
            this.MapsView.Focus();

            this.suppressShowingResults = true;
            this.ViewModel.SearchText = predictionItem.Description;

            await this.ShowResultsFrameAsync(false);

            this.suppressShowingResults = false;
        }

        private async void GetCurrentLocation_OnTapped(object sender, EventArgs e)
        {
            await this.TrySelectPositionFromCurrentLocation();
        }
    }

    //map.SetBinding(TKCustomMap.MapLongPressCommandProperty, "MapLongPressedCommand");

    //map.Pins = this.ViewModel.Pins;
    //map.SelectedPin = this.ViewModel.SelectedPin;

    //map.SetValue(Grid.RowProperty, 0);
    //map.SetValue(Grid.RowSpanProperty, 2);

    //var grid = new Grid();
    //var rows = new RowDefinitionCollection();
    //var firstRow = new RowDefinition
    //{
    //    Height = new GridLength(10, GridUnitType.Star),
    //};

    //var secondRow = new RowDefinition
    //{
    //    Height = new GridLength(90, GridUnitType.Star)
    //};

    //rows.Add(firstRow);
    //rows.Add(secondRow);
    //grid.RowDefinitions = rows;

    //var topBarOverlay = new GradientFrame();
    //topBarOverlay.StartColor = "#99000000";
    //topBarOverlay.EndColor = "#00000000";
    //topBarOverlay.SetValue(Grid.RowProperty, 0);
    //topBarOverlay.SetValue(Grid.RowSpanProperty, 1);
    //topBarOverlay.IsVisible = this.ViewModel.Attachment.IsNew;

    //var saveButton = new Label();
    //saveButton.TextColor = Color.White;
    //saveButton.Text = "SPEICHERN";
    //saveButton.FontSize = 17;
    //saveButton.Margin = new Thickness(15, 15, 15, 15);
    //saveButton.VerticalOptions = LayoutOptions.Start;
    //saveButton.HorizontalOptions = LayoutOptions.End;
    //saveButton.IsVisible = this.ViewModel.Attachment.IsNew;

    //var tapGesture = new TapGestureRecognizer();
    //tapGesture.Tapped += TapGestureOnTapped;
    //saveButton.GestureRecognizers.Add(tapGesture);

    //grid.Children.Add(map);
    //grid.Children.Add(topBarOverlay);
    //grid.Children.Add(saveButton);

    //this.Content = grid;
}