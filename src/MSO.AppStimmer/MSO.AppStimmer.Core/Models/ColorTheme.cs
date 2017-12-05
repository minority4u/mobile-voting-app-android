using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.StimmApp.Core.Models
{
    public class ColorTheme : ModelBase
    {
        private string appPrimaryColor = "#F9C470";

        public ColorTheme() : base(true)
        {
            
        }

        public string AppPrimaryColor
        {
            get => this.appPrimaryColor;
            set => this.Set(ref this.appPrimaryColor, value);
        }
    }
}
