using Akka;
using Akka.Actor;
using AkkaExample.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Actors
{
    public class Zoo : UntypedActor
    {
        private readonly IActorRef Keeper;

        public Zoo()
        {
            Keeper = Context.ActorOf(Actors.Keeper.Props("Joel Exotic"), "keeper");
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
            }
        }

        public static Props Props() => Akka.Actor.Props.Create(() => new Zoo());
    }
}
