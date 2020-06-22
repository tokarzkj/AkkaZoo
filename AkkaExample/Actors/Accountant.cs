using Akka.Actor;
using AkkaExample.Messages;

namespace AkkaExample.Actors
{
    public class Accountant : UntypedActor
    {

        public decimal TicketSales { get; set; }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case TicketSalesMessage sales:
                    TicketSales += sales.TicketSales;
                    Sender.Tell(new AdmittedMessage(), Self);
                    break;
            }
        }

        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new Accountant());
        }
    }
}
