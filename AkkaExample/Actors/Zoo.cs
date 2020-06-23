using Akka.Actor;
using AkkaExample.Messages;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace AkkaExample.Actors
{
    public class Zoo : UntypedActor
    {
        private readonly IActorRef Keeper;

        private readonly IActorRef Accountant;

        private readonly IList<IActorRef> Customers;

        public Zoo()
        {
            Keeper = Context.ActorOf(Actors.Keeper.Props("Joel Wild"), "keeper");
            Accountant = Context.ActorOf(Actors.Accountant.Props(), "Accountant");
            Customers = new List<IActorRef>();
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case KeeperNameMessage m:
                    if (m.Name is null)
                    {
                        Keeper.Tell(m, Self);
                    }
                    else
                    {
                        Console.WriteLine($"Keepers name is {m.Name}");
                    }
                    break;
                case TicketPurchaseMessage tpm:
                    var ticketSalesMessage = new TicketSalesMessage(tpm.Price * tpm.Quantity);
                    var customer = Context.ActorOf(Actors.Customer.Props("hank"), "customer" + Customers.Count);
                    Customers.Add(customer);

                    Accountant.Ask<AdmittedMessage>(ticketSalesMessage)
                        .PipeTo(customer, Self);
                    break;
                case AdmittedMessage _:
                    Console.WriteLine("Customer admitted");
                    break;
                case FoodMessage fm:
                    Keeper.Tell(fm);
                    break;
            }
        }

        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new Zoo());
        }
    }
}
