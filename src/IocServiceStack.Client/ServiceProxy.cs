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
   
    public class ServiceProxy<T> : RealProxy where T: class
    {
        public ServiceProxy() : base(typeof(T))
        {
        }

        public override IMessage Invoke(IMessage msg)
        {
            var methodCall = msg as IMethodCallMessage;
            var methodInfo = methodCall.MethodBase as MethodInfo;

            //Gateway -> Contract/Action
            //Json Body 
            // OnBeforeExecute(methodCall);
            try
            {
                //make a call to server to fetch
                //var result = methodInfo.Invoke(_contract, methodCall.InArgs);
                //  OnAfterExecute(methodCall);
                return new ReturnMessage(null, null, 0, methodCall.LogicalCallContext, methodCall);
            }
            catch (Exception ex)
            {
                // OnErrorExecute(methodCall);
                return new ReturnMessage(ex, methodCall);
            }
        }
    }
}
