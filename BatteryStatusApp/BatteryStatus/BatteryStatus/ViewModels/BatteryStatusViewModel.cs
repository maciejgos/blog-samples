using BatteryStatus.Infrastructure;
using MvvmHelpers;
using Xamarin.Forms;

namespace BatteryStatus.ViewModels
{
    public class BatteryStatusViewModel : BaseViewModel
    {
        public string BatteryStatus { get; }

        public string PowerSource { get; }

        public int RemainingCharge { get; }

        public BatteryStatusViewModel()
        {
            var batteryService = DependencyService.Get<IBatteryService>();

            if (batteryService == null)
                return;

            this.BatteryStatus = batteryService.Status.ToString();
            this.PowerSource = batteryService.PowerSource.ToString();
            this.RemainingCharge = batteryService.RemainingChargePercent;
        }
    }
}