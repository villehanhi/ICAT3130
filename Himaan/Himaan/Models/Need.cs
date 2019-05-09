using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Himaan.Models
{
    class Need
    {
        public string offerFrom { get; set; }
        public string offerTo { get; set; }
        public DateTime offerDate { get; set; }
        public string offerDescription { get; set; }
        public int offerFreeSeats { get; set; }
    }
}
