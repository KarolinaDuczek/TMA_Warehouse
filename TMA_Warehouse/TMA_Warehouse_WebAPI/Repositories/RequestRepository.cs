using Microsoft.EntityFrameworkCore;
using TMA_Warehouse_database.Context;
using TMA_Warehouse_database.Entities;

namespace TMA_Warehouse_WebAPI.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly WarehouseContext _context;
        public RequestRepository(WarehouseContext context)
        {
            _context = context;
        }
        public async Task AddRequest(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequest(int id)
        {
            var requestToDelete = await _context.Requests.FindAsync(id);
            if (requestToDelete is null)
            {
                throw new Exception("Object not found");
            }

            _context.Requests.Remove(requestToDelete);
            _context.SaveChanges();
        }

        public async Task<Request> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            return request;
        }

        public async Task<IEnumerable<Request>> GetRequests()
        {
            var requests = await _context.Requests.ToListAsync();
            return requests;
        }

        public async Task<Request> UpdateRequest(int id, Request request)
        {
            var dbRequest = await _context.Requests.FindAsync(id);

            dbRequest.EmployeeName = request.EmployeeName;
            dbRequest.ItemId = request.ItemId;
            dbRequest.Quantity = request.Quantity;
            dbRequest.PriceWithoutVAT = request.PriceWithoutVAT;
            dbRequest.Comment = request.Comment;
            dbRequest.Status = request.Status;

            await _context.SaveChangesAsync();
            return dbRequest;
        }
    }
}
