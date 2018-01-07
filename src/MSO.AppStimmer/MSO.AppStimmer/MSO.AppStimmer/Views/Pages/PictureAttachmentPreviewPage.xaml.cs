using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Services;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PictureAttachmentPreviewPage : ContentPage
    {
        public PictureAttachmentPreviewPage(PictureAttachmentPreviewViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            this.SubmitButton.Opacity = this.SubmitButton.Scale = 0;
            this.DescriptionGrid.Opacity = this.DescriptionGrid.Scale = 0;

            await Task.Delay(300);

            await Animator.SimpleFade(this.DescriptionGrid, Animator.FadeType.In);
            Animator.SimpleFade(this.SubmitButton, Animator.FadeType.In);
        }

        PictureAttachmentPreviewViewModel ViewModel => this.BindingContext as PictureAttachmentPreviewViewModel;
    }
}