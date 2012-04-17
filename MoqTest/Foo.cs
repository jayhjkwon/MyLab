using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoqTest
{
    public interface IService
    {
        bool DoSomething(string param);
    }

    public class Service : IService
    {

        public bool DoSomething(string param)
        {
            if (param.Length % 2 == 0)
                return true;
            else
                return false;
        }
    }

    public class Controller
    {
        public virtual int Id { get; set; }
        private IService service;

        public Controller()
        {
        }

        public Controller(IService service)
        {
            this.service = service;
        }

        public bool GetReult(string param)
        {
            return service.DoSomething(param);
        }

    }
}
