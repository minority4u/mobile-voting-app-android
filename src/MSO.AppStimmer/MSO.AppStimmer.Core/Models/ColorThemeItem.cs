namespace MSO.StimmApp.Core.Models
{
    public class ColorThemeItem : ModelBase
    {
        private string description;
        private ColorTheme colorTheme;

        public ColorThemeItem() : base(true)
        {
            
        }

        public string Description
        {
            get => this.description;
            set => this.Set(ref this.description, value);
        }

        public ColorTheme ColorTheme
        {
            get => this.colorTheme;
            set => this.Set(ref this.colorTheme, value);
        }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
