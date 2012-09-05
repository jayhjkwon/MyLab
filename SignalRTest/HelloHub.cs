using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRTest
{
    public class HelloHub : Hub
    {
        public void DoStuffServer(string msg)
        {
            Clients.doStuffClient(string.Format("{0} : {1}", DateTime.Now.ToLocalTime().ToString(), msg));
            Caller.doStuffClient("hey you are the caller");

            //return DateTime.Now.ToLocalTime().ToString();
        }

        public void GetPersonServer()
        {
            var p = new Person { Id = 1, Name = "Kwon" };
            Clients.getPersonClient(p);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}