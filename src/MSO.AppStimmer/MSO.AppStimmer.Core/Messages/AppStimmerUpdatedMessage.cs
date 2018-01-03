using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Core.Messages
{
    public class AppStimmerUpdatedMessage
    {
        public AppStimmerUpdatedMessage(AppStimmer appStimmer)
        {
            this.AppStimmer = appStimmer;
        }

        public AppStimmer AppStimmer;
    }
}
