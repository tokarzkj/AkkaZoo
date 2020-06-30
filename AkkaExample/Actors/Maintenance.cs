using Akka.Actor;
using AkkaExample.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Actors
{
    public class Maintenance : UntypedActor
    {
        private readonly Guid Id;

        public Maintenance()
        {
            Id = Guid.NewGuid();
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case MaintenanceMessage m:
                    Console.WriteLine($"{Id} is working on {m.ThingToMaintain}");
                    break;
            }
        }
    }
}
