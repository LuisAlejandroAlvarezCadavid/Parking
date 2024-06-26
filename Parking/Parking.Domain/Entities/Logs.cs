﻿using Parking.Domain.Resources;

namespace Parking.Domain.Entities
{
    public class Logs : DomainEntity
    {
        string plate;
        DateTime enterTime;
        public string? Observation { get; set; }
        public double? ValuePay { get; set; }
        public DateTime? LeaveTime { get; set; }
        public string Plate
        {
            get => plate;
            set
            {
                plate = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(Plate), string.Format(DomainMessages.NullValueProperty, nameof(Plate))) : value;
            }
        }

        public DateTime EnterTime
        {
            get => enterTime;
            set
            {
                enterTime = value.Ticks == 0 ? throw new ArgumentNullException(nameof(EnterTime), DomainMessages.DateValue) : value;
            }
        }

        public Logs(Guid id, DateTime fechaCreacion, DateTime fechaModificacion, string plate, DateTime enterTime, string? observation = default) : base(id, fechaCreacion, fechaModificacion)
        {
            Plate = plate;
            EnterTime = enterTime;
            Observation = observation;
        }

        public void SetValuePay(double? value) => ValuePay = value;
        public void SetLeaveTime(DateTime leaveTime) => LeaveTime = leaveTime;
    }
}
