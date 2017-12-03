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
            get
            {
                var setting = AppSettings.GetValueOrDefault(AppPrimaryColorSettingsKey, AppPrimaryColorSettingsDefault);
                return setting;
            }
            set
            {
                var original = AppPrimaryColor;
                if (AppSettings.AddOrUpdateValue(nameof(AppPrimaryColor), value))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(AppPrimaryColorSettingsKey, value);
            }
        }

    }
}