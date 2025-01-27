using Akka.Actor;
using Akka.TestKit.Xunit2;
using AkkaExample.Actors;
using AkkaExample.Messages;
using Xunit;

namespace AkkaExample.Tests
{
    public class ActorTests : TestKit
    {
        [Fact]
        public void KeeperTellsUsName()
        {
            var keeper = Sys.ActorOf(Keeper.Props("Joel Wild"), "Joel");

            var probe = CreateTestProbe();
            keeper.Tell(probe.Ref, TestActor);

            var keeperNameMessage = new KeeperNameMessage();
            keeper.Tell(keeperNameMessage);
            ExpectMsg<KeeperNameMessage>(m => m.Name == "Joel Wild");
        }

        [Fact]
        public void FeedTheAnimals()
        {
            var animal = Sys.ActorOf(Animal.Props("Joel Wild"), "Tiger");

            var probe = CreateTestProbe();
            animal.Tell(probe.Ref, TestActor);

            var foodMessage = new FoodMessage("Meat");
            animal.Tell(foodMessage);
            ExpectMsg("Thank you I was hungry");
        }

        [Fact]
        public void CustomerPurchasesTicketToZoo()
        {
            var zoo = Sys.ActorOf(Zoo.Props(), "zoo");

            var probe = CreateTestProbe();
            zoo.Tell(probe.Ref, TestActor);

            var newTicketPurchased = new TicketPurchaseMessage(2, 8.99M);
            zoo.Tell(newTicketPurchased);
            ExpectNoMsg();
        }
    }
}
