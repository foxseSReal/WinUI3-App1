using App1.View;
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
using Windows.Networking.NetworkOperators;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            // Ýlk öðeyi seçili hale getir
            NavView.SelectedItem = NavView.MenuItems[0];

            // Frame'i Anasayfaya yönlendir
            ContentFrame.Navigate(typeof(Page1Calendar));
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            // Eðer "Ayarlar" (Settings) seçildiyse (WinUI bunu otomatik yönetir)
            if (args.IsSettingsSelected)
            {
                // Ayarlar sayfasý oluþturduysanýz burayý açabilirsiniz
                // ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                // Seçilen öðeyi al
                var selectedItem = (NavigationViewItem)args.SelectedItem;

                // Tag deðerine göre sayfayý bul
                string? selectedTag = selectedItem.Tag.ToString();

                switch (selectedTag)
                {
                    case "Calendar":
                        ContentFrame.Navigate(typeof(Page1Calendar));
                        break;

                    case "EventList":
                        ContentFrame.Navigate(typeof(Page2EventList));
                        break;

                    case "EventAdd":
                        ContentFrame.Navigate(typeof(Page3EventAdd));
                        break;
                }
            }
        }

    }
}
