using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Notification
{
    public class Notification
    {
        public DateTime Data { get; set; }

        public string WhoSend { get; set; }

        public string Message { get; set; }

        public bool IsError { get; set; }
    }
}
