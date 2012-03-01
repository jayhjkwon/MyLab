using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace Ninject_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Ninject.IKernel kernel = new StandardKernel();

            //kernel.Bind<IService>().To<YourService>();
            kernel.Bind<IService>().To<MyService>();

            var service = kernel.Get<IService>();

            // #1 normal way
            //Client client = new Client(service);
            // #2 using self binding feature in Ninject
            Client client = kernel.Get<Client>();

            client.Run();

            Console.Read();
        }
    }



    public class Client
    {
        public IService Service { get; set; }

        public Client(IService service)
        {
            this.Service = service;
        }

        public void Run()
        {
            Service.SayHello();
        }
    }

    public interface IService
    {
        void SayHello();
    }

    public class MyService : IService
    {
        public void SayHello()
        {
            Console.WriteLine("hello from my service");
        }
    }

    public class YourService : IService
    {
        public void SayHello()
        {
            Console.WriteLine("hello from your service");
        }
    }

}
