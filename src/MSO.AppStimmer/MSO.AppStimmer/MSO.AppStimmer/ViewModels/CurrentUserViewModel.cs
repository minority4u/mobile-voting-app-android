using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;

namespace MSO.StimmApp.ViewModels
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
                ProfilePicture = "MSO.StimmApp.Resources.Images.Anonymous.jpg"
            };
        }

        public AppStimmerUser User
        {
            get => this.user;
            set => this.Set(ref this.user, value);
        }
    }
}
