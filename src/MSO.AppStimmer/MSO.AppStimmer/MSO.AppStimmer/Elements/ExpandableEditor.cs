using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Elements
{
    public class ExpandableEditor : Editor
    {
        public ExpandableEditor()
        {
            this.TextChanged += (sender, e) => { this.InvalidateMeasure(); };
        }
    }
}
