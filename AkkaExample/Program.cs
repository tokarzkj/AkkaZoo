using Akka.Actor;
using AkkaExample.Actors;
using System;

namespace AkkaExample
{
    class Program
    {
        private static ActorSystem ActorSystem;

        static void Main(string[] args)
        {
            ActorSystem = ActorSystem.Create("MainActor");
            IActorRef zoo = ActorSystem.ActorOf(Zoo.Props(), "zoo");
            //zoo.

            ActorSystem.Dispose();
        }
    }
}
