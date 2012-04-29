using System;
using System.Windows.Data;

namespace MoveIt.Helpers.Converters
{
    public class TimespanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TimeSpan timeSpan = value is TimeSpan ? (TimeSpan)value : new TimeSpan();
            return getDisplay(timeSpan.Hours) + ":" + getDisplay(timeSpan.Minutes) + ":" + getDisplay(timeSpan.Seconds);
        }

        private string getDisplay(int value)
        {
            if (value < 10) return "0" + value;
            if (value > 99) return "99";
            return "" + value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // TODO: Add error checking
            string countdown = value as string;

            string[] timeSpanStrings = countdown.Split(':');

            int hours = System.Convert.ToInt32(timeSpanStrings[0]);
            int minutes = System.Convert.ToInt32(timeSpanStrings[1]);
            int seconds = System.Convert.ToInt32(timeSpanStrings[2]);
            var timeSpan = new TimeSpan(hours, minutes, seconds);

            return timeSpan;
        }
    }
}
