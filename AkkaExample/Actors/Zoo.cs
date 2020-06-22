﻿using Akka.Actor;
using AkkaExample.Messages;
using System;
using System.Collections.Generic;

namespace AkkaExample.Actors
{
    public class Zoo : UntypedActor
    {
        private readonly IActorRef Keeper;

        private readonly IActorRef Accountant;

        private readonly IList<IActorRef> Customers;

        public Zoo()
        {
            Keeper = Context.ActorOf(Actors.Keeper.Props("Joel Exotic"), "keeper");
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

                    var admittedMessage = Accountant.Ask<AdmittedMessage>(ticketSalesMessage).PipeTo(customer);
                    customer.Tell(admittedMessage);
                    break;
            }
        }

        public static Props Props()
        {
            return Akka.Actor.Props.Create(() => new Zoo());
        }
    }
}
