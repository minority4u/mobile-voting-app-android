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
                    Picture = "MSO.StimmApp.Resources.Images.Photo.jpg",
                    Appstract = "Die Straßen im Dorf haben viele Löcher. Sie müssen gestopft werden.",
                    Description = "Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that\'s what you see at a toy store. And you must think you\'re in a toy store, because you\'re here shopping for an infant named Jeb.",

                    Attachments = new ObservableCollection<AppStimmerAttachment>()
                    {
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "https://googlechrome.github.io/samples/picture-element/images/butterfly.jpg",
                            AttachmentType = AttachmentType.Picture,
                        },
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Kaputte_Parkbank.jpg",
                            Description = "So sieht die Bank aus.",
                            AttachmentType = AttachmentType.Picture,
                        },
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Kaputte_Parkbank.jpg",
                            Description = "So sieht die Bank aus.",
                            AttachmentType = AttachmentType.Picture,
                        },
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Kaputte_Parkbank.jpg",
                            Description = "So sieht die Bank aus.",
                            AttachmentType = AttachmentType.Picture,
                        },
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "http://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4",
                            Description = "Dies ist ein cooles Video",
                            AttachmentType = AttachmentType.Video
                        },
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Kaputte_Parkbank.jpg",
                            Description = "So sieht die Bank aus.",
                            AttachmentType = AttachmentType.Picture,
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
                    Title = "Parkbänke voller Moos",
                    Picture ="MSO.StimmApp.Resources.Images.Kaputte_Parkbank.jpg",
                    Appstract = "Alle Parkbänke verfaulen langsam. Es sollten neue gebaut werden.",
                    Description = "Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that\'s what you see at a toy store. And you must think you\'re in a toy store, because you\'re here shopping for an infant named Jeb.",               
                },
                new AppStimmer
                {
                    Title = "Besserere Spielplätze",
                    Picture ="MSO.StimmApp.Resources.Images.Spielplatz.jpg",
                    Appstract = "Unsere Kinder sitzen nur noch am PC. Wir brauchen neue Spielplätze, damit sie mal rauskommen.",
                    Description = "Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that\'s what you see at a toy store. And you must think you\'re in a toy store, because you\'re here shopping for an infant named Jeb.",
                },
                new AppStimmer
                {
                    Title = "Neuer Bahnhof",
                    Picture ="MSO.StimmApp.Resources.Images.Alter_Bahnhof.jpg",
                    Appstract = "Unser Bahnhof ist in die Jahre gekommen. Es wird Zeit, einen neuen zu bauen!",
                    Description = "Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that\'s what you see at a toy store. And you must think you\'re in a toy store, because you\'re here shopping for an infant named Jeb.",
                },
                new AppStimmer
                {
                    Title = "Neue Hochschule",
                    Picture ="MSO.StimmApp.Resources.Images.Alte_Schule.jpg",
                    Appstract = "Die städtische Hochschule ist zu klein, und nicht modern genug. Es muss eine neue gebaut werden!",
                    Description = "Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that\'s what you see at a toy store. And you must think you\'re in a toy store, because you\'re here shopping for an infant named Jeb.",
                },
            };

            return list;
        }
    }
}
