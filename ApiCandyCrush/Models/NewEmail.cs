using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Postal;
namespace ApiCandyCrush.Models
{
    public class NewEmail : Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string name { get; set; }
        public string correo { get; set; }
        public string message { get; set; }
    }
}