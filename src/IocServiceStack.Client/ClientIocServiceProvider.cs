namespace IocServiceStack.Client
{
    using System;
    public class ClientIocServiceProvider
    {
        public static ServicePostConfiguration Configure(Action<ServiceConfig> configuration)
        {
            var config = IocServiceProvider.CreateNewIocContainer(configuration);

            ClientIocContainer.IoC = config.GetIocContainer();

            return config;
        }
    }
}
