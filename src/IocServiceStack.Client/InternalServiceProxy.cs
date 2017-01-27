#region License
// Copyright (c) 2016 Rajeswara-Rao-Jinaga
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

namespace IocServiceStack.Client
{
    using System;
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;

    internal class InternalServiceProxy<T> : RealProxy where T: class
    {
        private readonly string _gatewayBaseUrl;
        private readonly string _serviceType;

        public InternalServiceProxy(string gatewayBaseUrl) : base(typeof(T))
        {
            _gatewayBaseUrl = gatewayBaseUrl;
        }

        public InternalServiceProxy(string gatewayBaseUrl, string serviceType) : base(typeof(T))
        {
            _gatewayBaseUrl = gatewayBaseUrl;
            _serviceType = serviceType;

        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;

            try
            {
                var proxy = ClientServiceManager.GetService<IServiceProxy>();
                proxy.ServiceClient = ClientServiceManager.GetService<IServiceClient>();
                proxy.Serializer = ClientServiceManager.GetService<ISerializer>();
                proxy.BaseUrl = _gatewayBaseUrl;

                var result = proxy.Invoke(methodInfo.ReflectedType, _serviceType, methodInfo,  methodCall.Args);

                return new ReturnMessage(result, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception ex)
            {
                return new ReturnMessage(ex, methodCall);
            }
        }
    }
}
