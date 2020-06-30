using Akka.Actor;
using AkkaExample.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Actors
{
    public class Maintenance : ReceiveActor
    {
        private readonly Guid Id;

        public Maintenance()
        {
            Id = Guid.NewGuid();

            Receive<MaintenanceMessage>(mm =>
            {
                Console.WriteLine($"{Id} is working on {mm.ThingToMaintain}");
            });
        }
    }
}
