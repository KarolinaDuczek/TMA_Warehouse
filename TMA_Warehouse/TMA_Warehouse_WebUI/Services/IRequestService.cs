using TMA_Warehouse_Models.DTOs;
using TMA_Warehouse_WebUI.Model;

namespace TMA_Warehouse_WebUI.Services
{
    public interface IRequestService
    {
        IEnumerable<RequestDto> Requests { get; set; }
        Task GetRequests();
        Task<RequestModel?> GetRequestById(int id);
        Task AddRequest(RequestModel request);
        Task UpdateRequest(int id, RequestModel request);
        Task DeleteRequest(int id);
    }
}
