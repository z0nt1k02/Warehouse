using Warehouse.Application.Interfaces;
using Warehouse.Application.Services;
using Warehouse.Logic.Stores;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Extensions;

public static class DIExtensions
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped<IWarehouseStore, WarehouseRepository>();
        services.AddScoped<IWarehouseService, WarehouseService>();

        services.AddScoped<IZoneStore, ZoneRepository>();
        services.AddScoped<IZoneService, ZoneService>();
    }
}