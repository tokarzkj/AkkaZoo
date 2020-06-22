using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaExample.Messages
{
    public class TicketSalesMessage
    {
        public TicketSalesMessage(decimal ticketSales)
        {
            Id = Guid.NewGuid();
            TicketSales = ticketSales;
        }

        public Guid Id { get; set; }

        public decimal TicketSales { get; set; }
    }
}
