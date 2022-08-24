using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TH_Essentials.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace TH_Essentials.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaschenlampePage : ContentPage
    {
        TaschenlampeViewModel _viewModel;
        public TaschenlampePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TaschenlampeViewModel();
        }

        private async void ButtonOn_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOnAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async void ButtonOff_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Flashlight.TurnOffAsync();
            }
            catch (Exception)
            {

                throw;
            }            
        }
    }
}