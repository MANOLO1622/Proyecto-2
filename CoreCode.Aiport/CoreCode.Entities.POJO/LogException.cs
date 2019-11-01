using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.Entities.POJO
{
    public class LogException : BaseEntity
    {
        public int Exception_Id { get; set; }
        public int Session_Id { get; set; }
        public string Message { get; set; }
        public DateTime Datetime { get; set; }
        public string User { get; set; }
        public string Stack { get; set; }
        public string Backtrace { get; set; }
        
    }
}
