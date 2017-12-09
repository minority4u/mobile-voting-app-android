using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;

namespace MSO.StimmApp.Services
{
    public interface INavigationService
    {
        //
        // Summary:
        //     The key corresponding to the currently displayed page.
        string CurrentPageKey { get; }

        //
        // Summary:
        //     If possible, instructs the navigation service to discard the current page and
        //     display the previous page on the navigation stack.
        void GoBack();
        //
        // Summary:
        //     Instructs the navigation service to display a new page corresponding to the given
        //     key. Depending on the platforms, the navigation service might have to be configured
        //     with a key/page list.
        //
        // Parameters:
        //   pageKey:
        //     The key corresponding to the page that should be displayed.
        void NavigateTo(string pageKey);
        //
        // Summary:
        //     Instructs the navigation service to display a new page corresponding to the given
        //     key, and passes a parameter to the new page. Depending on the platforms, the
        //     navigation service might have to be Configure with a key/page list.
        //
        // Parameters:
        //   pageKey:
        //     The key corresponding to the page that should be displayed.
        //
        //   parameter:
        //     The parameter that should be passed to the new page.
        //void NavigateTo(string pageKey, object parameter);

        //// Open new PopupPage
        //Task PushAsync(PopupPage page, bool animate = true); // Navigation.PushPopupAsync

        //// Hide last PopupPage
        //Task PopAsync(bool animate = true); // Navigation.PopPopupAsync

        //// Hide all PopupPage with animations
        //Task PopAllAsync(bool animate = true); // Navigation.PopAllPopupAsync

        //// Remove one popup page in stack
        //Task RemovePageAsync(PopupPage page, bool animate = true); // Navigation.RemovePopupPageAsync
    }
}
