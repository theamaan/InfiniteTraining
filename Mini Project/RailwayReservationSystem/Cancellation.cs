using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem
{
    class Cancellation
    {
        public int CancellationId { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime CancellationDate { get; set; }
    }
}
