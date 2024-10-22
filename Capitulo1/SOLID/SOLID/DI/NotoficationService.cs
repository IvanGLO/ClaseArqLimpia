using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DI
{
    public interface INotification
    {
        void Send();
    }
    public class EMail:INotification
    {
        public string Sender {  get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }

        public void Send()
        {
            Console.WriteLine($"Enviando notificacion {Message}");
        }
    }
    public class NotoficationService
    {
        public void SendNotification(INotification notification)
        {
            notification.Send();
        }
    }
}
