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
            var keeper = Sys.ActorOf(Keeper.Props("Joel Exotic"), "zoo");

            var probe = CreateTestProbe();
            keeper.Tell(probe.Ref, TestActor);

            var keeperNameMessage = new KeeperNameMessage();
            keeper.Tell(keeperNameMessage);
            ExpectMsg<KeeperNameMessage>(m => m.Name == "Joel Exotic");
        }
    }
}
