namespace IocServiceStack.Client
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class ClientServiceProxy : IServiceProxy
    {
        public string BaseUrl
        {
            get; set;
        }
        public ISerializer Serializer { get; set; }
        public IServiceClient ServiceClient
        {
            get; set;
        }

        public object Invoke(Type contractType, string serviceType, MethodInfo methodInfo, object[] args)
        {
            string contractModule = contractType.Assembly.GetName().Name;
            string contractNamespace = contractType.Namespace;
            string contractName = contractType.Name;
            string actionName = methodInfo.Name;


            //prepare meta data of method parameters
            var parameters = methodInfo.GetParameters();
            Dictionary<string, string> metadata = new Dictionary<string, string>();
            foreach (var paramter in parameters)
            {
                metadata.Add(paramter.Name, paramter.ParameterType.FullName);
            }

            //serialize method info and data
            var data = Serializer.Serialize(new { Metadata = metadata, Data = args });

            //send
            var result = ServiceClient.Send(
                new ServiceRequest()
                {
                    BaseUrl = BaseUrl,
                    ServiceName = contractName,
                    Action = actionName,
                    ServiceType = serviceType,
                    Namespace = contractNamespace,
                    Module = contractModule,
                    Content = data
                });

            //handle result
            object returnValue = null;
            if (methodInfo.ReturnType != typeof(void))
                returnValue = Serializer.Deserialize(result, methodInfo.ReturnType);

            return returnValue;

        }
    }
}
