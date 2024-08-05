using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem
{
    public class BookingHistory
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int TrainId { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime BookingDate { get; set; }
        public string TrainName { get; set; } // Additional field to show train name
    }
    public class CancellationHistory
    {
        public int CancellationId { get; set; }
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime CancellationDate { get; set; }
        public string TrainName { get; set; } // Additional field to show train name
    }
}
