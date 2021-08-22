using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ListBoxItemTemplateSample
{
    public class ListBoxTemplateSelector : DataTemplateSelector
    {
        public DataTemplate IsChekedTemplate { get; set; }
        public DataTemplate IsNotChekedTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) return IsNotChekedTemplate;

            var id = ((SampleData)item).ID;

            if (id % 2 == 0)
            {
                return IsChekedTemplate;
            }
            else
            {
                return IsNotChekedTemplate;
            }
        }
    }
}
