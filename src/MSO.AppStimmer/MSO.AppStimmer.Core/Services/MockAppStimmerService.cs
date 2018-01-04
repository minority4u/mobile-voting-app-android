using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Core.Services
{
    public class MockAppStimmerService : IAppStimmerService
    {
        private readonly List<AppStimmer> appStimmers;

        public MockAppStimmerService()
        {
            this.appStimmers = this.GetRandomAppStimmers();
        }

        public async Task<List<AppStimmer>> GetAllAppStimmers()
        {
            var result = await Task.Run(() => this.GetAppStimmers());
            return result;
        }

        private List<AppStimmer> GetAppStimmers()
        {
            return this.appStimmers;
        }

        public void SaveAppStimmer(AppStimmer appStimmer)
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

            this.UpdateOrAddAppStimmer(appStimmer);
        }

        private void UpdateOrAddAppStimmer(AppStimmer appStimmer)
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
        }

        public void DeleteAppStimmer(AppStimmer appStimmer)
        {
            Messenger.Default.Send(new AppStimmerDeletedMessage(appStimmer));
        }

        private List<AppStimmer> GetRandomAppStimmers()
        {
            var list = new List<AppStimmer>()
            {
                new AppStimmer
                {
                    IsNew = false,
                    Title = "Parkbänke voller Moos",
                    Picture ="MSO.StimmApp.Resources.Images.Kaputte_Parkbank.jpg",
                    Appstract = "Alle Parkbänke verfaulen langsam. Es sollten neue gebaut werden.",
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
                    IsNew = false,
                    Title = "Besserere Spielplätze",
                    Picture ="MSO.StimmApp.Resources.Images.Spielplatz.jpg",
                    Appstract = "Unsere Kinder sitzen nur noch am PC. Wir brauchen neue Spielplätze, damit sie mal rauskommen.",
                    Description = "Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that\'s what you see at a toy store. And you must think you\'re in a toy store, because you\'re here shopping for an infant named Jeb.",
                },
                new AppStimmer
                {
                    IsNew = false,
                    Title = "Neuer Bahnhof",
                    Picture ="MSO.StimmApp.Resources.Images.Alter_Bahnhof.jpg",
                    Appstract = "Unser Bahnhof ist in die Jahre gekommen. Es wird Zeit, einen neuen zu bauen!",
                    Description = "Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that\'s what you see at a toy store. And you must think you\'re in a toy store, because you\'re here shopping for an infant named Jeb.",
                },
                new AppStimmer
                {
                    IsNew = false,
                    Title = "Neue Hochschule",
                    Picture ="MSO.StimmApp.Resources.Images.Alte_Schule.jpg",
                    Appstract = "Die städtische Hochschule ist zu klein, und nicht modern genug. Es muss eine neue gebaut werden!",
                    Description = "Do you see any Teletubbies in here? Do you see a slender plastic tag clipped to my shirt with my name printed on it? Do you see a little Asian child with a blank expression on his face sitting outside on a mechanical helicopter that shakes when you put quarters in it? No? Well, that\'s what you see at a toy store. And you must think you\'re in a toy store, because you\'re here shopping for an infant named Jeb.",
                },

                new AppStimmer
                {
                    IsNew = false,
                    Title = "Kreisverkehr an der B3",
                    Picture ="MSO.StimmApp.Resources.Images.Appstimmer1.png",
                    Appstract = "Neuer Kreisverkehr an der B3 Dorfeinfahrtsstraße.",
                    Description = "An der Dorfeinfahrtsstraße von der B3 kommt es die ganze Zeit zu Unfällen verursacht durch Raser. Letzte Woche gab es schon wieder ein Tödlicher Unfall. Es muss endlich ein Kreisverkehr gebaut werden. ",
                },

                new AppStimmer
                {
                    IsNew = false,
                    Title = "Schwimmbad Sanierung",
                    Picture ="MSO.StimmApp.Resources.Images.Appstimmer2.png",
                    Appstract = "Schwimmbad muss dringend saniert werden.",
                    Description = "Es gibt keine Gelegenheit mehr, mal schnell ein paar Bahnen zu schwimmen seit dem das Hallenbad geschlossen wurde. Zudem ist das nächste Hallenbad 25 min entfernt und daher keine Option nach dem Feierabend für viele Menschen.",
                },

                new AppStimmer
                {
                    IsNew = false,
                    Title = "Müll in der Fußgängerzone",
                    Picture ="MSO.StimmApp.Resources.Images.Appstimmer3.png",
                    Appstract = "Bitte einmal die Fußgängerzone fegen lassen.",
                    Description = "Die Fußgängerzone wird zu wenig gesäubert, der Müll sammelt sich immer häufiger an bevor dieses weggeräumt wird, das macht die Fußgängerzone unattraktiv und weniger Leute gehen einkaufen.",
                    Attachments = new ObservableCollection<AppStimmerAttachment>()
                    {
                        new AppStimmerAttachment
                        {
                            AttachmentSource = "MSO.StimmApp.Resources.Images.Appstimmer3_1.png",
                            AttachmentType = AttachmentType.Picture,
                        }
                        }
                },
                new AppStimmer
                {
                    IsNew = false,
                    Title = "Grafitti am Bahnhof",
                    Picture ="MSO.StimmApp.Resources.Images.Appstimmer4.png",
                    Appstract = "Entfernt bitte das Grafitti!",
                    Description = "Entfernt bitte das unsägliche Penis Graffiti vom Bahnhof. Das ist eine Schande für unser Dorf! Jeden Tag muss ich daran vorbeilaufen.",
                },

                new AppStimmer
                {
                    IsNew = false,
                    Title = "Dunkel wie im Mittelalter",
                    Picture ="MSO.StimmApp.Resources.Images.Appstimmer5.png",
                    Appstract = "Wir brauichen mehr Straßenlaternen in unserer Gemeinde.",
                    Description = "In der Scheuchzerstraße stehen zu wenig Strassenlaternen. Es ist einfach zu dunkel. Nachts traue ich mich kaum mehr aus dem Haus. ",
                },


            };

            return list;
        }
    }
}
