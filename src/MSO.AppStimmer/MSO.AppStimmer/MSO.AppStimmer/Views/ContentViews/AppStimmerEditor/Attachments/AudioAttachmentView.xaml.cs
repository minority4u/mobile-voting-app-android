using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.ViewModels;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.ContentViews.AppStimmerEditor.Attachments
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AudioAttachmentView : ContentView
    {
        public AudioAttachmentView()
        {
            this.InitializeComponent();
            this.Root.BindingContext = this;
        }

        public static readonly BindableProperty ViewModelProperty =
            BindableProperty.Create(nameof(ViewModel), typeof(AudioAttachmentViewModel), typeof(AudioAttachmentView), null, BindingMode.TwoWay);

        public AudioAttachmentViewModel ViewModel
        {
            get
            {
                var result = (AudioAttachmentViewModel)GetValue(ViewModelProperty);
                return result;
            }
            set => SetValue(ViewModelProperty, value);
        }
    }
}