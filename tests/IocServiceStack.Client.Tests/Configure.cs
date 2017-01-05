namespace IocServiceStack.Client.Tests
{
    using System;
    using NUnit.Framework;
    using IocServiceStack.Client;

    public class Configure
    {
        [Test]
        public void Config()
        {
            //Configure remote services
            IocServiceProvider.Configure(config =>
            {
                config.UseRemoteServices(new Uri(""));
            });
        }
    }
  

}
