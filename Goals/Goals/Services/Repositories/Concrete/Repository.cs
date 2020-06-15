using Goals.Helpers;
using Messenger.Repositories.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Messenger.Repositories.Concrete
{
    class Repository<T> : IRepository<T> where T : class
    {
        public string BaseUrl { get; } = ApplicationSettings.UrlBase;
        public async Task Add(T item)
        {
            string json = GetJsonString(item);
            string controller = $"{typeof(T).Name.ToLower()}s";
            string UriString = $"{BaseUrl}/{controller}/create";
            using (HttpClient client = new HttpClient())
            {
                using (HttpContent content = new StringContent(json))
                {
                    using (HttpRequestMessage request = new HttpRequestMessage())
                    {
                        request.RequestUri = new Uri(UriString);
                        request.Method = HttpMethod.Post;
                        request.Content = content;

                        using (HttpResponseMessage response = await client.SendAsync(request))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                string responseString = await response.Content.ReadAsStringAsync();
                            }
                            else
                            {
                                string errorResponseString = await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
            }
        }

        public async Task Update(T item)
        {
            string json = GetJsonString(item);
            string controller = $"{typeof(T).Name.ToLower()}s";
            string UriString = $"{BaseUrl}/{controller}/update";
            using (HttpClient client = new HttpClient())
            {
                using (HttpContent content = new StringContent(json))
                {
                    using (HttpRequestMessage request = new HttpRequestMessage())
                    {
                        request.RequestUri = new Uri(UriString);
                        request.Method = HttpMethod.Post;
                        request.Content = content;

                        using (HttpResponseMessage response = await client.SendAsync(request))
                        {
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                string responseString = await response.Content.ReadAsStringAsync();
                            }
                            else
                            {
                                string errorResponseString = await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
            }
        }

        public async Task Delete(int id)
        {
            string controller = $"{typeof(T).Name.ToLower()}s";
            string UriString = $"{BaseUrl}/{controller}/delete/{id}";
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri(UriString);
                    request.Method = HttpMethod.Get;
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string responseString = await response.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            string errorResponseString = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
        }

        public async Task<T> Find(int id)
        {
            string controller = $"{typeof(T).Name.ToLower()}s";
            string UriString = $"{BaseUrl}/{controller}/find/{id}";
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri(UriString);
                    request.Method = HttpMethod.Get;
                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            string responseString = await response.Content.ReadAsStringAsync();
                            T item = GetItemFromJson<T>(responseString);
                            return item;
                        }
                        else
                        {
                            string errorResponseString = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<T>> GetAll()
        {
            var collection = new List<T>();
            string controller = $"{typeof(T).Name.ToLower()}s";
            string UriString = $"{BaseUrl}/{controller}/get";
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri(UriString);
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Accept", "application/json");

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            HttpContent responseContent = response.Content;
                            var json = await responseContent.ReadAsStringAsync();
                            collection = GetListFromJson<T>(json);
                        }
                        else
                        {
                            string errorResponseString = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            return collection;
        }

        public async Task<List<T>> FindAll(int id)
        {
            var collection = new List<T>();
            string controller = $"{typeof(T).Name.ToLower()}s";
            string UriString = $"{BaseUrl}/{controller}/findall/id";
            using (HttpClient client = new HttpClient())
            {
                using (HttpRequestMessage request = new HttpRequestMessage())
                {
                    request.RequestUri = new Uri(UriString);
                    request.Method = HttpMethod.Get;
                    request.Headers.Add("Accept", "application/json");

                    using (HttpResponseMessage response = await client.SendAsync(request))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            HttpContent responseContent = response.Content;
                            var json = await responseContent.ReadAsStringAsync();
                            collection = GetListFromJson<T>(json);
                        }
                        else
                        {
                            string errorResponseString = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
            }
            return collection;
        }

        protected string GetJsonString(T item)
        {
            return System.Text.Json.JsonSerializer.Serialize<T>(item);
        }

        protected List<T> GetListFromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        protected T GetItemFromJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
