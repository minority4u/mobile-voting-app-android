using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSO.StimmApp.Helpers
{
    public interface INavigationBarController
    {
        Color Color { get; set; }

        int Height { get; }

        int ScreenHeight { get; }
    }
}
