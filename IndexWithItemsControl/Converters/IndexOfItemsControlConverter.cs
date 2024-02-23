using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace IndexWithItemsControl.Converters
{
    public class IndexOfItemsControlConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ItemsControl? itemsControl = null;
            ContentPresenter? content = null;
            foreach (var val in values)
            {
                if (val is ItemsControl i)
                {
                    itemsControl = i;
                    continue;
                }
                if (val is ContentPresenter c)
                {
                    content = c;
                    continue;
                }
            }
            if (itemsControl != null && content != null)
            {
                var index = itemsControl.ItemContainerGenerator.IndexFromContainer(content);
                return $"{index + 1}";
            }
            return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is object[] list)
            {
                return list;
            }
            return new object[] { value };
        }
    }
}
