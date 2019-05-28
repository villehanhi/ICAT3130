using System;
using System.Collections.Generic;
using System.Text;

namespace Himaan.Models
{
    class User
    {
        public int userId { get; set; }
        public string userFirstname { get; set; }
        public string userLastname { get; set; }
        public DateTime userDateOfBirth { get; set; }
        public string userEmail { get; set; }
        public string userPhone { get; set; }
    }
}
