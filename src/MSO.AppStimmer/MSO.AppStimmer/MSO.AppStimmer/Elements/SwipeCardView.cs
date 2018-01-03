using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Messages;
using MSO.StimmApp.ViewModels;
using Xamarin.Forms;

namespace MSO.StimmApp.Elements
{
    public class SwipeCardView : ContentView
    {
        // Back card scale
        private const float BackCardScale = 0.8f; 
        // Speed of the animations
        private uint AnimationLength = 500; 
        // 180 / pi
        private const float DegreesToRadians = 57.2957795f; 
        // The higher the number, the less the rotation effect
        private const float CardRotationAdjuster = 0.3f; 
        // Number of cards in stack
        private const int NumCards = 2; 

        public readonly View[] cards = new View[NumCards];
        // The card at the top of the stack
        public int topCardIndex;
        // Distance the card has been moved
        private float cardDistance;
        // The last items index added to the stack of the cards
        private int itemIndex; 
        private bool ignoreTouch;

        public SwipeCardView()
        {
            var view = new RelativeLayout();

            this.BackgroundColor = Color.FromHex(App.Settings.AppColors.SwipeCardBackgroundColor);
            this.Content = view;

            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += this.OnPanUpdated;
            this.GestureRecognizers.Add(panGesture);

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += TapGestureOnTapped;
            this.GestureRecognizers.Add(tapGesture);

            Messenger.Default.Register<AppStimmerButtonPressedMessage>(this, this.OnAppStimmerButtonPressed);
        }

        AppStimmerViewModel ViewModel => this.BindingContext as AppStimmerViewModel;

        private void TapGestureOnTapped(object sender, EventArgs eventArgs)
        {        
            this.ViewModel.ShowDetailsForCurrentAppStimmer();
        }

        private void OnAppStimmerButtonPressed(AppStimmerButtonPressedMessage obj)
        {
            Debug.WriteLine("AppStimmer button pressed. Result: " + obj.Liked);
            if (obj.Liked)
            {
                this.cardDistance = 1;
            }
            else
            {
                this.cardDistance = -1;
            }

            var topCard = this.cards[this.topCardIndex];
            var backCard = this.cards[PrevCardIndex(this.topCardIndex)];

            this.ignoreTouch = true;
            //this.AnimationLength = 1000;
            Device.BeginInvokeOnMainThread(async () =>
            {
                this.MoveCardOffTheScreen(topCard);
                backCard.Scale = 1.0;
            });
            //this.AnimationLength = 250;
            this.ignoreTouch = false;
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                nameof(ItemsSource),
                typeof(IList),
                typeof(SwipeCardView),
                null,
                propertyChanged: OnItemsSourcePropertyChanged);

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(SwipeCardView),
                propertyChanged: OnItemTemplatePropertyChanged);

        public static readonly BindableProperty SwipedLeftCommandProperty =
            BindableProperty.Create(
                nameof(SwipedLeftCommand),
                typeof(ICommand),
                typeof(SwipeCardView));

        public static readonly BindableProperty SwipedRightCommandProperty =
            BindableProperty.Create(
                nameof(SwipedRightCommand),
                typeof(ICommand),
                typeof(SwipeCardView));

        public static readonly BindableProperty TopItemProperty =
            BindableProperty.Create(
                nameof(TopItem),
                typeof(object),
                typeof(SwipeCardView),
                null,
                BindingMode.OneWayToSource);

        public int CardMoveDistance { get; set; } // Distance a card must be moved to consider to be swiped off

