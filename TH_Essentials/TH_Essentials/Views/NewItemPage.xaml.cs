using System;
using System.Collections.Generic;
using System.ComponentModel;
using TH_Essentials.Models;
using TH_Essentials.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TH_Essentials.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}