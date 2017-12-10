using System;
using System.Diagnostics;
using FFImageLoading.Svg.Forms;
using MSO.StimmApp.Elements;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFShapeView;

namespace MSO.StimmApp.Views.ContentViews.Appstimmen
{
	public partial class AppStimmerCardView : ContentView
	{
        public AppStimmerCardView ()
		{
			this.InitializeComponent();

            this.LayoutChanged += (sender, e) =>
		    {
		        this.SwipeCardView.CardMoveDistance = (int)(this.Width * 0.40f);
		    };

		    //var frame = this.SwipeCardView.cards[this.SwipeCardView.topCardIndex].FindByName<Frame>("CardFrame");
      //      var titleUnderlayGrid = frame.FindByName<Grid>("TitleUnderlayGrid");

		    //var numSlices = 1000;
      //      var rowDefinitions = new RowDefinitionCollection();

		    //for (var i = 1; i <= numSlices; i++)
		    //{
		    //    var rowDefinition = new RowDefinition();
		    //    rowDefinition.Height = new GridLength(i, GridUnitType.Star);
		    //    rowDefinitions.Add(rowDefinition);
		    //}

		    //titleUnderlayGrid.RowDefinitions = rowDefinitions;

		    //for (var i = 1; i <= numSlices; i++)
		    //{
		    //    var boxView = new BoxView
		    //    {
		    //        BackgroundColor = Color.Black,
		    //        Opacity = (float) i / numSlices,
		    //        WidthRequest = 50
		    //    };

		    //    boxView.SetValue(Grid.RowProperty, i);

      //          titleUnderlayGrid.Children.Add(boxView);
      //      }



		    //      var a = this.FindByName<Image>("LikeImage");
		    //      var b = this.SwipeCardView.FindByName<Image>("LikeImage");
		    //      var titleLabel = this.SwipeCardView.cards[this.SwipeCardView.topCardIndex].FindByName<Frame>("CardFrame");
		    //var stackLayout = titleLabel.FindByName<StackLayout>("TitleStackLayout");

		    //var grid = new Grid();
		    //grid.RowSpacing = 0;
		    //grid.ColumnSpacing = 0;
		    //      grid.HorizontalOptions = LayoutOptions.FillAndExpand;
		    //      var rowDefinitions = new RowDefinitionCollection();


		    //      for (var i = 0; i <= 100; i++)
		    //      {
		    //          var rowDefinition = new RowDefinition {Height = 1 / 100};
		    //          rowDefinitions.Add(rowDefinition);
		    //      }

		    //grid.RowDefinitions = rowDefinitions;

		    //      for (var i = 0; i <= 100; i++)
		    //{
		    //    var boxView = new BoxView { BackgroundColor = Color.Black };
		    //    boxView.SetValue(Grid.RowProperty, i);
		    //    boxView.WidthRequest = 30;

		    //    grid.Children.Add(boxView);
		    //      }

		    //      stackLayout.Children.Add(grid);
		}

	    public AppStimmerViewModel ViewModel => this.BindingContext as AppStimmerViewModel;

	    private void ShowDetailsImageButton_OnTapped(object sender, EventArgs e)
	    {
	        this.ViewModel.ShowDetailsForCurrentAppStimmer();
	    }

	    private void PanGestureRecognizer_OnPanUpdated(object sender, PanUpdatedEventArgs e)
	    {
	        Debug.WriteLine("Pan gesture: " + e.StatusType);
	    }
	}
}