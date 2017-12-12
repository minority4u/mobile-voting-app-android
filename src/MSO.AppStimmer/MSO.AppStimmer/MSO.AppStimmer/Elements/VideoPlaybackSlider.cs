using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace MSO.StimmApp.Elements
{
    public class VideoPlaybackSlider : Slider
    {
        public static readonly BindableProperty FinishedSelectionCommandProperty =
            BindableProperty.Create(
                nameof(FinishedSelectionCommand),
                typeof(ICommand),
                typeof(SwipeCardView));

        public ICommand FinishedSelectionCommand
        {
            get => (ICommand)this.GetValue(FinishedSelectionCommandProperty);
            set => this.SetValue(FinishedSelectionCommandProperty, value);
        }
    }
}
