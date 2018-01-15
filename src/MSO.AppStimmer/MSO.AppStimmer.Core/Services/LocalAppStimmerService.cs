using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MSO.Common;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Core.Services
{
    public class LocalAppStimmerService : IAppStimmerService
    {
        private const string CacheKey = "AllAppStimmerCache1";
        private List<AppStimmer> appStimmers = new List<AppStimmer>();

        public async Task<List<AppStimmer>> GetAllAppStimmers()
        {
            var isInCache = await CacheHelper.IsIncache<List<AppStimmer>>(CacheKey);
            if (!isInCache)
            {
                this.appStimmers = new List<AppStimmer>();
                await CacheHelper.SaveTocache(CacheKey, this.appStimmers);
            }
            else
            {
                this.appStimmers = await CacheHelper.GetFromCache<List<AppStimmer>>(CacheKey);
            }

            return this.appStimmers;
        }

        public async void SaveAppStimmer(AppStimmer appStimmer)
        {
            if (appStimmer.IsNew)
            {
                appStimmer.IsNew = false;
                Messenger.Default.Send(new AppStimmerAddedMessage(appStimmer));
            }
            else
            {
                Messenger.Default.Send(new AppStimmerUpdatedMessage(appStimmer));
            }

            await this.UpdateOrAddAppStimmer(appStimmer);
        }

        private async Task UpdateOrAddAppStimmer(AppStimmer appStimmer)
        {
            var existingAppStimmer = this.appStimmers.FirstOrDefault(a => a.Id == appStimmer.Id);
            if (existingAppStimmer != null)
            {
                var index = this.appStimmers.IndexOf(existingAppStimmer);
                this.appStimmers[index] = appStimmer;
            }
            else
            {
                this.appStimmers.Add(appStimmer);
            }

            await CacheHelper.SaveTocache(CacheKey, this.appStimmers);
        }

        public void DeleteAppStimmer(AppStimmer appStimmer)
        {
            Messenger.Default.Send(new AppStimmerDeletedMessage(appStimmer));
        }


        /// <summary>
        ///     This method is for testing purposes only.
        ///     // ToDo Delete later!
        /// </summary>
        /// <returns></returns>
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
