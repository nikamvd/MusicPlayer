using System;
using System.Globalization;
using System.Text;

namespace MusicPlayer.Converters
{
    public enum Format
    {
        CurrentTime,
        RemainingTime
    }

    public class SecondsToStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, System.Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 3 || !targetType.IsAssignableFrom(typeof(string)))
            {
                return null;
            }

            Format format;
            double currentTime;
            double totalDuration;
            if(!Enum.TryParse(System.Convert.ToString(values[0]), out format)
                || !double.TryParse(System.Convert.ToString(values[1]), out currentTime)
                || !double.TryParse(System.Convert.ToString(values[2]), out totalDuration))
            {
                return null;
            }

            double time = 0;
            switch(format)
            {
                case Format.CurrentTime:
                    time = currentTime;
                    break;

                case Format.RemainingTime:
                    time = totalDuration - currentTime;
                    break;
            }

            StringBuilder formatBuilder = new();
            var timeSpan = TimeSpan.FromSeconds(time);
            if (timeSpan.Hours > 0)
            {
                formatBuilder.Append(@"hh\:");
            }
            formatBuilder.Append(@"mm\:ss");
            return timeSpan.ToString(formatBuilder.ToString());
        }

        public object[] ConvertBack(object value, System.Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException($"No ConvertBack required for {typeof(SecondsToStringConverter)}");
        }
    }
}

