using PriceState.Data.Models;
using PriceState.Interfaces.Model.Region;
using PriceState.Interfaces.Model.Unit;

namespace PriceState.Interfaces;

public interface IUnitService
{
    Task<Unit?> CreateUnitAsync(string name);

    Task<GetUnitsResponse> GetAllUnitAsync(GetUnitsRequest request);

    Task<Unit> GetUnitAsync(int unitId);

    Task RenameUnitAsync(int unitId, string name);

    Task DeleteUnitAsync(int unitId);
}