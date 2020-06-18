using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.Xunit2;
using AkkaExample.Actors;
using Xunit;

namespace AkkaExample.Tests
{
    public class ActorTests : TestKit
    {
        [Fact]
        public void Test1()
        {
            IActorRef zoo = Sys.ActorOf(Zoo.Props(), "zoo");
            zoo.Tell("Who is the keeper?");
            ExpectMsg("Joel Exotic");
        }
    }
}
