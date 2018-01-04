using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using Rg.Plugins.Popup.Services;
using TK.CustomMap;

namespace MSO.StimmApp.ViewModels
{
    public class MapAttachmentViewModel : BaseViewModel
    {
        private AppStimmerAttachment attachment;
        private ObservableCollection<TKCustomMapPin> pins;
        private TKCustomMapPin selectedPin;
        private RelayCommand<Position> mapLongPressedCommand;

        public MapAttachmentViewModel(AppStimmerAttachment attachment)
        {
            this.Attachment = attachment;
            this.Pins = new ObservableCollection<TKCustomMapPin>();

            if (attachment.AttachmentSource != null)
            {
                var positions = attachment.AttachmentSource.Split(';');
                var latidude = Convert.ToDouble(positions[0], CultureInfo.InvariantCulture);
                var longitude = Convert.ToDouble(positions[1], CultureInfo.InvariantCulture);

                var position = new Position(latidude, longitude);
                this.SelectPosition(position);
            }
        }

        public RelayCommand<Position> MapLongPressedCommand => this.mapLongPressedCommand ?? (this.mapLongPressedCommand =
            new RelayCommand<Position>(position => this.LongPressed(position)));

        private void LongPressed(Position position)
        {
            this.SelectPosition(position);
        }

        private void SelectPosition(Position position)
        {
            var pin = new TKCustomMapPin
            {
                Position = position,
                IsVisible = true,
            };

            this.Pins.Clear();
            this.Pins.Add(pin);

            this.SelectedPin = new TKCustomMapPin {Position = position};
        }

        public AppStimmerAttachment Attachment
        {
            get => this.attachment;
            set => this.Set(ref this.attachment, value);
        }

        public ObservableCollection<TKCustomMapPin> Pins
        {
            get => this.pins;
            set => this.Set(ref this.pins, value);
        }

        public TKCustomMapPin SelectedPin
        {
            get => this.selectedPin;
            set => this.Set(ref this.selectedPin, value);
        }

        public async Task SaveAttachment()
        {
            Messenger.Default.Send(new AppStimmerAttachmentAddedMessage(this.Attachment));
            await PopupNavigation.PopAllAsync();
        }
    }
}
