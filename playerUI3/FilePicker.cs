using Microsoft.UI.Xaml;
using System;
using Windows.Storage.Pickers;

namespace playerUI3
{
    public class FilePicker
    {
        private nint hWnd;

        public FilePicker(Window window)
        {
            this.hWnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
        }


        public string GetFile(string[] filters)
        {
            var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
            WinRT.Interop.InitializeWithWindow.Initialize(openPicker, hWnd);

            foreach (var filter in filters)
            {
                openPicker.FileTypeFilter.Add(filter);
            }

            var file = openPicker.PickSingleFileAsync().AsTask().Result;
            if (file != null)
            {
                return file.Path;
            }
            return null;
        }

        public string[] GetFiles()
        {
            return null;
        }

        public string GetFolder()
        {
            return null;
        }

    }
}
