using Akka.Actor;
using System;

namespace AkkaExample
{
    class Program
    {
        private static ActorSystem ActorSystem;

        static void Main(string[] args)
        {
            ActorSystem = ActorSystem.Create("MainActor");
        }
    }
}
