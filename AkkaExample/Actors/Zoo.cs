using Akka;
using Akka.Actor;
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
                case "Who is the keeper?":
                    Keeper.Tell("Who is the keeper?", Self);
                    break;
            }
        }

        public static Props Props() => Akka.Actor.Props.Create(() => new Zoo());
    }
}
