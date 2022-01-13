using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            // here we should add our repositories
            // to use them with Dependency Injection Autofac Container

            builder.RegisterType<SpecializationRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<JobPositionRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<TaskRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<OrderTaskRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<OrderRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<ManagerRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<EmployeeRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<CustomerRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<BrigadeRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<FeedbackRepository>()
                .WithParameter("connectionString", _connectionString)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
