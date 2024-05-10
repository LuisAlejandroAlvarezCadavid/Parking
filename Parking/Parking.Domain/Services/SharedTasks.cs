using Parking.Domain.Entities;
using Parking.Domain.Ports;

namespace Parking.Domain.Services
{
    internal static class SharedTasks
    {
        internal static void SendBrockerMessge(IBrockerSenderRepository brockerSenderRepository, string plate, string? observation = default, double? valueToPay = 0.0)
        {
            var log = new Logs(Guid.NewGuid(), DateTime.Now, DateTime.Now, plate, DateTime.Now, observation);
            log.SetValuePay(valueToPay);
            log.SetLeaveTime(DateTime.Now);
            brockerSenderRepository.ConfigAndSendMessageToBrocker(log);
        }

        internal static double CalculateValueToPay(DateTime enterTime, DateTime leaveTime, double valueByHour, double valueOfOneDay)
        {
            var time = leaveTime - enterTime;
            double valueToPay = time.Days * valueOfOneDay + time.Hours * valueByHour;
            valueToPay = time.Minutes > 0 ? valueToPay + valueByHour : valueToPay;
            return valueToPay;
        }
    }
}
