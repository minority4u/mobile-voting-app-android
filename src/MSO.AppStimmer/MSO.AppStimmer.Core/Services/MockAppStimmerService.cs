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
                    Appstract = "Die Straße sieht beschissen aus.",
                    Description = "Das Loch muss repatiert werden. Außerdem muss die Straße " +
                                  "neu geteert werden. Und sie muss doppelt so breit werden.",
                    Picture = "MSO.StimmApp.Resources.Images.Schlagloch.jpg",
                    Attachments = new ObservableCollection<AppStimmerAttachment>()
                    {
                        new AppStimmerAttachment
                        {
                            Source = "MSO.StimmApp.Resources.Images.Schlagloch.jpg",
                            Description = "Bildbeschreibung",
                            AttachmentType = AttachmentType.Picture
                        },
                        new AppStimmerAttachment
                        {
                            Source = "Dies ist ein Text.",
                            Description = "Dies ist ein Text.",
                            AttachmentType = AttachmentType.Text
                        }
                    }                   
                },
                new AppStimmer
                {
                    Title = "Parkbank fault",
                    Appstract = "Die Parkbank ist kaum mehr benutzbar.",
                    Description = "Wir wollen neue Parkbänke. Aus Gold. Mit eingearbeiteten Rubinen.",
                    Picture = "MSO.StimmApp.Resources.Images.Kaputte_Parkbank.jpg"
                },
                new AppStimmer
                {
                    Title = "Besserer Spielplatz",
                    Appstract = "Der aktuelle Spielplatz reicht nicht.",
                    Description = "Es fehlen Rutschen. Und ein Swimming Pool. Und ein paar Rechner, zum LAN-Party machen.",
                    Picture = "MSO.StimmApp.Resources.Images.Spielplatz.jpg"
                },
                new AppStimmer
                {
                    Title = "Bahnhof",
                    Appstract = "Der Bahnhof muss erneuert werden.",
                    Description = "Der Bahnhof fällt bald zusammen. Das wäre doof.",
                    Picture = "MSO.StimmApp.Resources.Images.Alter_Bahnhof.jpg"
                },
                new AppStimmer
                {
                    Title = "Neue Hochschule",
                    Appstract = "Der Hochschule muss erneuert werden.",
                    Description = "Alle Hörsäle sehen ein bisschen als aus. Sollte man mal neu machen.",
                    Picture = "MSO.StimmApp.Resources.Images.Alte_Schule.jpg"
                },
            };

            return list;
        }
    }
}
