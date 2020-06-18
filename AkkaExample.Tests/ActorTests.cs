using Akka.Actor;
using AkkaExample.Actors;
using Xunit;

namespace AkkaExample.Tests
{
    public class ActorTests
    {
        [Fact]
        public void Test1()
        {
            var system = ActorSystem.Create("System");
            IActorRef zoo = system.ActorOf(Zoo.Props(), "zoo");
            zoo.Tell("Who is the keeper?");
            ExpectMsg
        }
    }
}
