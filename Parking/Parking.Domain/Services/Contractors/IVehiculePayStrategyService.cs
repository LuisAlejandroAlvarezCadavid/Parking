namespace Parking.Domain.Services.Contractors
{
    public interface IVehiculePayStrategyService
    {
        public string VehiculeType { get; set; }

        Task<bool> InsertEnterVehiculeAsync(string vehiculeTypoe);
    }
}
