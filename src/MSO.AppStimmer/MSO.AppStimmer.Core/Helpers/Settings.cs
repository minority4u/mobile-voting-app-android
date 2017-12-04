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

        private const string MenuPageBackgroundColorSettingsKey = "MenuPageBackgroundColor";
        private static readonly string MenuPageBackgroundColorSettingsDefault = "#AA000000";

        public string MenuPageBackgroundColor
        {
            get => AppSettings.GetValueOrDefault(MenuPageBackgroundColorSettingsKey, MenuPageBackgroundColorSettingsDefault);
            set
            {
                var original = MenuPageBackgroundColor;
                if (AppSettings.AddOrUpdateValue(nameof(MenuPageBackgroundColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(MenuPageBackgroundColor, value);
            }
        }
    }
}