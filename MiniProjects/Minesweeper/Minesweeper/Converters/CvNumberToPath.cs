using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Minesweeper.Converters
{
    class CvNumberToPath: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (System.Convert.ToInt32(value) >= 1 && System.Convert.ToInt32(value) <= 8)
                return new Uri("/Minesweeper;component/Images/no" + (string)value + ".png", UriKind.Relative);
            else if (System.Convert.ToInt32(value) == -1)
                return new Uri("/Minesweeper;component/Images/mine.png", UriKind.Relative);
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
