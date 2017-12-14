using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Core.Services
{
    public class MockAppStimmerService : IAppStimmerService
    {
        public List<AppStimmer> GetAllAppStimmers()
        {
            var result = this.GetRandomAppStimmers();
            return result;
        }

        public void SaveAppStimmer(AppStimmer appStimmer)
        {
            throw new NotImplementedException();
        }

        public void DeleteAppStimmer(AppStimmer appStimmer)
        {
            throw new NotImplementedException();
        }

        private List<AppStimmer> GetRandomAppStimmers()
        {
            var list = new List<AppStimmer>()
            {
                new AppStimmer
                {
                    Title = "Straße kaputt",
                    Attachments = new ObservableCollection<AppStimmerAttachment>()
                    {
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Schlagloch.jpg",
                            Description = "Das ist das blöde Schlagloch.",
                            AttachmentType = AttachmentType.Picture,
                            IsMainAttachment = true
                        },
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "Dies ist ein aussagekräftiger Appstract!",
                            AttachmentType = AttachmentType.Text,
                            IsMainAttachment = true
                        },
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "Dies ist ein Text-Attachment.",
                            Description = "Dies ist ein Text.",
                            AttachmentType = AttachmentType.Text
                        },
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4",
                            Description = "Dies ist ein cooles Video",
                            AttachmentType = AttachmentType.Video
                        },
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "https://ccrma.stanford.edu/~jos/mp3/gtr-jazz.mp3",
                            Description = "Dies ist eine Audio-Aufnahme",
                            AttachmentType = AttachmentType.Audio
                        }
                    }                   
                },
                new AppStimmer
                {
                    Title = "Parkbank voller Moos",
                    Attachments = new ObservableCollection<AppStimmerAttachment>()
                    {
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Kaputte_Parkbank.jpg",
                            Description = "So sieht die Bank aus.",
                            AttachmentType = AttachmentType.Picture,
                            IsMainAttachment = true
                        },
                    }
                },
                new AppStimmer
                {
                    Title = "Besserer Spielplatz",
                    Attachments = new ObservableCollection<AppStimmerAttachment>()
                    {
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Spielplatz.jpg",
                            Description = "Das ist der alte Spielplatz.",
                            AttachmentType = AttachmentType.Picture,
                            IsMainAttachment = true
                        },
                    }
                },
                new AppStimmer
                {
                    Title = "Neuer Bahnhof",
                    Attachments = new ObservableCollection<AppStimmerAttachment>()
                    {
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Alter_Bahnhof.jpg",
                            Description = "Der Bahnhof fällt bald auseinander.",
                            AttachmentType = AttachmentType.Picture,
                            IsMainAttachment = true
                        },
                    }
                },
                new AppStimmer
                {
                    Title = "Die Hochschule sieht nicht gut aus.",
                    Attachments = new ObservableCollection<AppStimmerAttachment>()
                    {
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Alte_Schule.jpg",
                            Description = "Es gibt nicht einmal Elektrizität",
                            AttachmentType = AttachmentType.Picture,
                            IsMainAttachment = true
                        },
                    }
                },
            };

            return list;
        }
    }
}
