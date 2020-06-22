using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Messages
{
    public class TicketPurchaseMessage
    {
        public TicketPurchaseMessage(int quantity, decimal price)
        {
            Quantity = quantity;
            Price = price;
        }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
