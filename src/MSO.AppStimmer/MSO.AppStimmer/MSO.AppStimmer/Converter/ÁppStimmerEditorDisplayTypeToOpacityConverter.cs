﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSO.StimmApp.Core.Enums;
using Xamarin.Forms;

namespace MSO.StimmApp.Converter
{
    public class ÁppStimmerEditorDisplayTypeToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var displayType = (AppStimmerEditorDisplayType)value;
            var par = parameter.ToString();

            if (displayType == AppStimmerEditorDisplayType.Overview && par == "overview")
                return 1.0;

            if (displayType == AppStimmerEditorDisplayType.Details && par == "details")
                return 1.0;

            return 0.5;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
