using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.AppStimmer.Core.Models
{
    public class AppStimmerUser : ModelBase
    {
        private string mailAddress;
        private string prename;
        private string surname;
        private string username;
        private string zipCode;
        private string profilePicture;

        public AppStimmerUser() : base(true)
        {
            this.Id = Guid.NewGuid();
        }

        public string MailAddress
        {
            get => this.mailAddress;
            set => this.Set(ref this.mailAddress, value);
        }

        public string Prename
        {
            get => this.prename;
            set => this.Set(ref this.prename, value);
        }

        public string Surname
        {
            get => this.surname;
            set => this.Set(ref this.surname, value);
        }

        public string ZipCode
        {
            get => this.zipCode;
            set => this.Set(ref this.zipCode, value);
        }

        public string Username
        {
            get => this.username;
            set => this.Set(ref this.username, value);
        }

        public string ProfilePicture
        {
            get => this.profilePicture;
            set => this.Set(ref this.profilePicture, value);
        }
    }
}
