using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp
{
    public class GradientLabel : Label
    { 
        public Color StartColor { get; set; }
        public Color EndColor { get; set; } 
    }
}
