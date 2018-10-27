using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiServices.Models
{
    public class MsgErr
    {
        public int messageError { get; set; }
        public int employeeId { get; set; }
        public DateTime MsgDate { get; set; }
        public string  message { get; set; }
        public string  velocite { get; set; }

    }
}