using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Himaan.Models
{
    class Need
    {
        public string needFrom { get; set; }
        public string needTo { get; set; }
        public DateTime needDate { get; set; }
        public string needDescription { get; set; }
        public int needFreeSeats { get; set; }
    }
}
