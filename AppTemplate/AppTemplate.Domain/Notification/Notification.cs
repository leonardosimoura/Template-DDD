using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTemplate.Domain.Notification
{
    public class Notification
    {
        public Notification()
        {
            Data = DateTime.Now;
            Id = 0;
            IsError = false;
            Message = "";
            WhoSend = "";
        }

        public Notification(string message, string whoSend, bool isError)
        {
            Data = DateTime.Now;
            IsError = isError;
            Message = message;
            WhoSend = whoSend;
        }

        public Notification(int id,string message, string whoSend, bool isError)
        {
            Data = DateTime.Now;
            Id = id;
            IsError = isError;
            Message = message;
            WhoSend = whoSend;
        }

        public int Id { get; set; }

        public DateTime Data { get; set; }

        public string WhoSend { get; set; }

        public string Message { get; set; }

        public bool IsError { get; set; }
    }
}
