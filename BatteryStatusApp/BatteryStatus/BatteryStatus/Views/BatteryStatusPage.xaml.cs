using BatteryStatus.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BatteryStatus.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BatteryStatusPage : ContentPage
	{
		public BatteryStatusPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new BatteryStatusViewModel();
        }
    }
}