using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Elements;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using TK.CustomMap;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapsContentPage : PopupPage
    {
        public MapsContentPage()
        {
            this.InitializeComponent();
        }

        public MapsContentPage(MapAttachmentViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;

            var pos = this.ViewModel.SelectedPin.Position;
            var map = new TKCustomMap(MapSpan.FromCenterAndRadius(pos, Distance.FromMiles(10)));
            map.SetBinding(TKCustomMap.MapLongPressCommandProperty, "MapLongPressedCommand");

            map.Pins = this.ViewModel.Pins;
            map.SelectedPin = this.ViewModel.SelectedPin;

            map.SetValue(Grid.RowProperty, 0);
            map.SetValue(Grid.RowSpanProperty, 2);

            var grid = new Grid();
            var rows = new RowDefinitionCollection();
            var firstRow = new RowDefinition
            {
                Height = new GridLength(10, GridUnitType.Star),
            };

            var secondRow = new RowDefinition
            {
                Height = new GridLength(90, GridUnitType.Star)
            };

            rows.Add(firstRow);
            rows.Add(secondRow);
            grid.RowDefinitions = rows;

            var topBarOverlay = new GradientFrame();
            topBarOverlay.StartColor = "#99000000";
            topBarOverlay.EndColor = "#00000000";
            topBarOverlay.SetValue(Grid.RowProperty, 0);
            topBarOverlay.SetValue(Grid.RowSpanProperty, 1);

            var saveButton = new Label();
            saveButton.TextColor = Color.White;
            saveButton.Text = "SPEICHERN";
            saveButton.FontSize = 17;
            saveButton.Margin = new Thickness(15, 15, 15, 15);
            saveButton.VerticalOptions = LayoutOptions.Start;
            saveButton.HorizontalOptions = LayoutOptions.End;

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGestureOnTapped;
            saveButton.GestureRecognizers.Add(tapGesture);
              
            grid.Children.Add(map);
            grid.Children.Add(topBarOverlay);
            grid.Children.Add(saveButton);

            this.Content = grid;
        }

        private async void TapGestureOnTapped(object sender, EventArgs eventArgs)
        {
            await this.ViewModel.SaveAttachment();
        }

        MapAttachmentViewModel ViewModel => this.BindingContext as MapAttachmentViewModel;
    }
}