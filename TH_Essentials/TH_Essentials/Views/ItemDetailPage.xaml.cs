using System.ComponentModel;
using TH_Essentials.ViewModels;
using Xamarin.Forms;

namespace TH_Essentials.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}