﻿using System.Diagnostics.CodeAnalysis;

namespace Bgg.Net.Common.Infrastructure.Http
{
    /// <summary>
    /// A wrapper around a HttpClient.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BggClient : IHttpClient, IDisposable
    {
        readonly HttpClient httpClient;
        private bool disposed = false;

        /// <summary>
        /// Constructs a new instance of the BggClient with a default path.
        /// </summary>
        public BggClient()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(Constants.BggBaseUrl)
            };
        }

        /// <summary>
        /// Constructs a new instance of the BggClient with the given base address.
        /// </summary>
        /// <param name="baseAddress"></param>
        public BggClient(string baseAddress)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        /// <inheritdoc cref="HttpClient.DeleteAsync(string)"/>
        public virtual Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return httpClient.DeleteAsync(url);
        }

        /// <inheritdoc cref="HttpClient.GetAsync(string)"/>
        public virtual Task<HttpResponseMessage> GetAsync(string url)
        {
            return httpClient.GetAsync(url);
        }

        /// <inheritdoc cref="HttpClient.PostAsync(string, HttpContent)"/>
        public virtual Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return httpClient.PostAsync(url, content);
        }

        /// <inheritdoc cref="HttpClient.PutAsync(string, HttpContent)"/>
        public virtual Task<HttpResponseMessage> PutAsync(string url, HttpContent content)
        {
            return httpClient.PutAsync(url, content);
        }

        /// <inheritdoc cref="HttpClient.SendAsync(HttpRequestMessage)"/>
        public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return httpClient.SendAsync(request);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                httpClient.Dispose();
            }

            disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
