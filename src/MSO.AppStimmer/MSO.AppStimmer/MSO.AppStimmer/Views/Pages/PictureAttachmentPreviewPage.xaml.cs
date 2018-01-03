using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PictureAttachmentPreviewPage : PopupPage
    {
        public PictureAttachmentPreviewPage(PictureAttachmentPreviewViewModel viewModel)
        {
            this.InitializeComponent();
            this.BindingContext = viewModel;
        }

        PictureAttachmentPreviewViewModel ViewModel => this.BindingContext as PictureAttachmentPreviewViewModel;
    }
}