using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.DataAccess
{
    public static class Connection
    {
        /// <summary>
        /// Connection string to data base
        /// </summary>
        public static string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TaskDatabase;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=TaskDatabase;Trusted_Connection=True;";
    }
}
