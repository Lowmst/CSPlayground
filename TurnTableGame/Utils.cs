using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnTableGame
{
    public static class Utils
    {
        public static async void MsgBox(String content, XamlRoot xamlRoot)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.XamlRoot = xamlRoot;
            dialog.Content = content;
            dialog.CloseButtonText = "OK";
            var result = await dialog.ShowAsync();
        }
    }
}
