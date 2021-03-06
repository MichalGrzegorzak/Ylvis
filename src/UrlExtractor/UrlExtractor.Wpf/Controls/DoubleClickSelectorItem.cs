﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace UrlExtractor.Wpf.Controls
{
    /// <summary>
    /// Class implements a <seealso cref="Selector"/> double click to command binding attached behaviour.
    /// </summary>
    public class DoubleClickSelectorItem
    {
        #region fields
        public static readonly DependencyProperty DoubleClickItemCommandProperty = DependencyProperty.RegisterAttached("DoubleClickItemCommand",
                                                typeof(ICommand), typeof(DoubleClickSelectorItem),
                                                new PropertyMetadata(null, DoubleClickSelectorItem.OnDoubleClickItemCommand));
        #endregion fields

        #region constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        public DoubleClickSelectorItem()
        {

        }
        #endregion constructor

        #region properties
        #endregion properties

        #region methods
        #region attached dependency property methods
        public static ICommand GetDoubleClickItemCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(DoubleClickItemCommandProperty);
        }

        public static void SetDoubleClickItemCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(DoubleClickItemCommandProperty, value);
        }
        #endregion attached dependency property methods

        private static void OnDoubleClickItemCommand(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uiElement = d as Selector;

            // Remove the handler if it exist to avoid memory leaks
            if (uiElement != null)
                uiElement.MouseDoubleClick -= UIElement_MouseDoubleClick;

            var command = e.NewValue as ICommand;
            if (command != null)
            {
                // the property is attached so we attach the Drop event handler
                uiElement.MouseDoubleClick += UIElement_MouseDoubleClick;
            }
        }

        private static void UIElement_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var uiElement = sender as Selector;

            // Sanity check just in case this was somehow send by something else
            if (uiElement == null)
                return;

            // Is there a selected item that was double clicked?
            if (uiElement.SelectedIndex == -1)
                return;

            ICommand doubleclickCommand = DoubleClickSelectorItem.GetDoubleClickItemCommand(uiElement);

            // There may not be a command bound to this after all
            if (doubleclickCommand == null)
                return;

            // Check whether this attached behaviour is bound to a RoutedCommand
            if (doubleclickCommand is RoutedCommand)
            {
                // Execute the routed command
                (doubleclickCommand as RoutedCommand).Execute(uiElement.SelectedItem, uiElement);
            }
            else
            {
                // Execute the Command as bound delegate
                doubleclickCommand.Execute(uiElement.SelectedItem);
            }
        }
        #endregion methods
    }
}
