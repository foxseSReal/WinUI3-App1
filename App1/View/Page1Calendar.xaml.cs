using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page1Calendar : Page
    {
        public Page1Calendar()
        {
            InitializeComponent();
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _Calendar.SelectionMode = CalendarViewSelectionMode.None;
            _CalendarSelectionModes.Content= "SelectionMode: None";
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _Calendar.SelectionMode = CalendarViewSelectionMode.Single;
            _CalendarSelectionModes.Content = "SelectionMode: Single";
        }

        private void CheckBox_Indeterminate(object sender, RoutedEventArgs e)
        {
            _Calendar.SelectionMode = CalendarViewSelectionMode.Multiple;
            _CalendarSelectionModes.Content = "SelectionMode: Multiple";
        }
    }
}
