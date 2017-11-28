using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSO.StimmApp.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppStimmersListView : ListView
    {
        public AppStimmersListView()
        {
            this.InitializeComponent();
        }
    }
}