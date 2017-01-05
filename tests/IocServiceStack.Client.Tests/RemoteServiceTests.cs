namespace IocServiceStack.Client.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static ServiceManager;

    public class RemoteServiceTests
    {
        [Test]
        public void TestService()
        {
            var customer = GetService<ICustomer>();
            //customer.GetCustomer(new Customer());

        }
    }
}
