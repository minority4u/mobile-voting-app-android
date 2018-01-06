using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Core.Maps;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using Plugin.Geolocator;
using Plugin.MediaManager.Abstractions;
using Rg.Plugins.Popup.Services;
using TK.CustomMap;
using Xamarin.Forms;

namespace MSO.StimmApp.ViewModels
{
    public class MapAttachmentViewModel : BaseViewModel
    {
        private AppStimmerAttachment attachment;
        private ObservableCollection<TKCustomMapPin> pins;
        private TKCustomMapPin selectedPin;
        private bool isSearching;
        private string searchText;
        private RelayCommand<Position> mapLongPressedCommand;
        private RelayCommand submitCommand;
        private ObservableCollection<AutoCompletePrediction> autoCompletePredictions;
        private IPlacesService placesService;

        [PreferredConstructor]
        public MapAttachmentViewModel(AppStimmerAttachment attachment)
        {
            this.Attachment = attachment;
            this.Pins = new ObservableCollection<TKCustomMapPin>();

            this.placesService = SimpleIoc.Default.GetInstance<IPlacesService>();
        }

        public AppStimmerAttachment Attachment
        {
            get => this.attachment;
            set => this.Set(ref this.attachment, value);
        }

        public string SearchText
        {
            get => this.searchText;
            set => this.Set(ref this.searchText, value);
        }

        public ObservableCollection<TKCustomMapPin> Pins
        {
            get => this.pins;
            set => this.Set(ref this.pins, value);
        }

        public ObservableCollection<AutoCompletePrediction> AutoCompletePredictions
        {
            get => this.autoCompletePredictions;
            set => this.Set(ref this.autoCompletePredictions, value);
        }

        public TKCustomMapPin SelectedPin
        {
            get => this.selectedPin;
            set => this.Set(ref this.selectedPin, value);
        }

        public bool IsSearching
        {
            get => this.isSearching;
            set => this.Set(ref this.isSearching, value);
        }

        public RelayCommand<Position> MapLongPressedCommand =>
            this.mapLongPressedCommand ?? (this.mapLongPressedCommand =
                new RelayCommand<Position>(position => this.LongPressed(position)));

        public async Task SearchForPlaces(string text)
        {
            Debug.WriteLine("Executing google places search: '{0}'", text);
            var searchoptions = new PlacesSearchOptions
            {
                PlaceType = PlaceType.All,
                BaseLocation = new MapLocation {Latitude = 49.4699789, Longitude = 8.4802401}, // UAS Mannheim
                Countries = "country:de",
                Radius = 1000 * 100 // 100 km
            };

            var result = await this.placesService.GetPlaces(text, searchoptions);
            this.AutoCompletePredictions = new ObservableCollection<AutoCompletePrediction>(result.AutoCompletePlaces);
        }

        private void LongPressed(Position position)
        {
            if (!this.Attachment.IsNew)
                return;

            this.SelectPosition(position);
        }

        public void SelectPosition(Position position)
        {
            var pin = new TKCustomMapPin
            {
                Position = position,
                IsVisible = false, // The custom renderer will display the pin, with a different icon
            };

            this.Pins.Clear();
            this.Pins.Add(pin);

            this.SelectedPin = new TKCustomMapPin {Position = position};
        }

        public async Task SaveAttachment()
        {
            if (this.SelectedPin == null)
                return;

            var latidude = this.SelectedPin.Position.Latitude;
            var longitude = this.SelectedPin.Position.Longitude;

            var attachmentSource = latidude.ToString(CultureInfo.InvariantCulture) + ';' +
                                   longitude.ToString(CultureInfo.InvariantCulture);
            this.Attachment.AttachmentSource = attachmentSource;

            Messenger.Default.Send(new AppStimmerAttachmentAddedMessage(this.Attachment));
            await App.NavigationService.GoBack();
        }
    }
}
