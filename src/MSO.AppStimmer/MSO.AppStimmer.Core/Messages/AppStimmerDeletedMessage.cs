using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Models;

namespace MSO.StimmApp.Core.Messages
{
    public class AppStimmerDeletedMessage
    {
        public AppStimmerDeletedMessage(AppStimmer appStimmer)
        {
            this.AppStimmer = appStimmer;
        }

        public AppStimmer AppStimmer;
    }
}
