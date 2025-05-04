using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Dto.Rack;
using Warehouse.Application.Interfaces;
using Warehouse.Application.Mapping;
using Warehouse.Logic.Entities;

namespace Warehouse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RackController : ControllerBase
{
    private readonly IRackService _rackService;

    public RackController(IRackService rackService)
    {
        _rackService = rackService;
    }

    [HttpGet("zone/{zoneId}")]
    public async Task<ActionResult<IReadOnlyList<RackEntity>>> GetByZone(Guid zoneId)
    {
        var racks = await _rackService.GetByZone(zoneId);
        return Ok(racks.Select(x=>x.ToShortDto()));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RackEntity>> GetById(Guid id)
    {
        var rack = await _rackService.GetById(id);
        if (rack == null)
        {
            return NotFound();
        }
        return Ok(rack.ToDto());
    }

    [HttpPost]
    public async Task<ActionResult> AddRack(CreateUpdateRackDto dto)
    {
        var rack = await _rackService.AddRack(dto);
        return Ok("Rack created successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRack(Guid id, CreateUpdateRackDto dto)
    {
        await _rackService.UpdateRack(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRack(Guid id)
    {
        try
        {
            await _rackService.DeleteRack(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}