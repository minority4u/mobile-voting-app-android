using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MSO.AppStimmer.Core.Models;
using MSO.AppStimmer.Core.ViewModels;

namespace MSO.AppStimmer.ViewModels
{
    public class CurrentUserViewModel : BaseViewModel
    {
        private AppStimmerUser user;

        public CurrentUserViewModel()
        {
            this.User = new AppStimmerUser()
            {
                MailAddress = "tinderchampion@sexy.net",
                Username = "Anonymous_666",
                ProfilePicture = "MSO.AppStimmer.Resources.Images.Anonymous.jpg"
            };
        }

        public AppStimmerUser User
        {
            get => this.user;
            set => this.Set(ref this.user, value);
        }
    }
}
