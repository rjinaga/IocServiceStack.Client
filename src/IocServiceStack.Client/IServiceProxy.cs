namespace IocServiceStack.Client
{
    using System;
    using System.Reflection;

    public interface IServiceProxy
    {
        string BaseUrl { get; set; }
        ISerializer Serializer { get; set; }
        IServiceClient ServiceClient { get; set; }
        object Invoke(Type contractType, MethodInfo methodInfo, object[] args);
    }
}
