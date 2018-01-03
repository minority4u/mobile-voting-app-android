using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MSO.Common;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Core.Services
{
    public class LocalAppStimmerService : IAppStimmerService
    {
        private const string CacheKey = "AllAppStimmerss";
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
            await this.UpdateOrAddAppStimmer(appStimmer);

            // ToDo: Proper state handling. Who sets the IsNew flag to false?
            if (appStimmer.IsNew)
            {
                appStimmer.IsNew = false;
                Messenger.Default.Send(new AppStimmerAddedMessage(appStimmer));
            }
            else
            {
                Messenger.Default.Send(new AppStimmerUpdatedMessage(appStimmer));
            }
        }

        private async Task UpdateOrAddAppStimmer(AppStimmer appStimmer)
        {
            var existingAppStimmer = this.appStimmers.FirstOrDefault(a => a.Id == appStimmer.Id);
            if (existingAppStimmer == null)
            {
                this.appStimmers.Add(appStimmer);
            }
            else
            {
                this.appStimmers.Remove(existingAppStimmer);
                this.appStimmers.Add(appStimmer);
            }

            await CacheHelper.SaveTocache(CacheKey, this.appStimmers);
        }

        public void DeleteAppStimmer(AppStimmer appStimmer)
        {
            Messenger.Default.Send(new AppStimmerDeletedMessage(appStimmer));
        }
    }
}
