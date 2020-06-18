using Akka.Actor;
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
        }

        public string Name { get; set; }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "Who is the keeper?":
                    Sender.Tell(Name, Self);
                    break;
            }
        }

        public static Props Props(string name)
        {
            return Akka.Actor.Props.Create(() => new Keeper(name));
        }
    }
}
