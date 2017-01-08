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
    using System.Net.Http;

    public class ServiceClient : IServiceClient
    {
        HttpClient _httpClient;
        public ServiceClient()
        {
            _httpClient = new HttpClient();
            
        }
      
        public byte[] Send(ServiceRequest request)
        {
            Verify(request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post,
                new Uri($"{request.BaseUrl}/{request.ServiceName}/{request.Action}"))
            {
                Content = new ByteArrayContent(request.Content)
            };

            //add namespace and module to the headers
            if (!string.IsNullOrWhiteSpace(request.Namespace))
            {
                httpRequest.Headers.Add("ns", request.Namespace);
            }
            httpRequest.Headers.Add("module", request.Module);

            var response = _httpClient.SendAsync(httpRequest);
            var result = response.Result.Content.ReadAsByteArrayAsync().Result;
            return result;
        }

        private void Verify(ServiceRequest request)
        {
            var requiredFields = !string.IsNullOrWhiteSpace(request.BaseUrl) &&
                !string.IsNullOrWhiteSpace(request.Module) &&
                !string.IsNullOrWhiteSpace(request.ServiceName) &&
                !string.IsNullOrWhiteSpace(request.Action) &&
                request.Content != null;

            if (!requiredFields)
            {
                throw new Exception("Invalid ServiceRequest object, all fields in request object are mandatory except namespace");
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _httpClient.Dispose();
                    _httpClient = null;
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
