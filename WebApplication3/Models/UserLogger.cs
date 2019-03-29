using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class UserLogger
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateExecuted { get; set; }
        public string CookieInfo { get; set; }
        public string UserId { get; set; }


    }
}
