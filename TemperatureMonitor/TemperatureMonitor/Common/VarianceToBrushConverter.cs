using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace TemperatureMonitor.Common
{
    [ValueConversion(typeof(string), typeof(Brush))]
    class VarianceToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double variance;

            string varianceText = (string)value;
            Regex r = new Regex(@"\((?<Variance>\d*)\)");

            if (r.IsMatch(varianceText))
                variance = double.Parse(r.Match(varianceText).Groups[1].Value);
            else
                variance = double.Parse(varianceText);

            if (variance <= 5 && variance >= -5)
                return Brushes.Green;
            else if (variance <= 10 && variance >= -10)
                return Brushes.Yellow;
            else
                return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
