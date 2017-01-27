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

    public class ClientServiceProvider : IocServiceStack.IServiceProvider
    {
        private IDecoratorManager _decoratorManager;
        private string _gatewayBaseUrl;

        public IDecoratorManager DecoratorManager
        {
            set
            {
                _decoratorManager = value;
            }
        }

        public IocContainer IocContainer
        {
            set
            {
                throw new NotImplementedException();
            }
        }

        public ClientServiceProvider(string gatewayBaseUrl)
        {
            _gatewayBaseUrl = gatewayBaseUrl;
        }
        
        public object GetService(System.Type contractType)
        {
            throw new System.NotImplementedException();
        }

        public T GetService<T>() where T : class
        {
            var proxy = new InternalServiceProxy<T>(_gatewayBaseUrl);
            return (T)proxy.GetTransparentProxy();
        }

        public T GetService<T>(string serviceName) where T : class
        {
            var proxy = new InternalServiceProxy<T>(_gatewayBaseUrl, serviceName);
            return (T)proxy.GetTransparentProxy();
        }

        public object GetService(Type contractType, string serviceName)
        {
            throw new NotImplementedException();
        }

        public IServiceFactory GetServiceFactory()
        {
            throw new System.NotImplementedException();
        }

        public IContainerService GetDependencyFactory(string name)
        {
            throw new NotImplementedException();
        }
    }
}
