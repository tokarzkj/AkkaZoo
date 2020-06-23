using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Messages
{
    public class AdmittedMessage
    {
        public Guid Id { get; set; }

        private int Count { get; set; }

        public AdmittedMessage()
        {
            Id = Guid.NewGuid();
        }
    }
}
