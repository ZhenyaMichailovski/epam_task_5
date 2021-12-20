using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.DataAccess.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Sex { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }
}
