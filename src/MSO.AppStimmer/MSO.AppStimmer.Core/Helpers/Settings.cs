// Helpers/Settings.cs

using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MSO.StimmApp.Core.Helpers
{
    /// <summary>
    ///     This is the Settings static class that can be used in the solution.
    ///     All settings are laid out the same exact way with getters and setters.
    /// </summary>
    public class Settings : Models.ModelBase
    {
        static ISettings AppSettings =>
            CrossSettings.Current;

        static Settings settings;

        public static Settings Current =>
            settings ?? (settings = new Settings());

        private const string AppPrimaryColorSettingsKey = "PrimaryColor";
        private static readonly string AppPrimaryColorSettingsDefault = "#F9C470";

        public string AppPrimaryColor
        {
            get => AppSettings.GetValueOrDefault(AppPrimaryColorSettingsKey, AppPrimaryColorSettingsDefault);
            set
            {
                var original = AppPrimaryColor;
                if (AppSettings.AddOrUpdateValue(nameof(AppPrimaryColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(AppPrimaryColorSettingsKey, value);
            }
        }

        private const string SecondaryColorSettingsKey = "SecondaryColor";
        private static readonly string SecondaryColorSettingsDefault = "#F1F4F6";

        public string SecondaryColor
        {
            get => AppSettings.GetValueOrDefault(SecondaryColorSettingsKey, SecondaryColorSettingsDefault);
            set
            {
                var original = SecondaryColor;
                if (AppSettings.AddOrUpdateValue(nameof(SecondaryColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(SecondaryColor, value);
            }
        }

        private const string MenuPageColorSettingsKey = "MenuPageColor";
        private static readonly string MenuPageColorSettingsDefault = "#AA000000";

        public string MenuPageColor
        {
            get => AppSettings.GetValueOrDefault(MenuPageColorSettingsKey, MenuPageColorSettingsDefault);
            set
            {
                var original = MenuPageColor;
                if (AppSettings.AddOrUpdateValue(nameof(MenuPageColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(MenuPageColor, value);
            }
        }

        private const string BottomActionBarColorSettingsKey = "BottomActionBarColor";
        private static readonly string BottomActionBarColorSettingsDefault = "#88FFFFFF";

        public string BottomActionBarColor
        {
            get => AppSettings.GetValueOrDefault(BottomActionBarColorSettingsKey, BottomActionBarColorSettingsDefault);
            set
            {
                var original = BottomActionBarColor;
                if (AppSettings.AddOrUpdateValue(nameof(BottomActionBarColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(BottomActionBarColor, value);
            }
        }

        private const string SimpleControlsColorSettingsKey = "SimpleControlsColor";
        private static readonly string SimpleControlsColorSettingsDefault = "#A9A9A9";

        public string SimpleControlsColor
        {
            get => AppSettings.GetValueOrDefault(SimpleControlsColorSettingsKey, SimpleControlsColorSettingsDefault);
            set
            {
                var original = SimpleControlsColor;
                if (AppSettings.AddOrUpdateValue(nameof(SimpleControlsColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(SimpleControlsColor, value);
            }
        }

        private const string ListViewHeaderColorColorSettingsKey = "ListViewHeaderColorColor";
        private static readonly string ListViewHeaderColorColorSettingsDefault = "#808080";

        public string ListViewHeaderColorColor
        {
            get => AppSettings.GetValueOrDefault(ListViewHeaderColorColorSettingsKey, ListViewHeaderColorColorSettingsDefault);
            set
            {
                var original = ListViewHeaderColorColor;
                if (AppSettings.AddOrUpdateValue(nameof(ListViewHeaderColorColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(ListViewHeaderColorColor, value);
            }
        }


        private const string AppStimmerAttachmentItemColorSettingsKey = "AppStimmerAttachmentItemBackgroundColor";
        private static readonly string AppStimmerAttachmentItemColorSettingsDefault = "#FFFFFF";

        public string AppStimmerAttachmentItemColor
        {
            get => AppSettings.GetValueOrDefault(AppStimmerAttachmentItemColorSettingsKey, AppStimmerAttachmentItemColorSettingsDefault);
            set
            {
                var original = AppStimmerAttachmentItemColor;
                if (AppSettings.AddOrUpdateValue(nameof(AppStimmerAttachmentItemColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(AppStimmerAttachmentItemColor, value);
            }
        }

        private const string AppStimmersItemColorSettingsKey = "AppStimmersItemBackgroundColor";
        private static readonly string AppStimmersItemColorSettingsDefault = "#FFFFFF";

        public string AppStimmersItemColor
        {
            get => AppSettings.GetValueOrDefault(AppStimmersItemColorSettingsKey, AppStimmersItemColorSettingsDefault);
            set
            {
                var original = AppStimmersItemColor;
                if (AppSettings.AddOrUpdateValue(nameof(AppStimmersItemColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(AppStimmersItemColor, value);
            }
        }

        private const string PopupColorSettingsKey = "PopupColor";
        private static readonly string PopupColorSettingsDefault = "#FFFFFF";

        public string PopupColor
        {
            get => AppSettings.GetValueOrDefault(PopupColorSettingsKey, PopupColorSettingsDefault);
            set
            {
                var original = PopupColor;
                if (AppSettings.AddOrUpdateValue(nameof(PopupColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(PopupColor, value);
            }
        }

        private const string ActiveTabIndicatorColorSettingsKey = "ActiveTabIndicatorColor";
        private static readonly string ActiveTabIndicatorColorSettingsDefault = "#FFFFFF";

        public string ActiveTabIndicatorColor
        {
            get => AppSettings.GetValueOrDefault(ActiveTabIndicatorColorSettingsKey, ActiveTabIndicatorColorSettingsDefault);
            set
            {
                var original = ActiveTabIndicatorColor;
                if (AppSettings.AddOrUpdateValue(nameof(ActiveTabIndicatorColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(ActiveTabIndicatorColor, value);
            }
        }
    }
}