using System;
using System.Collections.Generic;
using System.Text;

namespace Himaan.Models
{
    class Offer
    {
        public string offerFrom { get; set; }
        public string offerTo { get; set; }
        public DateTime offerDate { get; set; }
        public string offerDescription { get; set; }
        public int offerFreeSeats { get; set; }
    }
}
