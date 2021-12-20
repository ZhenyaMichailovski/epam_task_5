using epam_task_5.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.DataAccess.Entities
{
	public class Order
	{
		public int Id { get; set; }
		public int IdClient { get; set; }
		public int IdBook { get; set; }
		public DateTimeOffset OrderDate { get; set; }
		public StatusEnum Status { get; set; }
		public ConditionEnum Condition { get; set; }
		

	}
}
