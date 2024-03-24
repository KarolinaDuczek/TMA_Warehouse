using TMA_Warehouse_database.Entities;

namespace TMA_Warehouse_WebAPI.Repositories
{
    public interface IRequestRepository
    {
        Task<IEnumerable<Request>> GetRequests();
        Task<Request> GetRequest(int id);
        Task AddRequest(Request request);
        Task DeleteRequest(int id);
        Task<Request> UpdateRequest(int id, Request request);
    }
}
