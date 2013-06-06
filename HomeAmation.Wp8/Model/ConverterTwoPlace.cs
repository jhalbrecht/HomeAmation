using System;
using System.Globalization;
using System.Windows.Data;

namespace HomeAmation.Model
{

        public class ConverterTwoPlace : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                float myval = (float)value;
                return myval.ToString("F2");
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {

                throw new NotImplementedException();
            }
        }
    }

