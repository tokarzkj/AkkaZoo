using Akka.Actor;
using AkkaExample.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Actors
{
    public class Animal : UntypedActor
    {
        public string AnimalType { get; set; }

        public bool IsHungry { get; set; }

        public Animal(string animalType)
        {
            AnimalType = animalType;
            IsHungry = true;
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case FoodMessage _:
                    string res = "I am not hungry";
                    if (IsHungry)
                    {
                        IsHungry = false;
                        res = "Thank you I was hungry";
                    }
                    Sender.Tell(res, Self);
                    break;
            }
        }

        public static Props Props(string animalType)
        {
            return Akka.Actor.Props.Create(() => new Animal(animalType));
        }
    }
}
