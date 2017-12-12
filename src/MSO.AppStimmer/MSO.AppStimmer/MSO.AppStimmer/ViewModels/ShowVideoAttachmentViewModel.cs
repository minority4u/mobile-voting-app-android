using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.ViewModels;

namespace MSO.StimmApp.ViewModels
{
    public class ShowVideoAttachmentViewModel : BaseViewModel
    {
        private string videoPath;

        [PreferredConstructor]
        public ShowVideoAttachmentViewModel(string videoPath)
        {
            this.VideoPath = videoPath;
        }

        public string VideoPath
        {
            get => this.videoPath;
            set => this.Set(ref this.videoPath, value);
        }
    }
}
