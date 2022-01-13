using Autofac;
using epam_task_5.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_5.DataAccess
{
    public class DiModule : Module
    {
        private readonly string _connectionString;
        public DiModule()
        {
            _connectionString = Connection.ConnectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<ClientRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<OrderRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
