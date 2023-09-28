﻿using Newtonsoft.Json;
using NuGet.ContentModel;
using SeatManagement2.Models;
using SeatManagementFE.Interfaces;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SeatManagementFE.Implementation
{
    public class ApiCall<T> : IApiCall<T> where T : class
    {
        private readonly string endPoint;
        private readonly HttpClient client;

        public ApiCall(string ep)
        {
            endPoint = ep;
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7097/api/");
        }
        public List<T> GetData()
        {
            var response = client.GetAsync(endPoint).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var getResponse = JsonConvert.DeserializeObject<List<T>>(responseContent);
                return getResponse;
            }
            else
            {
                return null;
            }
        }

        public int PostData(T data)
        {
            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(endPoint, content).Result;

            var responseContent = response.Content.ReadAsStringAsync().Result;
            if (int.TryParse(responseContent, out int res))
            {
                return res;
            }
            return 0;
        }

        public bool UpdateData(T data)
        {
            var json = JsonSerializer.Serialize(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PatchAsync(endPoint, content).Result;

            var responseContent = response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateAssetData(int assetId, int? employeeId)
        {
            var response = client.PatchAsync(endPoint, null).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}