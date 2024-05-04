namespace Parking.Application.Dtos
{
    public class VehiculeDto
    {
        public string Plate { get; set; } = default!;
        public DateTime EnterTime { get; set; }
        public DateTime LeaveTime { get; set; }
    }
}
