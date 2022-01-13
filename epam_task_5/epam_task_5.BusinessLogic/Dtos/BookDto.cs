
namespace epam_task_5.BusinessLogic.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public Enums.StatusEnum Returned { get; set; }
        public Enums.ConditionEnum Condition { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Author + " " + Genre + " " + Returned + " " + Condition + ";";
        }
    }
}
