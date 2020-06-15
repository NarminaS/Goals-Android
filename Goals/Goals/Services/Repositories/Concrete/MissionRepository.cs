using Goals.DTO;
using Goals.Models;
using Goals.Services.Repositories.Abstract;
using Messenger.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Goals.Services.Repositories.Concrete
{
    class MissionRepository : Repository<Mission>, IMissionRepository
    {
        public async Task<MissionSimpleDto> CreateForList(MissionCreateDto mission)
        {
            Mission dbMission = new Mission 
            { Name = mission.Name, 
                Deadline = mission.Deadline,
                Description = mission.Description,
                TotalSum = mission.TotalSum
            };
            string json = GetJsonString(dbMission);
            string controller = $"{typeof(Mission).Name.ToLower()}s";
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
                                MissionSimpleDto dto = GetItemFromJson<MissionSimpleDto>(responseString);
                                return dto;
                            }
                            else
                            {
                                string errorResponseString = await response.Content.ReadAsStringAsync();
                            }
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<MissionSimpleDto>> GetMissionsForList()
        {
            var collection = new List<MissionSimpleDto>();
            string UriString = $"{BaseUrl}/missions/getforlist";
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
                            collection = GetListFromJson<MissionSimpleDto>(json);
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

        public async Task<MissionDetailDto> GetForDetail(int id)
        {
            string controller = $"missions";
            string UriString = $"{BaseUrl}/{controller}/getfordetail/{id}";
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
                            MissionDetailDto item = GetItemFromJson<MissionDetailDto>(responseString);
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
    }
}
