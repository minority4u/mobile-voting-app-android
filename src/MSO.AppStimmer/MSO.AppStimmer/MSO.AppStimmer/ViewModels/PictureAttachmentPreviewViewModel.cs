using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using Rg.Plugins.Popup.Services;

namespace MSO.StimmApp.ViewModels
{
    public class PictureAttachmentPreviewViewModel : BaseViewModel
    {
        private AppStimmerAttachment attachment;
        private RelayCommand submitCommand;


        public PictureAttachmentPreviewViewModel(AppStimmerAttachment attachment)
        {
            this.Attachment = attachment;
        }

        public RelayCommand SubmitCommand => this.submitCommand ?? (this.submitCommand =
            new RelayCommand(this.Submit));

        private async void Submit()
        {
            Messenger.Default.Send(new AppStimmerAttachmentAddedMessage(this.Attachment));
            await PopupNavigation.PopAllAsync();
        }

        public AppStimmerAttachment Attachment
        {
            get => this.attachment;
            set => this.Set(ref this.attachment, value);
        }
    }
}
