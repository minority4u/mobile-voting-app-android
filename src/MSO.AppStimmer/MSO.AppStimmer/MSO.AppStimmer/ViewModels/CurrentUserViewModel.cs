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
                MailAddress = "Max@Mustermann.com",
                Username = "Max Mustermann",
                ProfilePicture = "MSO.StimmApp.Resources.Images.Profil1.jpg"
            };
        }

        public AppStimmerUser User
        {
            get => this.user;
            set => this.Set(ref this.user, value);
        }
    }
}
