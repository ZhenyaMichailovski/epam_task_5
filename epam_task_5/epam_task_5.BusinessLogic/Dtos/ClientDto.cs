using System;

namespace epam_task_5.BusinessLogic.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Sex { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

        public override string ToString()
        {
            return Id + " " + FIO + " " + Sex + " " + DateOfBirth + ";";
        }
    }
}
