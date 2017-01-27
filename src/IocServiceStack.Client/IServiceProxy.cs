namespace IocServiceStack.Client
{
    using System;
    using System.Reflection;

    public interface IServiceProxy
    {
        string BaseUrl { get; set; }
        ISerializer Serializer { get; set; }
        IServiceClient ServiceClient { get; set; }
        object Invoke(Type contractType, string serviceType, MethodInfo methodInfo,  object[] args);
    }
}
