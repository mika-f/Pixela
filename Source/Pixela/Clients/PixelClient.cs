﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Pixela.Extensions;
using Pixela.Models;

namespace Pixela.Clients
{
    public class PixelClient : ApiClient
    {
        internal PixelClient(PixelaClient client) : base(client) { }

        private async Task<ApiResponse> CreateAsyncInternal<T>(string graphId, DateTime date, T quantity, string optionalData)
        {
            var parameters = new Dictionary<string, object>
            {
                ["date"] = date.ToString("yyyyMMdd"),
                ["quantity"] = quantity.ToString()
            };

            if (!string.IsNullOrWhiteSpace(optionalData))
                parameters.Add("optionalData", optionalData);

            return await Client.SendAsync<ApiResponse>(HttpMethod.Post, $"/v1/users/{Client.Username}/graphs/{graphId}", parameters).Stay();
        }

        /// <summary>
        ///     It records the quantity of the specified date as a "Pixel".
        /// </summary>
        /// <param name="graphId">ID of graph</param>
        /// <param name="date">the date on witch the quantity is to be recorded.</param>
        /// <param name="quantity">quantity to be registered on the specified date</param>
        /// <param name="optionalData">additional information other than quantity.</param>
        /// <returns></returns>
        public async Task<ApiResponse> CreateAsync(string graphId, DateTime date, float quantity, string optionalData = null)
        {
            return await CreateAsyncInternal(graphId, date, quantity, optionalData).Stay();
        }

        /// <summary>
        ///     It records the quantity of the specified date as a "Pixel".
        /// </summary>
        /// <param name="graphId">ID of graph</param>
        /// <param name="date">the date on witch the quantity is to be recorded.</param>
        /// <param name="quantity">quantity to be registered on the specified date</param>
        /// <param name="optionalData">additional information other than quantity.</param>
        /// <returns></returns>
        public async Task<ApiResponse> CreateAsync(string graphId, DateTime date, int quantity, string optionalData = null)
        {
            return await CreateAsyncInternal(graphId, date, quantity, optionalData).Stay();
        }

        /// <summary>
        ///     Get registered quantity as "Pixel".
        /// </summary>
        /// <param name="graphId">ID of graph</param>
        /// <param name="date">date to register the quantity</param>
        /// <returns></returns>
        public async Task<Pixel> ShowAsync(string graphId, DateTime date)
        {
            return await Client.GetAsync<Pixel>($"/v1/users/{Client.Username}/graphs/{graphId}/{date:yyyyMMdd}").Stay();
        }

        private async Task<ApiResponse> UpdateAsyncInternal<T>(string graphId, DateTime date, T quantity, string optionalData)
        {
            var parameters = new Dictionary<string, object> {["quantity"] = quantity.ToString()};
            if (!string.IsNullOrWhiteSpace(optionalData))
                parameters.Add("optionalData", optionalData);
            return await Client.SendAsync<ApiResponse>(HttpMethod.Put, $"/v1/users/{Client.Username}/graphs/{graphId}/{date:yyyyMMdd}", parameters).Stay();
        }

        /// <summary>
        ///     Update the quantity already registered as a "Pixel".
        /// </summary>
        /// <param name="graphId">ID of graph</param>
        /// <param name="date">date to update the quantity</param>
        /// <param name="quantity">the quantity to be registered on specified date.</param>
        /// <param name="optionalData">additional information other than quantity.</param>
        /// <returns></returns>
        public async Task<ApiResponse> UpdateAsync(string graphId, DateTime date, float quantity, string optionalData = null)
        {
            return await UpdateAsyncInternal(graphId, date, quantity, optionalData).Stay();
        }

        /// <summary>
        ///     Update the quantity already registered as a "Pixel".
        /// </summary>
        /// <param name="graphId">ID of graph</param>
        /// <param name="date">date to update the quantity</param>
        /// <param name="quantity">the quantity to be registered on specified date.</param>
        /// <param name="optionalData">additional information other than quantity.</param>
        /// <returns></returns>
        public async Task<ApiResponse> UpdateAsync(string graphId, DateTime date, int quantity, string optionalData = null)
        {
            return await UpdateAsyncInternal(graphId, date, quantity, optionalData).Stay();
        }

        /// <summary>
        ///     Increment quantity "Pixel" of the day (UTC).
        /// </summary>
        /// <param name="graphId">ID of graph</param>
        /// <returns></returns>
        public async Task<ApiResponse> IncrementAsync(string graphId)
        {
            return await Client.SendAsync<ApiResponse>(HttpMethod.Put, $"/v1/users/{Client.Username}/graphs/{graphId}/increment").Stay();
        }

        /// <summary>
        ///     Decrement quantity "Pixel" of the day (UTC).
        /// </summary>
        /// <param name="graphId">ID of graph</param>
        /// <returns></returns>
        public async Task<ApiResponse> DecrementAsync(string graphId)
        {
            return await Client.SendAsync<ApiResponse>(HttpMethod.Put, $"/v1/users/{Client.Username}/graphs/{graphId}/decrement").Stay();
        }

        /// <summary>
        ///     Delete the registered "Pixel".
        /// </summary>
        /// <param name="graphId">ID of graph</param>
        /// <param name="date">date to delete "Pixel"</param>
        /// <returns></returns>
        public async Task<ApiResponse> DestroyAsync(string graphId, DateTime date)
        {
            return await Client.SendAsync<ApiResponse>(HttpMethod.Delete, $"/v1/users/{Client.Username}/graphs/{graphId}/{date:yyyyMMdd}").Stay();
        }
    }
}