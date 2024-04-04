using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;
using TMA_Warehouse_database.Entities;
using TMA_Warehouse_Models.DTOs;
using TMA_Warehouse_WebUI.Model;
using TMA_Warehouse_WebUI.Pages;

namespace TMA_Warehouse_WebUI.Services
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public RequestService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
        }
        public IEnumerable<RequestDto> Requests { get; set; }

        public async Task AddRequest(RequestModel request)
        {
            await _http.PostAsJsonAsync("api/Request", request);
            _navigationManger.NavigateTo("requests");
        }

        public async Task DeleteRequest(int id)
        {
            var result = await _http.DeleteAsync($"api/Request/{id}");
            _navigationManger.NavigateTo("requests");
        }

        public async Task<RequestModel?> GetRequestById(int id)
        {
            var result = await _http.GetAsync($"api/Request/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<RequestModel>();
            }
            return null;
        }

        public async Task GetRequests()
        {
            var result = await _http.GetFromJsonAsync<IEnumerable<RequestDto>>("api/Request");
            if (result is not null)
                Requests = result;
        }

        public async Task UpdateRequest(int id, RequestModel request)
        {
            await _http.PutAsJsonAsync($"api/Request/{id}", request);
            _navigationManger.NavigateTo("requests");
        }
    }
}
