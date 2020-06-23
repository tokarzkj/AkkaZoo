using Akka.Actor;
using Akka.Event;
using AkkaExample.Messages;
using System;
using System.Diagnostics;

namespace AkkaExample.Actors
{
    public class Customer : UntypedActor
    {
        private Guid Id;

        public string Name { get; set; }

        public bool HasTicket { get; set; }

        public Customer(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case AdmittedMessage m:
                    HasTicket = true;
                    Sender.Tell(m, Self);
                    break;
            }
        }

        public static Props Props(string name)
        {
            return Akka.Actor.Props.Create(() => new Customer(name));
        }
    }
}
