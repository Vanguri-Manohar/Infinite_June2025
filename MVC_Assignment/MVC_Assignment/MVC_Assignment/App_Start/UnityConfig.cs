using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

using MVC_Assignment.Repository;
using MVC_Assignment.Models;

namespace MVC_Assignment
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ContactContext>();
            container.RegisterType<IContactRepository, ContactRepository>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}