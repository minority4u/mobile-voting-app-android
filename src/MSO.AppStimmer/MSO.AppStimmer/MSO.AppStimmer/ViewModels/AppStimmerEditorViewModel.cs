using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MSO.Common;
using MSO.StimmApp.Core.Enums;
using MSO.StimmApp.Core.Messages;
using MSO.StimmApp.Core.Models;
using MSO.StimmApp.Core.Services;
using MSO.StimmApp.Core.ViewModels;
using MSO.StimmApp.Enums;
using MSO.StimmApp.Views.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace MSO.StimmApp.ViewModels
{
    public class AppStimmerEditorViewModel : BaseViewModel
    {
        private AppStimmer appStimmer;
        private IAppStimmerService appStimmerService;
        private bool isAddingAttachment;
        private AppStimmerEditorDisplayType displayType;
        private bool isEditable;
        private RelayCommand<AppStimmerEditorDisplayType> setDisplayModeCommand;
        private RelayCommand<ModelEditFinishedType> endEditCommand;
        private Color navigationBarBackgroundColor;
        private bool displayNavigationBarTitle;
        private string appStimmerDescription;
        private RelayCommand<EditAppStimmerTextType> editTextCommand;
        private RelayCommand saveAppStimmerCommand;

        public bool IsAddingAttachment
        {
            get => this.isAddingAttachment;
            set => this.Set(ref this.isAddingAttachment, value);
        }

        [PreferredConstructor]
        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService) :
            this(appStimmerService, new AppStimmer(), AppStimmerEditorDisplayType.Overview, isEditable: true)
        {
            //Debug.WriteLine(@"First constructor called. IsEditable: " + isEditable);
        }

        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService, AppStimmer appStimmer)
            : this(appStimmerService, appStimmer, AppStimmerEditorDisplayType.Overview, isEditable: true)
        {
            //Debug.WriteLine(@"Second constructor called. IsEditable: " + isEditable);
        }

        public AppStimmerEditorViewModel(IAppStimmerService appStimmerService, AppStimmer appStimmer,
            AppStimmerEditorDisplayType displayType, bool isEditable)
        {
            this.appStimmerService = appStimmerService;
            this.DisplayType = displayType;
            this.IsEditable = isEditable;

            if (this.IsEditable)
            {
                this.BeginAppStimmerEdit(appStimmer);
            }
            else
            {
                this.AppStimmer = appStimmer;
            }

            Messenger.Default.Register<AppStimmerAttachmentAddedMessage>(this, this.OnAppStimmerAttachmentAdded);

            var navigationBarColor = Color.FromHex(App.Settings.AppColors.PrimaryColor);
            // make navigation bar background transparent, except the buttons
            this.NavigationBarBackgroundColor = new Color(navigationBarColor.R, navigationBarColor.G, navigationBarColor.B, 0);
        }


        private void BeginAppStimmerEdit(AppStimmer apst)
        {
            this.AppStimmer = apst;
            this.AppStimmer.BeginEdit();
        }

        private void OnAppStimmerAttachmentAdded(AppStimmerAttachmentAddedMessage message)
        {
            var oldAttachments = this.AppStimmer.Attachments;
            this.AppStimmer.Attachments = new ObservableCollection<AppStimmerAttachment>(oldAttachments)
            {
                message.Attachment
            };
        }

        public AppStimmer AppStimmer
        {
            get => this.appStimmer;
            set => this.Set(ref this.appStimmer, value); 
        }

        public AppStimmer AppStimmerMediaAttachments
        {
            get => this.appStimmer;
            set => this.Set(ref this.appStimmer, value);
        }

        public Color NavigationBarBackgroundColor
        {
            get => this.navigationBarBackgroundColor;
            set => this.Set(ref this.navigationBarBackgroundColor, value);
        }

        public string AppStimmerDescription
        {
            get
            {
                foreach (var attachment in this.AppStimmer.Attachments)
                {
                    if (!attachment.IsMainAttachment && attachment.AttachmentType == AttachmentType.Text)
                    {
                        this.appStimmerDescription = attachment.AttachmentSource;
                    }
                }

                return this.appStimmerDescription;
            }
            set
            {
                foreach (var attachment in this.AppStimmer.Attachments)
                {
                    if (!attachment.IsMainAttachment && attachment.AttachmentType == AttachmentType.Text)
                    {
                        attachment.AttachmentSource = value;
                    }
                }

                this.Set(ref this.appStimmerDescription, value);
            } 
        }

        public AppStimmerEditorDisplayType DisplayType
        {
            get => this.displayType;
            set => this.Set(ref this.displayType, value);
        }

        public bool IsEditable
        {
            get => this.isEditable;
            set => this.Set(ref this.isEditable, value);
        }

        public bool DisplayNavigationBarTitle
        {
            get => this.displayNavigationBarTitle;
            set => this.Set(ref this.displayNavigationBarTitle, value);
        }

        public RelayCommand<AppStimmerEditorDisplayType> SetDisplayModeCommand => this.setDisplayModeCommand ?? (this.setDisplayModeCommand =
            new RelayCommand<AppStimmerEditorDisplayType>((type) => this.SetDisplayMode(type)));

        public RelayCommand<ModelEditFinishedType> EndEditCommand => this.endEditCommand ?? (this.endEditCommand =
            new RelayCommand<ModelEditFinishedType>((type) => this.EndEdit(type)));

        public RelayCommand<EditAppStimmerTextType> EditTextCommand => this.editTextCommand ?? (this.editTextCommand =
            new RelayCommand<EditAppStimmerTextType>((type) => this.EditText(type)));

        public RelayCommand SaveAppStimmerCommand => this.saveAppStimmerCommand ?? (this.saveAppStimmerCommand =
            new RelayCommand(this.SaveAppStimmer));

        private async void SaveAppStimmer()
        {
            if (this.IsEditable)
            {
                this.AppStimmer.EndEdit();
                await Task.Run(() => this.appStimmerService.SaveAppStimmer(this.AppStimmer));

                this.BeginAppStimmerEdit(new AppStimmer());
            }
            
            await App.NavigationService.GoBack(); 
        }

        private async void EditText(EditAppStimmerTextType type)
        {
            if (!this.IsEditable)
                return;

            var description = "Editor";
            var maxCharacters = 0;

            switch (type)
            {
                case EditAppStimmerTextType.Appstract:
                    description = "Appstract";
                    maxCharacters = 100;
                    break;
                case EditAppStimmerTextType.Title:
                    description = "Titel";
                    maxCharacters = 25;
                    break;
            }

            var viewModel = new EditAppStimmerTextViewModel(description, this.AppStimmer, type, maxCharacters);
            var page = new EditTextPopupPage(viewModel);

            await PopupNavigation.PushAsync(page);
        }

        private void SetDisplayMode(AppStimmerEditorDisplayType type)
        {
            this.DisplayType = type;
        }

        private async void EndEdit(ModelEditFinishedType type)
        {
            if (type == ModelEditFinishedType.Cancel)
            {
                this.AppStimmer.CancelEdit();
            }
            else if (type == ModelEditFinishedType.Save)
            {
                this.AppStimmer.EndEdit();
            }

            await App.NavigationService.GoBack();
        }
    }
}
