using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Elements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubmitButton : ContentView
    {
        public SubmitButton()
        {
            this.InitializeComponent();
        }
    }
}