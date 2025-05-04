
using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Dto.Warehouse;
using Warehouse.Application.Interfaces;
using Warehouse.Application.Mapping;


namespace Warehouse.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
    private readonly IWarehouseService _warehouseService;
    

    public WarehouseController(IWarehouseService warehouseService)    
    {
        _warehouseService = warehouseService;
        
    }
    

    [HttpGet]
    public async Task<IActionResult> GetWarehouses()
    {
        var warehouses = await _warehouseService.GetAllWarehousesAsync();
        return Ok(warehouses.Select(w=> w.ToDto()).ToList());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWarehouse(Guid id)
    {
        var warehouse = await _warehouseService.GetById(id);
        if (warehouse == null)
        {
            return NotFound();
        }
        return Ok(warehouse.ToDto());   
    }
    
    [HttpPost]
    public async Task<IActionResult> AddWarehouse(CreateUpdateWarehouseDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); 
        await _warehouseService.AddWarehouse(dto);
        return Ok("Warehouse added successfully");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWarehouse(Guid id, CreateUpdateWarehouseDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState); 
        await _warehouseService.UpdateWarehouse(id, dto);
        return Ok("Warehouse updated successfully");
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _warehouseService.DeleteWarehouse(id);
        return Ok("Warehouse deleted successfully");
    }
    
}