        public IList ItemsSource
        {
            get => (IList) this.GetValue(ItemsSourceProperty);
            set
            {
                this.SetValue(ItemsSourceProperty, value);
                this.itemIndex = 0;
            }
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate) this.GetValue(ItemTemplateProperty);
            set => this.SetValue(ItemTemplateProperty, value);
        }

        public object TopItem
        {
            get => (object) this.GetValue(TopItemProperty);
            set => this.SetValue(TopItemProperty, value);
        }

        public ICommand SwipedLeftCommand
        {
            get => (ICommand)this.GetValue(SwipedLeftCommandProperty);
            set => this.SetValue(SwipedLeftCommandProperty, value);
        }

        public ICommand SwipedRightCommand
        {
            get => (ICommand) this.GetValue(SwipedRightCommandProperty);
            set => this.SetValue(SwipedRightCommandProperty, value);
        }

        private static void OnItemTemplatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var swipeCardView = (SwipeCardView) bindable;
            if (swipeCardView.ItemTemplate == null)
                return;

            swipeCardView.Content = null;
            var view = new RelativeLayout();

            // create a stack of cards
            for (var i = 0; i < NumCards; i++)
            {
                var content = swipeCardView.ItemTemplate.CreateContent();
                if (!(content is View) && !(content is ViewCell))
                    throw new Exception($"Invalid visual object {nameof(content)}");

                var card = content is View ? content as View : ((ViewCell)content).View;

                swipeCardView.cards[i] = card;
                card.InputTransparent = true;
                card.IsVisible = false;
                card.BackgroundColor = Color.FromHex(App.Settings.AppColors.SwipeCardColor);

                view.Children.Add(
                    card,
                    Constraint.Constant(0),
                    Constraint.Constant(0),
                    Constraint.RelativeToParent(parent => parent.Width),
                    Constraint.RelativeToParent(parent => parent.Height));
            }

            swipeCardView.Content = view;
        }

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var swipeCardView = (SwipeCardView)bindable;

            var observable = oldValue as INotifyCollectionChanged;
            if (observable != null)
                observable.CollectionChanged -= swipeCardView.OnItemSourceCollectionChanged;

            observable = newValue as INotifyCollectionChanged;
            swipeCardView.Setup();
            if (observable != null)
                observable.CollectionChanged += swipeCardView.OnItemSourceCollectionChanged;
        }

        private void OnItemSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.cards[0].IsVisible == false && this.cards[1].IsVisible == false)
                this.Setup();
        }

        private void Setup()
        {
            // Set the top card
            this.topCardIndex = 0;

            // Create a stack of cards
            for (var i = 0; i < Math.Min(NumCards, this.ItemsSource.Count); i++)
            {
                if (this.itemIndex >= this.ItemsSource.Count)
                    break;

                var card = this.cards[i];
                card.BindingContext = this.ItemsSource[this.itemIndex];

                if (i == 0)
                    this.TopItem = this.ItemsSource[this.itemIndex];

                card.IsVisible = true;
                card.Scale = this.GetScale(i);
                card.RotateTo(0, 0);
                card.TranslateTo(0, -card.Y, 0);

                ((RelativeLayout) this.Content).LowerChild(card);
                this.itemIndex++;
            }

            //var topCard = this.cards[this.topCardIndex];
            //var scrollView = topCard.FindByName<ScrollView>("Scroller");
            //scrollView.Scrolled += (sender, e) => Parallax();
            //Parallax();

            //var panGesture = new PanGestureRecognizer();
            //panGesture.PanUpdated += this.OnPanUpdated;
            //scrollView.GestureRecognizers.Add(panGesture);
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            //Debug.WriteLine("GestureStatusChange received");
            //Debug.WriteLine(DateTime.Now.ToString("hh.mm.ss.ffffff") + ": " + e.StatusType);
            switch (e.StatusType)
            {
                case GestureStatus.Started:
           
                    this.HandleTouchStart();
                    break;
                case GestureStatus.Running:
                
                    this.HandleTouch((float)e.TotalX, (float) e.TotalY);
                    break;
                case GestureStatus.Completed:
                  
                    this.HandleTouchEnd();
                    break;
                case GestureStatus.Canceled:
                   
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // Hande when a touch event begins
        private void HandleTouchStart()
        {
            this.cardDistance = 0;
        }

        // Handle the ongoing touch event as the card is moved
        private void HandleTouch(float differenceX, float differenceY)
        {
            if (this.ignoreTouch)
                return;

            var topCard = this.cards[this.topCardIndex];
            var backCard = this.cards[PrevCardIndex(this.topCardIndex)];

            // Move the top card
            if (topCard.IsVisible)
            {
                // Move the card
                topCard.TranslationX = differenceX;
                //if (Math.Abs(this.cardDistance) > 0)
                topCard.TranslationY = differenceY;

                // Calculate a angle for the card
                var rotationAngle = (float)(CardRotationAdjuster * Math.Min(differenceX / this.Width, 1.0f));
                topCard.Rotation = rotationAngle * DegreesToRadians;
                

                // Keep a record of how far its moved
                this.cardDistance = differenceX;

                var percentageOfTriggerDistanceMoved = Math.Abs(this.cardDistance / this.CardMoveDistance);
                if (percentageOfTriggerDistanceMoved > 0.10)
                {
                    //var overlayGrid = topCard.FindByName<Image>("OverlayImage");

                    //if (this.cardDistance > 0)
                    //    overlayGrid.BackgroundColor = Color.FromHex(App.Settings.AppColors.SwipeRightIndicatorColor);
                    //else
                    //    overlayGrid.BackgroundColor = Color.FromHex(App.Settings.AppColors.SwipeLeftIndicatorColor);

                    //overlayGrid.Opacity = percentageOfTriggerDistanceMoved;
                    
                    var overlayGrid = topCard.FindByName<Image>("LikeImage");

                    if (this.cardDistance > 0)
                    {
                        var likeImage = topCard.FindByName<Image>("LikeImage");
                        likeImage.Opacity = percentageOfTriggerDistanceMoved;
                    }
                    else
                    {
                        var dislikeImage = topCard.FindByName<Image>("DislikeImage");
                        dislikeImage.Opacity = percentageOfTriggerDistanceMoved;
                    }        
                }
                else
                {
                    ResetOverlayColor();
                }
            }

            // Scale the backcard
            if (backCard.IsVisible)
                backCard.Scale = Math.Min(BackCardScale + Math.Abs((this.cardDistance / this.CardMoveDistance) * (1.0f - BackCardScale)), 1.0f);
        }

        private void ResetOverlayColor()
        {
            var topCard = this.cards[this.topCardIndex];
            //var overlayGrid = topCard.FindByName<Image>("OverlayImage");
            //overlayGrid.Opacity = 0.0;
            //overlayGrid.BackgroundColor = Color.FromHex(App.Settings.AppColors.NoSwipeIndicatorColor);
            var likeImage = topCard.FindByName<Image>("LikeImage");
            var dislikeImage = topCard.FindByName<Image>("DislikeImage");

            likeImage.Opacity = 0.0;
            dislikeImage.Opacity = 0.0;
        }

        double _imageHeight = 0;

        void Parallax()
        {
            var topCard = this.cards[this.topCardIndex];

            var scrollView = topCard.FindByName<ScrollView>("Scroller");
            var photoImage = topCard.FindByName<Image>("AppStimmerPicture");
            
            if (_imageHeight <= 0)
                _imageHeight = photoImage.Height;

            var y = scrollView.ScrollY * .4;
            if (y >= 0)
            {
                //Move the Image's Y coordinate a fraction of the ScrollView's Y position
                photoImage.Scale = 1;
                photoImage.TranslationY = y;
            }
            else
            {
                //Calculate a scale that equalizes the height vs scroll
                double newHeight = _imageHeight + (scrollView.ScrollY * -1);
                photoImage.Scale = newHeight / _imageHeight;
                photoImage.TranslationY = scrollView.ScrollY / 2;
            }
        }

        // Handle the end of the touch event
        private async void HandleTouchEnd()
        {
            Debug.WriteLine("HandleTouchEnd");
            this.ignoreTouch = true;

            var topCard = this.cards[this.topCardIndex];
            this.ResetOverlayColor();

            // If the card was move enough to be considered swiped off
            if (Math.Abs((int)this.cardDistance) > this.CardMoveDistance)
            {
                await MoveCardOffTheScreen(topCard);
            }
            else
            {
                // Move the top card back to the center
                topCard.TranslateTo((-topCard.X), -topCard.Y, AnimationLength, Easing.SpringOut);
                topCard.RotateTo(0, AnimationLength, Easing.SpringOut);

                // Scale the back card down
                var prevCard = this.cards[PrevCardIndex(this.topCardIndex)];
                await prevCard.ScaleTo(BackCardScale, AnimationLength, Easing.SpringOut);
            }

            this.ignoreTouch = false;
        }

        private async Task MoveCardOffTheScreen(View topCard)
        {
            // move off the screen
            await topCard.TranslateTo(this.cardDistance > 0 ? this.Width : -this.Width, 0, AnimationLength / 2, Easing.SpringOut);
            topCard.IsVisible = false;

            if (this.SwipedRightCommand != null && this.cardDistance > 0)
                this.SwipedRightCommand.Execute(this.ItemsSource.IndexOf(topCard.BindingContext));
            else
                SwipedLeftCommand?.Execute(this.ItemsSource.IndexOf(topCard.BindingContext));

            this.ShowNextCard();
        }

        public void ShowNextCard()
        {
            if (this.cards[0].IsVisible == false && this.cards[1].IsVisible == false)
            {
                this.Setup();
                return;
            }

            this.TopItem = this.ItemsSource[this.itemIndex - 1];

            var topCard = this.cards[this.topCardIndex];
            this.topCardIndex = NextCardIndex(this.topCardIndex);

            // If there are more cards to show, show the next card in to place of 
            // the card that was swipped off the screen
            if (this.itemIndex >= this.ItemsSource.Count)
                return;

            // Push it to the back z order
            ((RelativeLayout)this.Content).LowerChild(topCard);

            try
            {
                // Reset its scale, opacity and rotation
                topCard.Scale = BackCardScale;
                topCard.RotateTo(0, 0);
                topCard.TranslateTo(0, -topCard.Y, 0);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }

            topCard.BindingContext = this.ItemsSource[this.itemIndex];

            topCard.IsVisible = true;
            this.itemIndex++;
        }

        // Return the next card index from the top
        private static int NextCardIndex(int topIndex)
        {
            return topIndex == 0 ? 1 : 0;
        }

        // Return the prev card index from the top
        private static int PrevCardIndex(int topIndex)
        {
            return topIndex == 0 ? 1 : 0;
        }

        // Helper to get the scale based on the card index position relative to the top card
        private float GetScale(int index)
        {
            float result;
            if (index != this.topCardIndex)
                result = BackCardScale;
            else
                result = 1.0f;

            return result;
        }
    }
}
