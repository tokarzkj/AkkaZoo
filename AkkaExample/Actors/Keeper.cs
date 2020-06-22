using Akka.Actor;
using AkkaExample.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Actors
{
    public class Keeper : UntypedActor
    {
        public Keeper(string name)
        {
            Name = name;
            Animal = Context.ActorOf(Actors.Animal.Props("Tiger"), "tiger");
        }

        private readonly IActorRef Animal;

        public string Name { get; set; }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case KeeperNameMessage m:
                    m.Name = Name;
                    Sender.Tell(m, Self);
                    break;
                case FoodMessage food:
                    Sender.Tell(food, Self);
                    break;
            }
        }

        public static Props Props(string name)
        {
            return Akka.Actor.Props.Create(() => new Keeper(name));
        }
    }
}
