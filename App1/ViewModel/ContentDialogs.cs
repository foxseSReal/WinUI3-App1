using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModel
{
    internal static class ContentDialogs
    {

        /// <summary>
        ///     Bu metodlar daha hizli bir sekilde ContentDialog olusturmak icin kullanilacak.
        ///     
        /// </summary>
        /// <param name="root">Pencerenin XamlRoot değeri (this.Content.XamlRoot).</param>
        /// <param name="_title">Kutucuğun başlığı.</param>
        /// <param name="_content">Kullanıcıya sorulacak soru ve ya bilgilendirme metni.</param>
        /// <returns></returns>
        /// 

        #region ContentDialog Hakkında

        // ContentDialog kullanımı hakkında bilgi:
        // ContentDialog, kullanıcıya bilgi vermek veya onay almak için kullanılan bir dialog kutusudur.
        // İçeriği, başlığı ve butonları özelleştirilebilir.
        // ContentDialog oluşturmak için aşağıdaki adımlar izlenir:
        // 1. ContentDialog nesnesi oluşturulur.
        // 2. XamlRoot, Title, Content, PrimaryButtonText, SecondaryButtonText ve CloseButtonText gibi özellikler ayarlanır.
        // 3. ShowAsync() metodu çağrılarak dialog gösterilir ve kullanıcı etkileşimi beklenir.
        #endregion


        //Standart bir bilgilendirme dialogu.
        internal static async Task DefaultDialog(XamlRoot root,string _title, string _content)
        {
            ContentDialog dialog = new ContentDialog();

            dialog.XamlRoot = root;
            dialog.Title = _title;
            dialog.Content = _content;
            dialog.PrimaryButtonText = "Tamam";
            dialog.DefaultButton = ContentDialogButton.None;

            var result = await dialog.ShowAsync();
        }

    }
}
