using Android.App;
using Android.Content;
using Android.OS;
using BatteryStatus.Models;
using System;
using AndroidBatteryStatus = Android.OS.BatteryStatus;

[assembly:Xamarin.Forms.Dependency(typeof(BatteryStatus.Droid.Infrastructure.BatteryService))]
namespace BatteryStatus.Droid.Infrastructure
{
    public class BatteryService : BatteryStatus.Infrastructure.IBatteryService
    {
        public int RemainingChargePercent
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            var level = battery.GetIntExtra(BatteryManager.ExtraLevel, -1);
                            var scale = battery.GetIntExtra(BatteryManager.ExtraScale, -1);

                            return (int)Math.Floor(level * 100D / scale);
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }

        public Models.BatteryStatus Status
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)AndroidBatteryStatus.Charging || status == (int)AndroidBatteryStatus.Full;

                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;
                            bool wirelessCharge = false;
                            wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;

                            isCharging = (usbCharge || acCharge || wirelessCharge);
                            if (isCharging)
                                return Models.BatteryStatus.Charging;

                            switch (status)
                            {
                                case (int)AndroidBatteryStatus.Charging:
                                    return Models.BatteryStatus.Charging;
                                case (int)AndroidBatteryStatus.Discharging:
                                    return Models.BatteryStatus.Discharging;
                                case (int)AndroidBatteryStatus.Full:
                                    return Models.BatteryStatus.Full;
                                case (int)AndroidBatteryStatus.NotCharging:
                                    return Models.BatteryStatus.NotCharging;
                                default:
                                    return Models.BatteryStatus.Unknown;
                            }
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }

        public PowerSource PowerSource
        {
            get
            {
                try
                {
                    using (var filter = new IntentFilter(Intent.ActionBatteryChanged))
                    {
                        using (var battery = Application.Context.RegisterReceiver(null, filter))
                        {
                            int status = battery.GetIntExtra(BatteryManager.ExtraStatus, -1);
                            var isCharging = status == (int)AndroidBatteryStatus.Charging || status == (int)AndroidBatteryStatus.Full;

                            var chargePlug = battery.GetIntExtra(BatteryManager.ExtraPlugged, -1);
                            var usbCharge = chargePlug == (int)BatteryPlugged.Usb;
                            var acCharge = chargePlug == (int)BatteryPlugged.Ac;

                            bool wirelessCharge = false;
                            wirelessCharge = chargePlug == (int)BatteryPlugged.Wireless;

                            isCharging = (usbCharge || acCharge || wirelessCharge);

                            if (!isCharging)
                                return Models.PowerSource.Battery;
                            else if (usbCharge)
                                return Models.PowerSource.Usb;
                            else if (acCharge)
                                return Models.PowerSource.Ac;
                            else if (wirelessCharge)
                                return Models.PowerSource.Wireless;
                            else
                                return Models.PowerSource.Other;
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Ensure you have android.permission.BATTERY_STATS");
                    throw;
                }
            }
        }

        public BatteryService()
        {

        }
    }
}