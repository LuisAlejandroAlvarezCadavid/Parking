using Parking.Domain.Entities;
using Parking.Domain.Enums;
using Parking.Domain.Ports;

namespace Parking.Domain.Services
{
    internal static class SharedTasks
    {
        internal static void SendBrockerMessge(IBrockerSenderRepository brockerSenderRepository, string plate)
        {
            var log = new Logs(Guid.NewGuid(), DateTime.Now, DateTime.Now, plate, DateTime.Now);
            log.SetLeaveTime(DateTime.Now);
            brockerSenderRepository.ConfigAndSendMessageToBrocker(log);
        }

        internal static double CalculateValueToPay(DateTime enterTime, DateTime leaveTime, double valueByHour, double valueOfOneDay)
        {
            var time = leaveTime - enterTime;
            var totalHours = time.Hours;
            double valueToPay = 0.0;
            if (time.Hours > (int)Numbers.TWENTY_FOUR)
            {
                var hours = (int)Math.Round((double)(time.Hours / (int)Numbers.TWENTY_FOUR), 0);
                valueToPay += hours + valueOfOneDay;
                totalHours -= hours;
            }

            valueToPay += totalHours * valueByHour;
            valueToPay = time.Minutes > 0 ? valueToPay + valueByHour : valueToPay;
            return valueToPay;
        }
    }
}
