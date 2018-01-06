using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using MSO.StimmApp.Droid.Renderers;
using MSO.StimmApp.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(ColoredNavigationPage), typeof(ImprovedNavigationBarRenderer))]
namespace MSO.StimmApp.Droid.Renderers
{
    class ImprovedNavigationBarRenderer : NavigationPageRenderer
    {
        public ImprovedNavigationBarRenderer(Context context) : base(context)
        {
           
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            Element page = Element.Parent;
            MasterDetailPage masterDetailPage = null;
            while (page != null)
            {
                if (page is MasterDetailPage)
                {
                    masterDetailPage = page as MasterDetailPage;
                    break;
                }

                page = page.Parent;
            }

            if (masterDetailPage == null)
            {
                return;
            }

            var renderer = Platform.GetRenderer(masterDetailPage) as MasterDetailPageRenderer;
            if (renderer == null)
            {
                return;
            }

            var drawerLayout = (DrawerLayout)renderer;
            Android.Support.V7.Widget.Toolbar toolbar = null;

            for (int i = 0; i < ChildCount; i++)
            {
                var child = GetChildAt(i);
                toolbar = child as Android.Support.V7.Widget.Toolbar;
                if (toolbar != null)
                {
                    break;
                }
            }

            toolbar?.SetNavigationOnClickListener(new MenuClickListener(Element, drawerLayout));
        }

        private class MenuClickListener : Java.Lang.Object, IOnClickListener
        {
            readonly NavigationPage navigationPage;
            private DrawerLayout layout;

            public MenuClickListener(NavigationPage navigationPage, DrawerLayout layout)
            {
                this.navigationPage = navigationPage;
                this.layout = layout;
            }

            public void OnClick(View v)
            {
                var page = navigationPage.CurrentPage as ContentPage;
                if (navigationPage.Navigation.NavigationStack.Count <= 1)
                {
                    layout.OpenDrawer((int)GravityFlags.Left);
                }

                if (page != null)
                {
                    App.NavigationService.GoBack();
                }
            }
        }
    }
}