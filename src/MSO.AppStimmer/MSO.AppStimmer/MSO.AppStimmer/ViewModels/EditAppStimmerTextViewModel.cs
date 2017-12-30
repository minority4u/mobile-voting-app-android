using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.ViewModels;
using MSO.StimmApp.Enums;
using MSO.StimmApp.Services;
using Rg.Plugins.Popup.Services;

namespace MSO.StimmApp.ViewModels
{
    public class EditAppStimmerTextViewModel : BaseViewModel
    {
        private string text;
        private int maxCharacters;
        private string editorDescription;
        private int charactersCount;
        private AppStimmer appStimmer;
        private RelayCommand saveTextCommand;
        private EditAppStimmerTextType textType;
        
        public EditAppStimmerTextViewModel(string editorDescription, AppStimmer appStimmer, 
            EditAppStimmerTextType textType, int maxCharacters)
        {
            this.EditorDescription = editorDescription;
            this.AppStimmer = appStimmer;          
            this.MaxCharacters = maxCharacters;
            this.textType = textType;
            
            switch (textType)
            {
                case EditAppStimmerTextType.Title:
                    this.Text = this.AppStimmer.Title;
                    break;
                case EditAppStimmerTextType.Appstract:
                    this.Text = this.AppStimmer.Appstract;
                    break;
            }
        }

        public RelayCommand SaveTextCommand => this.saveTextCommand ?? (this.saveTextCommand =
            new RelayCommand(this.SaveText));

        public bool FinishedEdit { get; set; } = false;

        private async void SaveText()
        {
            switch (this.textType)
            {
                case EditAppStimmerTextType.Title:
                    this.AppStimmer.Title = this.Text;
                    break;
                case EditAppStimmerTextType.Appstract:
                    this.AppStimmer.Appstract = this.Text;
                    break;
            }

            this.FinishedEdit = true;
            await PopupNavigation.PopAsync(true);          
        }

        public string Text
        {
            get => this.text;
            set
            {
                this.Set(ref this.text, value);
                this.CharactersCount = value.Length; 
            } 
        }

        public string EditorDescription
        {
            get => this.editorDescription;
            set => this.Set(ref this.editorDescription, value);
        }

        public AppStimmer AppStimmer
        {
            get => this.appStimmer;
            set => this.Set(ref this.appStimmer, value);
        }

        public int MaxCharacters
        {
            get => this.maxCharacters;
            set => this.Set(ref this.maxCharacters, value);
        }

        public int CharactersCount
        {
            get => this.charactersCount;
            set => this.Set(ref this.charactersCount, value);
        }
    }
}
