namespace IocServiceStack.Client.Tests
{
    using System;
    using NUnit.Framework;
    using IocServiceStack.Client;

    [SetUpFixture]
    public class Configure
    {
        [OneTimeSetUp]
        public void Config()
        {
            //Configure remote services
            IocServiceProvider.Configure(config =>
            {
                config.UseRemoteServices(gatewayBaseUrl : "http://localhost:63488/serviceapi");
            });
        }
    }
}
