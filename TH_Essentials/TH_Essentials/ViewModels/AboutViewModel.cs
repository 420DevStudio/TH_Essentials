using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TH_Essentials.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Über TH Essentials";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/420DevStudio/TH_Essentials"));
        }

        public ICommand OpenWebCommand { get; }
    }
}