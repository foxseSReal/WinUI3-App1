using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;

namespace App1.ViewModel
{
    //MVVM modellerinde ViewModel katmanında yer alan ilk class yapisinda partial eklenmeli.
    // Çünkü kodun yarısını sen, diğer yarısını Toolkit arka planda yazacak.
    //ObservableObject'ten miras almalı.
    public partial class Page1CalandarModel : ObservableObject
    {
        [ObservableProperty]
        private string _checkBoxContent = "SelectionMode: None";
        [ObservableProperty]
        private bool? _checkBoxStatus = false;
        [ObservableProperty]
        private bool _isInfoBarOpen = false;
        // Takvimin Modu
        [ObservableProperty]
        private CalendarViewSelectionMode _calendarMode = CalendarViewSelectionMode.None;

        // On[OzelliginAdi]Changed metodu, ozelligin degeri degistiginde otomatik olarak cagrilir.
        partial void OnCheckBoxStatusChanged(bool? value)
        {
            if (value == false)
            {
                CalendarMode = CalendarViewSelectionMode.None;
                CheckBoxContent = "SelectionMode: None";
                IsInfoBarOpen = false;
            }
            else if (value == true)
            {
                CalendarMode = CalendarViewSelectionMode.Single;
                CheckBoxContent = "SelectionMode: Single";
                IsInfoBarOpen = false;
            }
            else if (value == null)
            {
                CalendarMode = CalendarViewSelectionMode.Multiple;
                CheckBoxContent = "SelectionMode: Multiple";
                IsInfoBarOpen = true;
            }
        }

    }
}
