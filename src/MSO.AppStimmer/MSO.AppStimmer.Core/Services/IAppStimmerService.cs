using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Core.Services
{
    public interface IAppStimmerService
    {
        Task<List<AppStimmer>> GetAllAppStimmers();

        void SaveAppStimmer(AppStimmer appStimmer);

        void DeleteAppStimmer(AppStimmer appStimmer);
    }
}
