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
using Windows.UI.Popups;
using System.Threading.Tasks;
using App1.Helpers;
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
            _CalendarSelectionModes.Content = "SelectionMode: None";
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
            _InfoBar.IsOpen = true;

        }

        private async void _Calendar_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            //Kullanýcý tarih seçtiðinde yapýlacak iþlemler buraya eklenebilir
            //Tarihleri kisitlamamizda gerekiyor ayrica

            int maxSelections = 7; // Maksimum seçim sayýsý

            if (sender.SelectedDates.Count > maxSelections)
            {
                foreach (var addedDate in args.AddedDates)
                {
                    sender.SelectedDates.Remove(addedDate);
                }
            }

            else
            {
                // Seçilen tarihleri iþleme
                foreach (var date in args.AddedDates)
                {
                    // Seçilen tarih üzerinde iþlemler yapýlabilir
                }

            }
        }

        private async void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog dialog = new ContentDialog();

            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Save your work?";
            dialog.PrimaryButtonText = "Tamam";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;

            var result = await dialog.ShowAsync();
        }

        private async void InfoBarButton_Click(object sender, RoutedEventArgs e)
        {
            //await ContentDialogs.DefaultDialog(this.XamlRoot, "Bilgi", "Birden fazla tarih seçimi etkinleþtirildi. Maksimum 7 tarih seçebilirsiniz.");
            await ContentDialogs.PanelDialog(this.XamlRoot);

        }



    }
}
