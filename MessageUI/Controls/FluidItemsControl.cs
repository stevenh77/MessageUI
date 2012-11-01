using System.Windows;
using System.Windows.Controls;

namespace MessageUI.Controls
{
    // Using this control to allow use to contain ListBoxItem to enjoy their rich loading events
    //  without the overhead of a listbox control (selection, focus, validation etc not required).

    public class FluidItemsControl : ItemsControl
    {
        public static readonly DependencyProperty ItemContainerStyleProperty = 
            DependencyProperty.Register("ItemContainerStyle", 
                                        typeof(Style), 
                                        typeof(FluidItemsControl), 
                                        new PropertyMetadata(null));

        public Style ItemContainerStyle
        {
            set { SetValue(ItemContainerStyleProperty, value); }
            get { return (Style)GetValue(ItemContainerStyleProperty); }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            var container = new ListBoxItem();
            if (ItemContainerStyle != null)
            {
                container.Style = ItemContainerStyle;
            }
            return container;
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is ListBoxItem;
        }
    }
}