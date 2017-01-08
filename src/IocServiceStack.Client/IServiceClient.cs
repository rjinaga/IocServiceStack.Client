namespace IocServiceStack.Client
{
    using System;
    public interface IServiceClient : IDisposable
    {
        byte[] Send(ServiceRequest request);
    }
}