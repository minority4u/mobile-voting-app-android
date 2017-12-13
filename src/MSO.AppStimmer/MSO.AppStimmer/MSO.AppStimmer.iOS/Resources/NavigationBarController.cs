using System;
using MSO.AppStimmer.iOS.Resources;
using MSO.StimmApp.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(NavigationBarController))]
namespace MSO.AppStimmer.iOS.Resources
{
    public class NavigationBarController: INavigationBarController
    {
        public void SetStatusBarColor(Xamarin.Forms.Color color)
        {
            throw new NotImplementedException();
        }

        public Color Color
        {
            get { return Color; }
            set
            {
                this.SetStatusBarColor(value);
            }
        }

        public bool IsVisible { get; set; }

        public int Height { get; set; }
        public int ScreenHeight { get; }
        public void HideNavigationBar()
        {
            throw new NotImplementedException();
        }
    }
}