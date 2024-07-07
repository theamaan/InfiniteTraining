using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelConcessionLib
{
    public class TravelConcession
    {
        // Constant total fare
        private const double TotalFare = 500.0;
        public string CalculateConcession(int age)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double discountedFare = TotalFare * 0.7; // 30% concession
                return $"Senior Citizen - Discounted Fare: {discountedFare:C}";
            }
            else
            {
                return $"Ticket Booked - Fare: {TotalFare:C}";
            }
        }
    }
}
