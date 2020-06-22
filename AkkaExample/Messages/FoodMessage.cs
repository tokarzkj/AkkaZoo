using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Messages
{
    public class FoodMessage
    {
        public FoodMessage(string name)
        {
            Id = new Guid();
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
