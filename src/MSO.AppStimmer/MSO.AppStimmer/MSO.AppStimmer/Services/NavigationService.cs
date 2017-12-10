using System;
using System.Collections.Generic;
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
        private readonly Dictionary<string, Type> pagesByKey = new Dictionary<string, Type>();
        private NavigationPage navigation;

        public void Initialize(NavigationPage navigationPage)
        {
            this.navigation = navigationPage;
        }

        public string CurrentPageKey
        {
            get
            {
                lock (pagesByKey)
                {
                    if (this.navigation.CurrentPage == null)
                        return null;

                    var pageType = this.navigation.CurrentPage.GetType();

                    if (!pagesByKey.ContainsValue(pageType))
                        return null;

                    var result = pagesByKey.First(p => p.Value == pageType).Key;
                    return result;
                }
            }
        }

        public void GoBack()
        {
            if (this.CanGoBack())
                this.navigation.PopAsync();
        }

        public bool CanGoBack()
        {
            var result = this.navigation?.Navigation?.NavigationStack?.Count > 1;
            return result;
        }

        public void NavigateTo(string pageKey)
        {
            this.NavigateTo(pageKey, null);
        }

        // Required for interface
        public void NavigateTo(string pageKey, object parameter)
        {
            var paramsArray = new[] { parameter };
            this.NavigateTo(pageKey, false, paramsArray);
        }

        // Two or more parameters
        public void NavigateTo(string pageKey, params object[] parametersArray)
        {
            this.NavigateTo(pageKey, false, parametersArray);
        }

        private void NavigateTo(string pageKey, bool replaceRoot, params object[] parameters)
        {
            lock (this.pagesByKey)
            {
                if (!this.pagesByKey.ContainsKey(pageKey))
                {
                    var exceptionMessage = $"No such page: {pageKey}. Did you forget to call NavigationService.Configure?";
                    throw new ArgumentException(exceptionMessage, nameof(pageKey));
                }

                var type = this.pagesByKey[pageKey];
                var constructor = ReflectionHelper.GetConstructor(type, parameters);

                if (constructor == null)
                {
                    var exceptionMessage = $"No suitable constructor found for page {pageKey}";
                    throw new InvalidOperationException(exceptionMessage);
                }

                if (!replaceRoot)
                {
                    var page = constructor.Invoke(parameters) as Page;
                    navigation.PushAsync(page, false);
                }
                else
                {
                    var page = constructor.Invoke(parameters) as Page;
                    var root = navigation.Navigation.NavigationStack.First();
                    navigation.Navigation.InsertPageBefore(page, root);
                    navigation.PopToRootAsync(false);
                }
            }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (pagesByKey)
            {
                if (pagesByKey.ContainsKey(pageKey))
                    pagesByKey[pageKey] = pageType;
                else
                    pagesByKey.Add(pageKey, pageType);
            }
        }

        public void SetNewRoot(string pageKey)
        {
            this.NavigateTo(pageKey, true);
        }
    }
}
