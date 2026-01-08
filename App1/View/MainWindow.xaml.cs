using App1.View;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;
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
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(null);
            IntPtr hWnd = WinRT.Interop.WindowNative.GetWindowHandle(this);
            WindowId windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            AppWindow appWindow = AppWindow.GetFromWindowId(windowId);
            appWindow.Resize(new SizeInt32(1280, 720));
            CenterAppWindow(appWindow);
        }

        private void CenterAppWindow(AppWindow appWindow)
        {
            DisplayArea displayArea = DisplayArea.GetFromWindowId(appWindow.Id, DisplayAreaFallback.Primary);

            var workArea = displayArea.WorkArea;

            int centerX = ((workArea.Width - appWindow.Size.Width) / 2) + workArea.X;
            int centerY = ((workArea.Height - appWindow.Size.Height) / 2) + workArea.Y;

            appWindow.Move(new PointInt32(centerX, centerY));
        }

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            NavView.SelectedItem = NavView.MenuItems[0];

            ContentFrame.Navigate(typeof(Page1Calendar), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //Ayarlar sayfasina yönlendirme yapýlabilir
            }
            else
            {
                var selectedItem = (NavigationViewItem)args.SelectedItem;

                string? selectedTag = selectedItem.Tag.ToString();

                switch (selectedTag)
                {
                    case "Calendar":
                        ContentFrame.Navigate(typeof(Page1Calendar), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
                        break;

                    case "EventList":
                        ContentFrame.Navigate(typeof(Page2EventList), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
                        break;

                    case "EventAdd":
                        ContentFrame.Navigate(typeof(Page3EventAdd), null, new SlideNavigationTransitionInfo() { Effect = SlideNavigationTransitionEffect.FromRight });
                        break;
                }
            }
        }

    }
}
