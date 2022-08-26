using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TH_Essentials.ViewModels
{
    public class EinkaufslistenViewModel : BaseViewModel
    {
        //public ObservableRangeCollection<Einkaufslisten> Einkaufslisten { get; set; }

        public EinkaufslistenViewModel()
        {
            Title = "Einkaufslisten";

            //Einkaufslisten = new ObservableRangeCollection<Einkaufslisten>;
        }
    }
}