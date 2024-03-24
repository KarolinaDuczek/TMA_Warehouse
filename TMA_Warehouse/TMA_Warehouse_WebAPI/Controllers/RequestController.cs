using Microsoft.AspNetCore.Mvc;
using TMA_Warehouse_Models.DTOs;
using TMA_Warehouse_WebAPI.Extensions;
using TMA_Warehouse_WebAPI.Repositories;

namespace TMA_Warehouse_WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IRequestRepository _requestRepository;
    public RequestController(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RequestDto>>> GetRequests()
    {
        var requests = await _requestRepository.GetRequests();
        if (requests == null)
        {
            return NotFound();
        }
        else
        {
            var requestDtos = requests.ConvertToDto();
            return Ok(requestDtos);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RequestDto>> GetRequestById(int id)
    {
        try
        {
            var request = await _requestRepository.GetRequest(id);
            if (request == null)
            {
                return BadRequest();
            }
            else
            {
                var requestDtos = request.ConvertToDto();
                return Ok(requestDtos);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<NoContentResult> AddRequest(RequestDto request)
    {
        var requestToAdd = request.ConvertToEntity();
        await _requestRepository.AddRequest(requestToAdd);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<NoContentResult> UpdateRequestById(int id, RequestDto request)
    {
        var requestToUpdate = request.ConvertToEntity();
        await _requestRepository.UpdateRequest(id, requestToUpdate);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteRequestById(int id)
    {
        try
        {
            await _requestRepository.DeleteRequest(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
