using epam_task_5.BusinessLogic.Enums;
using System;

namespace epam_task_5.BusinessLogic.Dtos
{
    public class OrderDto
    {
		public int Id { get; set; }
		public int IdClient { get; set; }
		public int IdBook { get; set; }
		public DateTimeOffset OrderDate { get; set; }
		public ConditionEnum ReturnCondition { get; set; }

        public override string ToString()
        {
            return Id + " " + IdClient + " " + IdBook + " " + OrderDate + " " + ReturnCondition + ";";
        }

    }
}
