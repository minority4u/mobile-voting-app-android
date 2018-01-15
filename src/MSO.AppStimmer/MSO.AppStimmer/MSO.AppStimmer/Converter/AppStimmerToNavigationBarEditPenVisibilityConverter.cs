using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSO.StimmApp.Converter
{
    public class AppStimmerToNavigationBarEditPenVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values?[0] == null || values[1] == null)
                return false;

            var displayNavigationBarTitle = (bool) values[0];
            var isAppStimmerEditable = (bool) values[1];

            if (!displayNavigationBarTitle || !isAppStimmerEditable)
                return false;

            return true;

        }
    }
}
