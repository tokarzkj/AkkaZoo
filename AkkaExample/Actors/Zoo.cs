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
            throw new NotImplementedException();
        }

        public static Props Props() => Akka.Actor.Props.Create(() => new Zoo());
    }
}
