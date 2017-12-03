﻿using GalaSoft.MvvmLight;
using MSO.StimmApp.Core.Helpers;

namespace MSO.StimmApp.Core.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        public Settings Settings => Settings.Current;

        private bool isBusy;

        public bool IsBusy
        {
            get => this.isBusy;
            set => this.Set(ref this.isBusy, value);
        }
    }
}
