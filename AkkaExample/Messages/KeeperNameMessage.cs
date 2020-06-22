using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Messages
{
    public class KeeperNameMessage
    {
        public KeeperNameMessage()
        {
            Id = new Guid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
