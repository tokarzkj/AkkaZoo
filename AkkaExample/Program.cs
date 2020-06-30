using Akka.Actor;
using AkkaExample.Actors;
using AkkaExample.Messages;
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

            Console.WriteLine("Enter a command. Enter q to quit");

            bool doContinue = true;
            while (doContinue)
            {
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "buy ticket":
                        var random = new Random();
                        int quantity = random.Next(1, 10);
                        var newTicketPurchased = new TicketPurchaseMessage(quantity, 8.99M);
                        zoo.Tell(newTicketPurchased);
                        break;
                    case "meet keeper":
                        var keeperNameMessage = new KeeperNameMessage();
                        zoo.Tell(keeperNameMessage);
                        break;
                    case "feed animals":
                        var foodMessage = new FoodMessage("Meat");
                        zoo.Tell(foodMessage);
                        break;
                    case "q":
                        doContinue = false;
                        break;
                    case "fix":
                        Console.WriteLine("Enter thing to maintain");
                        var thingToMaintain = Console.ReadLine();
                        var maintenanceMessage = new MaintenanceMessage()
                        {
                            ThingToMaintain = thingToMaintain
                        };
                        zoo.Tell(maintenanceMessage);
                        break;
                }
            }

            ActorSystem.Dispose();
        }
    }
}
