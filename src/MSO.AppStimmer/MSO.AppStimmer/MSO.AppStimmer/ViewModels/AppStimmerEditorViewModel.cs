using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.Services;
using MSO.StimmApp.Core.ViewModels;

namespace MSO.StimmApp.ViewModels
{
    public class AppStimmerEditorViewModel : BaseViewModel
    {
        private AppStimmer appStimmer;
        private IAppStimmerService appStimmerService;

        [PreferredConstructor]
        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService) :
            this(appStimmerService, new AppStimmer())
        {
            
        }

        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService, AppStimmer appStimmer)
        {
            this.appStimmerService = appStimmerService;
            this.appStimmer = appStimmer;
        }

        public AppStimmer AppStimmer
        {
            get => this.appStimmer;
            set => this.Set(ref this.appStimmer, value);
        }
    }
}
