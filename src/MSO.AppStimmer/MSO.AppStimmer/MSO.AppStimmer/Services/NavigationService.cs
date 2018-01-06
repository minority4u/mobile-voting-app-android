using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MSO.Common;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace MSO.StimmApp.Services
{
    /// <summary>
    ///     This is the NavigationService implementation for the navigation between pages of the App.
    /// </summary>
    public class NavigationService : INavigationService
    {
        private NavigationPage navigation;

        private uint fadeOutLength = 250;
        private uint fadeInLength = 150;

        private Easing easing = Easing.Linear;
        private string animationName = "PageExitAnimation";

        public void Initialize(NavigationPage navigationPage)
        {
            this.navigation = navigationPage;
        }

        public async Task GoBack(bool animated = true)
        {
            if (!this.CanGoBack())
                return;

            if (!animated)
            {
                await this.navigation.PopAsync(true);
            }
            else
            {
                this.NavigateBackAnimated();
            }        
        }

        public bool CanGoBack()
        {
            var result = this.navigation?.Navigation?.NavigationStack?.Count > 1;
            return result;
        }

        public async Task NavigateTo(Page page, bool animated = true, bool replaceRoot = false)
        {
            if (!replaceRoot)
            {
                if (!animated)
                {
                    await navigation.PushAsync(page, true);
                }
                else
                {
                    this.NavigateToAnimated(page);
                }
            }
            else
            {
                NavigateToNewRootAnimated(page, animated);
            }
        }

        public async Task SetNewRoot(Page page)
        {
            await this.NavigateTo(page, false, true);
        }


        private void NavigateToNewRootAnimated(Page page, bool animated)
        {
            var fadeOutAction = new Action<double>((v) =>
            {
                this.navigation.CurrentPage.Opacity = v / 100;
            });

            var fadeInAction = new Action<double, bool>(async (d, b) =>
            {
                page.Opacity = 0;

                var root = navigation.Navigation.NavigationStack.First();
                navigation.Navigation.InsertPageBefore(page, root);

                await navigation.PopToRootAsync(animated);
                page.FadeTo(1, this.fadeInLength, this.easing);
            });

            var owner = page;
            var rate = 1U;

            var animation = new Animation(fadeOutAction, 100, 0, Easing.Linear);
            animation.Commit(owner, this.animationName, rate, this.fadeOutLength, this.easing, fadeInAction);
        }

        private void NavigateBackAnimated()
        {
            var fadeOutAction = new Action<double>((v) =>
            {
                this.navigation.CurrentPage.Opacity = v / 100;
            });

            var fadeInAction = new Action<double, bool>(async (d, b) =>
            {
                await this.navigation.PopAsync(true);

                var newPage = this.navigation.CurrentPage;
                newPage.Opacity = 0;

                newPage.FadeTo(1, this.fadeInLength, this.easing);
            });

            var owner = this.navigation.CurrentPage;
            var rate = 1U;

            var animation = new Animation(fadeOutAction, 100, 0, Easing.Linear);
            animation.Commit(owner, this.animationName, rate, this.fadeOutLength, this.easing, fadeInAction);
        }

        private void NavigateToAnimated(Page page)
        {
            var fadeOutAction = new Action<double>((v) =>
            {
                this.navigation.CurrentPage.Opacity = v / 100;
            });

            var fadeInAction = new Action<double, bool>(async (d, b) =>
            {
                page.Opacity = 0;
                navigation.PushAsync(page, true);             
                page.FadeTo(1, this.fadeInLength, this.easing);
            });

            var owner = page;
            var rate = 1U;

            var animation = new Animation(fadeOutAction, 100, 0, Easing.Linear);
            animation.Commit(owner, this.animationName, rate, this.fadeOutLength, this.easing, fadeInAction);
        }
    }
}
