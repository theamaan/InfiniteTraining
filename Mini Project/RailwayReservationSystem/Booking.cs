using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservationSystem
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int TrainId { get; set; }
        public int NumberOfTickets { get; set; }
        public DateTime BookingDate { get; set; }
    }

}
