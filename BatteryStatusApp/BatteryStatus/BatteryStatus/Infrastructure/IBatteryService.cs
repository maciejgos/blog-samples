namespace BatteryStatus.Infrastructure
{
    public interface IBatteryService
    {
        int RemainingChargePercent { get; }

        Models.BatteryStatus Status { get; }

        Models.PowerSource PowerSource { get; }
    }
}
