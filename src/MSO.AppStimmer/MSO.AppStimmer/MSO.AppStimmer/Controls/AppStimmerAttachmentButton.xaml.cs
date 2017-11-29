using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Controls
{
	public partial class AppStimmerAttachmentButton : ContentView
	{
	    public static readonly BindableProperty ViewModelProperty =
	        BindableProperty.Create(nameof(Description), typeof(string), typeof(AppStimmerAttachmentButton), null, BindingMode.TwoWay);

	    public static readonly BindableProperty IconSourceProperty =
	        BindableProperty.Create(nameof(IconSource), typeof(string), typeof(AppStimmerAttachmentButton), null, BindingMode.TwoWay);

        public AppStimmerAttachmentButton ()
		{
			this.InitializeComponent();
		    this.Root.BindingContext = this;
		}

	    public string Description
	    {
	        get
	        {
	            var result = (string)GetValue(ViewModelProperty);
	            return result;
	        }
	        set => SetValue(ViewModelProperty, value);
	    }

	    public string IconSource
	    {
	        get
	        {
	            var result = (string)GetValue(IconSourceProperty);
	            return result;
	        }
	        set => SetValue(IconSourceProperty, value);
	    }
    }
}