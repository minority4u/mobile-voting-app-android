using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace MSO.AppStimmer.Core.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        private bool isBusy;

        public bool IsBusy
        {
            get => this.isBusy;
            set => this.Set(ref this.isBusy, value);
        }
    }
}
