using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warehouse.Application.Interfaces;
using Warehouse.Persistence;

namespace Warehouse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ZoneController : ControllerBase
{
    private readonly IZoneService _zoneService;
    private readonly WarehouseDbContext _context;

    public ZoneController(IZoneService zoneService, WarehouseDbContext context)
    {
        _zoneService = zoneService;
        _context = context;
    }

    [HttpGet]
    [Route("warehouse/{warehouseId}")]
    public async Task<IActionResult> GetZones(Guid warehouseId)
    {
        var exists = await _context.Warehouses.AnyAsync(w => w.Id == warehouseId);
        if(!exists)
        {
            return NotFound("Warehouse not found");
        }
        var zones = await _zoneService.GetByWarehouse(warehouseId);
        return Ok(zones);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetZone(Guid id)
    {
        var zone = await _zoneService.GetById(id);
        if (zone == null)
        {
            return NotFound();
        }
        return Ok(zone);
    }

    
}