namespace IocServiceStack.Client
{
    using System;
    public class ClientIocServiceProvider
    {
        public static ServicePostConfiguration Configure(Action<ServiceConfig> configuration)
        {
            var config = IocServicelet.CreateIocContainer(configuration);

            ClientIocContainer.IoC = config.GetIocContainer();

            return config;
        }
    }
}
