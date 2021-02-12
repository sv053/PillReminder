using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PillReminder.ViewModels
{
   public class ColorConverter : IValueConverter
    {
       
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if ((System.Convert.ToBoolean(value))==true)
                {
                    return "Blue";
                }
                else
                {
                    return "Gray";
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                //string color = System.Convert.ToString(value);
                //if (color == Color.Blue.ToString())
                //    return 0;
                //else
                    return 0;
            }
        }
    
}
