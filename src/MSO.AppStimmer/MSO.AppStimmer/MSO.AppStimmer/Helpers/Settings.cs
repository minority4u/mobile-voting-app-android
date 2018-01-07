// Helpers/Settings.cs

using MSO.StimmApp.Core.Models;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace MSO.StimmApp
{
    /// <summary>
    ///     This is the Settings static class that can be used in the solution.
    ///     All settings are laid out the same exact way with getters and setters.
    /// </summary>
    public class Settings : ModelBase
    {
        public Settings() : base(true)
        {

        }

        static ISettings AppSettings =>
            CrossSettings.Current;

        static Settings settings;

        public static Settings Current =>
            settings ?? (settings = new Settings());

        private const string AppColorsSettingKey = "AppColors";
        private static readonly string AppPrimaryColorsSettingDefault = JsonConvert.SerializeObject(new ColorTheme());

        public ColorTheme AppColors
        {
            get => JsonConvert.DeserializeObject<ColorTheme>(AppSettings.GetValueOrDefault(AppColorsSettingKey, AppPrimaryColorsSettingDefault));
            set
            {
                var original = AppColors;
                var colorThemeValue = JsonConvert.SerializeObject(value);

                if (AppSettings.AddOrUpdateValue(nameof(AppColors), colorThemeValue))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(AppColorsSettingKey, colorThemeValue);
            }
        }

        private const string AppStimmerAttachmentMarginKey = "AttachmentMargin";
        private static readonly string AppStimmerAttachmentMarginDefault = JsonConvert.SerializeObject(new Thickness(-30,0,0,0));

        public Thickness AttachmentMargin
        {
            get => JsonConvert.DeserializeObject<Thickness>(AppSettings.GetValueOrDefault(AppStimmerAttachmentMarginKey, AppStimmerAttachmentMarginDefault));
            set
            {
                var original = AttachmentMargin;
                var margin = JsonConvert.SerializeObject(value);

                if (AppSettings.AddOrUpdateValue(nameof(AttachmentMargin), margin))
                    this.Set(ref original, value);

                AppSettings.AddOrUpdateValue(AppStimmerAttachmentMarginKey, margin);
            }
        }
    }
}