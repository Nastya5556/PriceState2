using Microsoft.EntityFrameworkCore;
using PriceState.Data;
using PriceState.Data.Models;
using PriceState.Interfaces;
using PriceState.Interfaces.Model;
using PriceState.Interfaces.Model.Unit;
using PriceState.Interfaces.Pagination;

namespace PriceState.Services;

public class UnitService: IUnitService
{
    private readonly DataContext _db;

    public UnitService(DataContext db)
    {
        _db = db;
    }

    public async Task<Unit> CreateUnitAsync( string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new PriceStateException("Incorrect Unit name!", EnumErrorCode.ArgumentIsIncorrect);

        if (await _db.Units.AnyAsync(x => x.Name == name))
            throw new PriceStateException($"Unit with name {name} is already exists!", EnumErrorCode.EntityIsAlreadyExists);


        var unit = new Unit
        {
            Name = name,

        };

        await _db.Units.AddAsync(unit);
        await _db.SaveChangesAsync();

        return unit;
    }
	


    public async Task<GetUnitsResponse> GetAllUnitAsync(GetUnitsRequest request)
    {
        return await _db.Units.GetPageAsync<GetUnitsResponse, Unit, UnitModel>(request, unit =>
            new UnitModel
            {
                Id = unit.Id,
                Name = unit.Name
            });
    }



    public async Task<Unit> GetUnitAsync(int unitId)
    {
        return await _db.Units.FirstOrDefaultAsync(x => x.Id == unitId) 
               ?? throw new PriceStateException($"Unit {unitId} is not found!", EnumErrorCode.EntityIsNotFound);
    }



    public async Task RenameUnitAsync(int unitId, string name)
    {
        var unit = await _db.Units.FirstOrDefaultAsync(x => x.Id == unitId);
        if (unit is null)
            throw new PriceStateException($"Unit {unitId} is not exists!", EnumErrorCode.EntityIsNotFound);

        unit.Name = name;
        await _db.SaveChangesAsync();
    }
	
	
    public async Task DeleteUnitAsync(int unitId)
    {
        _db.Units.Remove(new Unit {Id = unitId});
        await _db.SaveChangesAsync();
    }
	
}