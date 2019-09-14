using System;
using System.Globalization;
using Xamarin.Forms;

namespace FirKarnaHai
{
    class ChangeCompleteActionTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isCompleted = (bool)value;
            return isCompleted ? "Uncompleted" : "Completed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
